using Azure.Data.Tables;
using Azure.Identity;
using Microsoft.Extensions.Azure;

namespace CloudProviders.StorageProviders;

public class AzureTableProviderFactory : ITableProviderFactory
{
    private TableServiceClient _tableServiceClient;
    private Dictionary<string, ITableProvider> _tableClients;
    
    public AzureTableProviderFactory(AzureStorageProviderSettings settings)
    {
        this._tableServiceClient = new TableServiceClient(
            new Uri(settings.AzureStorageUrl),
            new DefaultAzureCredential());
        this._tableClients = new Dictionary<string, ITableProvider>();
    }
    
    public ITableProvider GetTableProvider(string tableName)
    {
        if (this._tableClients.TryGetValue(tableName, out var table))
        {
            return table;
        }
        
        var tableClient = this._tableServiceClient.GetTableClient(tableName);
        var tableProvider = new AzureTableProvider(tableClient);
        this._tableClients.TryAdd(tableName, tableProvider);

        return tableProvider;
    }
}