using System.IO;
using Newtonsoft.Json;

namespace SkateparkManagement
{
    public static class JsonHandler
    {
        public static T ReadFromJsonFile<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            return default;
        }

        public static void WriteToJsonFile<T>(string filePath, T data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
