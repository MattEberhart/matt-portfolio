namespace CloudProviders.StorageProviders;

public interface ITableProviderFactory
{
    public ITableProvider GetTableProvider(string tableName);
}