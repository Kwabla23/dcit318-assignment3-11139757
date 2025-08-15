using Question5_InventoryLogger;

var app = new InventoryApp("inventory.json");
app.SeedSampleData();
app.SaveData();

// Simulate a new session by making a new app instance
var app2 = new InventoryApp("inventory.json");
app2.LoadData();
app2.PrintAllItems();
