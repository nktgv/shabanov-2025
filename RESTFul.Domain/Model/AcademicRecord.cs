using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Model;

public class AcademicRecord
{
    public int RecordId { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public int? SemesterId { get; set; }
    public int? TeacherId { get; set; }
    public decimal? FinalGrade { get; set; }
    public int Status { get; set; }
    public RecordStatus RecordStatus { get; set; }
    public int AttemptNumber { get; set; }
    public DateTime? ExamDate { get; set; }

    // Navigation properties
    public Student? Student { get; set; }
    public Subject? Subject { get; set; }
    public Teacher? Teacher { get; set; }
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
