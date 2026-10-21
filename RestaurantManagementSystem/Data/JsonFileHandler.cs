
using System.Text.Json;

namespace RestaurantManagementSystem.Data
{
    public class JsonFileHandler<T> where T : class
    {
        private readonly string filePath;

        private readonly JsonSerializerOptions options =
            new JsonSerializerOptions
            {
                WriteIndented = true
            };

        public JsonFileHandler(string fileName)
        {
            string folderPath = Path.Combine(
                AppContext.BaseDirectory, "Storage");

            Directory.CreateDirectory(folderPath);

            filePath = Path.Combine(folderPath, fileName);
        }

        public void Save(List<T> data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, options);
                File.WriteAllText(filePath, json);

                Console.WriteLine("Data saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Save error: {ex.Message}");
            }
        }

        public List<T> Load()
        {
            try
            {
                if (!File.Exists(filePath))
                    return new List<T>();

                string json = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(json))
                    return new List<T>();

                return JsonSerializer.Deserialize<List<T>>(json)
                       ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Load error: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
