using Question3_Warehouse;

var mgr = new WareHouseManager();
mgr.SeedData();
mgr.PrintAll();
Console.WriteLine();
mgr.DemoExceptionScenarios();
