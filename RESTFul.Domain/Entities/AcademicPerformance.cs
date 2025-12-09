using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Entities;

public class AcademicPerformance
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid SubjectId { get; set; }
    public int Semester { get; set; }
    public ControlType ControlType { get; set; }
    public int? Grade { get; set; }
    public string? GradeLetter { get; set; }
    public DateTime ExamDate { get; set; }
    public Guid TeacherId { get; set; }

    // Navigation properties
    public Student Student { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
    public User Teacher { get; set; } = null!;

    // Methods
    public bool IsPassed()
    {
        if (Grade.HasValue)
        {
            return Grade.Value >= 3;
        }

        if (!string.IsNullOrEmpty(GradeLetter))
        {
            return GradeLetter.Equals("Зачтено", StringComparison.OrdinalIgnoreCase) ||
                   GradeLetter.Equals("Passed", StringComparison.OrdinalIgnoreCase);
        }

        return false;
    }
}
