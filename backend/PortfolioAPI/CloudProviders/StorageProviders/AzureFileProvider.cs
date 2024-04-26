using Azure;
using Azure.Identity;
using Azure.Storage.Blobs;

namespace CloudProviders.StorageProviders;

public class AzureFileProvider : IFileProvider
{
    private BlobServiceClient _blobServiceClient;
    private Dictionary<string, BlobContainerClient> _blobContainerClients;
    private Dictionary<string, BlobClient> _blobClients;
    
    
    public AzureFileProvider(AzureStorageProviderSettings settings)
    {
        this._blobServiceClient = new BlobServiceClient(
            new Uri(settings.AzureStorageUrl),
            new DefaultAzureCredential());

        this._blobContainerClients = new Dictionary<string, BlobContainerClient>();
        this._blobClients = new Dictionary<string, BlobClient>();
    }

    public async Task CreateFileAsync(string folderName, string fileName, Stream stream)
    {
        var blobContainerClient = await GetBlobContainerClientAsync(folderName);
        await blobContainerClient.UploadBlobAsync(fileName, stream);
    }

    public async Task<Stream> GetFileAsync(string folderName, string fileName)
    {
        try
        {
            var blobClient = await GetBlobClientAsync(folderName, fileName);
            var stream = new MemoryStream();
            await blobClient.DownloadToAsync(stream);
            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }
        catch (RequestFailedException e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Stream>> GetAllFilesAsync(string folderName)
    {
        var blobContainerClient = await GetBlobContainerClientAsync(folderName);
        var blobs = blobContainerClient.GetBlobsAsync();
        var streams = new List<Stream>();
        await foreach (var blob in blobs)
        {
            var stream = new MemoryStream();
            var blobClient = await GetBlobClientAsync(folderName, blob.Name);
            await blobClient.DownloadToAsync(stream);
            stream.Seek(0, SeekOrigin.Begin);
            streams.Add(stream);
        }

        return streams;
    }

    public async Task UpdateFileAsync(string folderName, string fileName, Stream stream)
    {
        var blobClient = await GetBlobClientAsync(folderName, fileName);
        await blobClient.UploadAsync(stream, overwrite: true);
    }

    public async Task DeleteFileAsync(string folderName, string fileName)
    {
        var blobClient = await GetBlobClientAsync(folderName, fileName);
        await blobClient.DeleteAsync();
    }

    private async Task<BlobContainerClient> GetBlobContainerClientAsync(string folderName)
    {
        if (!this._blobContainerClients.ContainsKey(folderName))
        {
            BlobContainerClient blobContainerClient;
            try
            {
                blobContainerClient = await this._blobServiceClient.CreateBlobContainerAsync(folderName);
            }
            catch (RequestFailedException e)
            {
                blobContainerClient = this._blobServiceClient.GetBlobContainerClient(folderName);
            }

            this._blobContainerClients[folderName] = blobContainerClient;
        }

        return this._blobContainerClients[folderName];
    }
    
    private async Task<BlobClient> GetBlobClientAsync(string folderName, string fileName)
    {
        var blobClientKeyName = $"{folderName}_{fileName}";
        if (!this._blobClients.ContainsKey(blobClientKeyName))
        {
            var containerClient = await GetBlobContainerClientAsync(folderName);
            var blobClient = containerClient.GetBlobClient(fileName);
            this._blobClients[blobClientKeyName] = blobClient;
        }

        return this._blobClients[blobClientKeyName];
    }
}