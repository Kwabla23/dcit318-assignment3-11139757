namespace Question3_Warehouse;

public interface IInventoryItem
{
    int Id { get; }
    string Name { get; }
    int Quantity { get; set; }
}

public class ElectronicItem : IInventoryItem
{
    public int Id { get; }
    public string Name { get; }
    public int Quantity { get; set; }
    public string Brand { get; }
    public int WarrantyMonths { get; }

    public ElectronicItem(int id, string name, int quantity, string brand, int warrantyMonths)
    {
        Id = id; Name = name; Quantity = quantity; Brand = brand; WarrantyMonths = warrantyMonths;
    }

    public override string ToString() => $"[Electronic] #{Id} {Name} ({Brand}) x{Quantity}, Warranty: {WarrantyMonths} mo";
}

public class GroceryItem : IInventoryItem
{
    public int Id { get; }
    public string Name { get; }
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; }

    public GroceryItem(int id, string name, int quantity, DateTime expiryDate)
    {
        Id = id; Name = name; Quantity = quantity; ExpiryDate = expiryDate;
    }

    public override string ToString() => $"[Grocery] #{Id} {Name} x{Quantity}, Exp: {ExpiryDate:d}";
}
