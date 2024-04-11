namespace CloudProviders.StorageProviders;

public interface IStorageProvider
{
    public Task CreateFileAsync(string folderName, string fileName, Stream stream);

    public Task<Stream> GetFileAsync(string folderName, string fileName);

    public Task<IEnumerable<Stream>> GetAllFilesAsync(string folderName);

    public Task UpdateFileAsync(string folderName, string fileName, Stream stream);

    public Task DeleteFileAsync(string folderName, string fileName);
}