namespace Question2_HealthSystem;

public class HealthSystemApp
{
    private readonly Repository<Patient> _patientRepo = new();
    private readonly Repository<Prescription> _prescriptionRepo = new();
    private readonly Dictionary<int, List<Prescription>> _prescriptionMap = new();

    public void SeedData()
    {
        _patientRepo.Add(new Patient(1, "Alice Smith", 30, "Female"));
        _patientRepo.Add(new Patient(2, "Bob Johnson", 45, "Male"));
        _patientRepo.Add(new Patient(3, "Cynthia Lee", 29, "Female"));

        _prescriptionRepo.Add(new Prescription(101, 1, "Amoxicillin", DateTime.Today.AddDays(-7)));
        _prescriptionRepo.Add(new Prescription(102, 1, "Ibuprofen", DateTime.Today.AddDays(-3)));
        _prescriptionRepo.Add(new Prescription(103, 2, "Lisinopril", DateTime.Today.AddDays(-1)));
        _prescriptionRepo.Add(new Prescription(104, 3, "Metformin", DateTime.Today));
        _prescriptionRepo.Add(new Prescription(105, 2, "Atorvastatin", DateTime.Today.AddDays(-2)));
    }

    public void BuildPrescriptionMap()
    {
        _prescriptionMap.Clear();
        foreach (var p in _prescriptionRepo.GetAll())
        {
            if (!_prescriptionMap.TryGetValue(p.PatientId, out var list))
            {
                list = new List<Prescription>();
                _prescriptionMap[p.PatientId] = list;
            }
            list.Add(p);
        }
    }

    public void PrintAllPatients()
    {
        Console.WriteLine("All Patients:");
        foreach (var p in _patientRepo.GetAll())
            Console.WriteLine(" - " + p);
    }

    public List<Prescription> GetPrescriptionsByPatientId(int patientId)
    {
        return _prescriptionMap.TryGetValue(patientId, out var list) ? new(list) : new List<Prescription>();
    }

    public void PrintPrescriptionsForPatient(int id)
    {
        Console.WriteLine($"Prescriptions for patient #{id}:");
        var list = GetPrescriptionsByPatientId(id);
        if (list.Count == 0) Console.WriteLine(" (none)");
        foreach (var pr in list) Console.WriteLine(" - " + pr);
    }
}
