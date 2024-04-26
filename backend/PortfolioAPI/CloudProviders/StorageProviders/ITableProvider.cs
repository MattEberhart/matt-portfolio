using System.Linq.Expressions;
using Azure.Data.Tables;

namespace CloudProviders.StorageProviders;

public interface ITableProvider
{
    public Task<T> CreateRecord<T>(T record) where T : ITableEntity;

    public Task<T> GetRecord<T>(string partitionKey, string rowKey) where T : class, ITableEntity;

    public Task<IEnumerable<T>> GetRecords<T>(Expression<Func<T, bool>> filter = null) where T : class, ITableEntity;

    public Task UpdateRecord<T>(T record, UpdateMode updateMode) where T : ITableEntity;

    public Task DeleteRecord(string partitionKey, string rowKey);

}