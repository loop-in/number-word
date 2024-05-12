using System.Text.Json;

namespace NumberToWord.Api.Common;

public static class JsonReader<T> where T : class
{
    public static T? GetObject(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(jsonString);
    }
}
