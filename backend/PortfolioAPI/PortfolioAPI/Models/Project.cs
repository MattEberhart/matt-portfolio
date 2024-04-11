using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PortfolioAPI.Models;

public class Project
{
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