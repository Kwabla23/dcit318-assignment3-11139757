namespace Question4_Grading;

public class Student
{
    public int Id { get; }
    public string FullName { get; }
    public int Score { get; }

    public Student(int id, string fullName, int score)
    {
        Id = id; FullName = fullName; Score = score;
    }

    public string GetGrade() =>
        Score >= 80 && Score <= 100 ? "A" :
        Score >= 70 ? "B" :
        Score >= 60 ? "C" :
        Score >= 50 ? "D" : "F";

    public override string ToString() => $"{FullName} (ID: {Id}): Score = {Score}, Grade = {GetGrade()}";
}
