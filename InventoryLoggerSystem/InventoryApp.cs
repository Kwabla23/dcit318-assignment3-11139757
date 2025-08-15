namespace Question5_InventoryLogger;

public class InventoryApp
{
    private readonly InventoryLogger<InventoryItem> _logger;

    public InventoryApp(string filePath)
    {
        _logger = new InventoryLogger<InventoryItem>(filePath);
    }

    public void SeedSampleData()
    {
        _logger.Add(new InventoryItem(1, "Printer Paper (A4)", 50, DateTime.Today));
        _logger.Add(new InventoryItem(2, "USB-C Cable", 25, DateTime.Today.AddDays(-1)));
        _logger.Add(new InventoryItem(3, "Stapler", 10, DateTime.Today.AddDays(-2)));
        _logger.Add(new InventoryItem(4, "Ethernet Cable (10m)", 15, DateTime.Today.AddDays(-5)));
        _logger.Add(new InventoryItem(5, "Desk Chair", 3, DateTime.Today.AddDays(-10)));
    }

    public void SaveData() => _logger.SaveToFile();
    public void LoadData() => _logger.LoadFromFile();

    public void PrintAllItems()
    {
        foreach (var item in _logger.GetAll())
            Console.WriteLine($"#{item.Id} {item.Name} x{item.Quantity} (Added: {item.DateAdded:d})");
    }
}
