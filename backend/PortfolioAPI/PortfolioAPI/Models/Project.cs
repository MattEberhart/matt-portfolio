using System.Text.Json.Serialization;
using Azure;
using Azure.Data.Tables;
using Newtonsoft.Json;
using JsonIgnore = Newtonsoft.Json.JsonIgnoreAttribute;

namespace PortfolioAPI.Models;

public class Project : ITableEntity
{
    [JsonIgnore]
    public virtual string PartitionKey { get; set; }
    
    [JsonIgnore]
    public virtual string RowKey { get => Id; set => Id = value; }
    
    [JsonIgnore]
    public ETag ETag { get; set; }
    
    [JsonIgnore]
    public DateTimeOffset? Timestamp { get; set; }


    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("about")]
    public string About { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("linkOne")]
    public string LinkOne { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("linkTwo")]
    public string LinkTwo { get; set; }
}