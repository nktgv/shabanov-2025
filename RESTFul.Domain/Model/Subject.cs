namespace RESTFul.Domain.Model;

public class Subject
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public string SubjectCode { get; set; } = string.Empty;
    public int TheoryHours { get; set; }
    public int PracticeHours { get; set; }
    public int LabHours { get; set; }
    public int SemesterNumber { get; set; }
    public bool IsElective { get; set; }

    // Navigation properties
    public ICollection<AcademicRecord> AcademicRecords { get; set; } = new List<AcademicRecord>();
}
