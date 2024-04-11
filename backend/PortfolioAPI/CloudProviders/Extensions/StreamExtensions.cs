using Newtonsoft.Json;

namespace CloudProviders.Extensions;

public static class StreamExtensions
{
    public static async Task<T> DeserializeStreamContent<T>(this Stream stream)
    {
        if (stream == null)
        {
            return default(T);
        }
        
        using (var streamReader = new StreamReader(stream))
        {
            var stringContent = await streamReader.ReadToEndAsync();
            return JsonConvert.DeserializeObject<T>(stringContent);
        }
    }

    public static Stream SerializeToStreamContent<T>(this T jsonObject)
    {
        var stringContent = JsonConvert.SerializeObject(jsonObject);
        MemoryStream stream = new MemoryStream();
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(stringContent);
        stream.Write(jsonBytes, 0, jsonBytes.Length);
        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }
}