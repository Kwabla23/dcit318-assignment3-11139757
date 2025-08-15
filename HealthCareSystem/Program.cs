using Question2_HealthSystem;

var app = new HealthSystemApp();
app.SeedData();
app.BuildPrescriptionMap();
app.PrintAllPatients();
Console.WriteLine();
app.PrintPrescriptionsForPatient(2);
