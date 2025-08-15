using System.Text.Json;

namespace Question5_InventoryLogger;

public class InventoryLogger<T> where T : IInventoryEntity
{
    private readonly List<T> _log = new();
    private readonly string _filePath;

    public InventoryLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(T item) => _log.Add(item);
    public List<T> GetAll() => new(_log);

    public void SaveToFile()
    {
        try
        {
            var json = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
            using var sw = new StreamWriter(_filePath, false);
            sw.Write(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
            throw;
        }
    }

    public void LoadFromFile()
    {
        try
        {
            using var sr = new StreamReader(_filePath);
            var json = sr.ReadToEnd();
            var items = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            _log.Clear();
            _log.AddRange(items);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found; starting with empty log.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
            throw;
        }
    }
}
