namespace Question3_Warehouse;

public class WareHouseManager
{
    private readonly InventoryRepository<ElectronicItem> _electronics = new();
    private readonly InventoryRepository<GroceryItem> _groceries = new();

    public void SeedData()
    {
        // Electronics
        _electronics.AddItem(new ElectronicItem(1, "Smartphone", 15, "Axiom", 24));
        _electronics.AddItem(new ElectronicItem(2, "Laptop", 8, "ZenTech", 12));
        _electronics.AddItem(new ElectronicItem(3, "Headphones", 25, "SoundMax", 18));

        // Groceries
        _groceries.AddItem(new GroceryItem(101, "Rice (5kg)", 40, DateTime.Today.AddMonths(12)));
        _groceries.AddItem(new GroceryItem(102, "Milk (1L)", 60, DateTime.Today.AddDays(20)));
        _groceries.AddItem(new GroceryItem(103, "Eggs (Tray)", 30, DateTime.Today.AddDays(10)));
    }

    public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
    {
        foreach (var item in repo.GetAllItems())
            Console.WriteLine(" - " + item);
    }

    public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
    {
        try
        {
            var item = repo.GetItemById(id);
            repo.UpdateQuantity(id, item.Quantity + quantity);
            Console.WriteLine($"Updated quantity for #{id} to {item.Quantity}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error increasing stock: {ex.Message}");
        }
    }

    public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
    {
        try
        {
            repo.RemoveItem(id);
            Console.WriteLine($"Removed item #{id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing item: {ex.Message}");
        }
    }

    public void DemoExceptionScenarios()
    {
        try
        {
            // Duplicate add
            _electronics.AddItem(new ElectronicItem(1, "Tablet", 5, "Axiom", 12));
        }
        catch (DuplicateItemException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }

        try
        {
            // Remove non-existent
            _groceries.RemoveItem(999);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }

        try
        {
            // Update invalid quantity
            _groceries.UpdateQuantity(101, -5);
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }
    }

    public void PrintAll()
    {
        Console.WriteLine("Groceries:");
        PrintAllItems(_groceries);
        Console.WriteLine("\nElectronics:");
        PrintAllItems(_electronics);
    }
}
