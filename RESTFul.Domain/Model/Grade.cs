using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Model;

public class Grade
{
    public int GradeId { get; set; }
    public int RecordId { get; set; }
    public decimal GradeValue { get; set; }
    public GradeType GradeType { get; set; }
    public DateTime GradeDate { get; set; }
    public int TeacherId { get; set; }
    public decimal? MaxPoints { get; set; }
    public string Comments { get; set; } = string.Empty;

    // Navigation properties
    public AcademicRecord? AcademicRecord { get; set; }
    public Teacher? Teacher { get; set; }
}
