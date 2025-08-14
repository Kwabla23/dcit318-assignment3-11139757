using Question4_Grading;

try
{
    var processor = new StudentResultProcessor();
    string input = "students_input.txt";
    string output = "students_report.txt";
    var students = processor.ReadStudentsFromFile(input);
    processor.WriteReportToFile(students, output);
    Console.WriteLine($"Report written to: {output}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File not found: {ex.Message}");
}
catch (InvalidScoreFormatException ex)
{
    Console.WriteLine(ex.Message);
}
catch (MissingFieldException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
