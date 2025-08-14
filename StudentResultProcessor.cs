using System.Globalization;

namespace Question4_Grading;

public class StudentResultProcessor
{
    public List<Student> ReadStudentsFromFile(string inputFilePath)
    {
        var students = new List<Student>();
        using var sr = new StreamReader(inputFilePath);
        string? line;
        int lineNo = 0;
        while ((line = sr.ReadLine()) != null)
        {
            lineNo++;
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split(',');
            if (parts.Length != 3)
                throw new MissingFieldException($"Line {lineNo}: Expected 3 fields but got {parts.Length}.");
            try
            {
                int id = int.Parse(parts[0].Trim(), CultureInfo.InvariantCulture);
                string fullName = parts[1].Trim();
                int score = int.Parse(parts[2].Trim(), CultureInfo.InvariantCulture);
                students.Add(new Student(id, fullName, score));
            }
            catch (FormatException)
            {
                throw new InvalidScoreFormatException($"Line {lineNo}: Score is not a valid integer.");
            }
        }
        return students;
    }

    public void WriteReportToFile(List<Student> students, string outputFilePath)
    {
        using var sw = new StreamWriter(outputFilePath, false);
        foreach (var s in students)
        {
            sw.WriteLine(s.ToString());
        }
    }
}
