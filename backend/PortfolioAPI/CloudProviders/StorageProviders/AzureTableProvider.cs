using System.Linq.Expressions;
using Azure;
using Azure.Data.Tables;
using Azure.Identity;
using Microsoft.VisualBasic.CompilerServices;

namespace CloudProviders.StorageProviders;

public class AzureTableProvider : ITableProvider
{
    private TableClient _tableClient;

    public AzureTableProvider(TableClient tableClient)
    {
        this._tableClient = tableClient;
    }

    public async Task<T> CreateRecord<T>(T record) where T : ITableEntity
    {
        await this._tableClient.AddEntityAsync(record);
        return record;
    }

    public async Task<T> GetRecord<T>(string partitionKey, string rowKey) where T : class, ITableEntity
    {
        var recordResponse = await this._tableClient.GetEntityAsync<T>(partitionKey, rowKey);
        return recordResponse.Value;
    }

    public async Task<IEnumerable<T>> GetRecords<T>(Expression<Func<T,bool>> filter = null) where T : class, ITableEntity
    {
        filter ??= _ => true;
        var recordsPageable = this._tableClient.QueryAsync(filter);
        List<T> records = new List<T>();

        await foreach (var record in recordsPageable)
        {
            records.Add(record);
        }

        return records;
    }

    public async Task UpdateRecord<T>(T record, UpdateMode updateMode) where T : ITableEntity
    {
        var tableUpdateMode = updateMode == UpdateMode.Merge ? TableUpdateMode.Merge : TableUpdateMode.Replace;
        var recordResponse = await this._tableClient.UpdateEntityAsync(record, record.ETag, tableUpdateMode);
    }

    public async Task DeleteRecord(string partitionKey, string rowKey)
    {
        await this._tableClient.DeleteEntityAsync(partitionKey, rowKey);
    }
}