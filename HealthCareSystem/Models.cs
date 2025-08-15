namespace Question2_HealthSystem;

public class Patient
{
    public int Id { get; }
    public string Name { get; }
    public int Age { get; }
    public string Gender { get; }

    public Patient(int id, string name, int age, string gender)
    {
        Id = id; Name = name; Age = age; Gender = gender;
    }

    public override string ToString() => $"Patient #{Id}: {Name}, {Age}, {Gender}";
}

public class Prescription
{
    public int Id { get; }
    public int PatientId { get; }
    public string MedicationName { get; }
    public DateTime DateIssued { get; }

    public Prescription(int id, int patientId, string medicationName, DateTime dateIssued)
    {
        Id = id; PatientId = patientId; MedicationName = medicationName; DateIssued = dateIssued;
    }

    public override string ToString() => $"Prescription #{Id} for Patient {PatientId}: {MedicationName} ({DateIssued:d})";
}
