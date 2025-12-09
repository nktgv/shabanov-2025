using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Entities;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int Course { get; set; }
    public Guid SpecialtyId { get; set; }
    public EducationForm Form { get; set; }
    public int StartYear { get; set; }
    public Guid CuratorId { get; set; }

    // Navigation properties
    public Specialty Specialty { get; set; } = null!;
    public User Curator { get; set; } = null!;
    public List<Student> Students { get; set; } = new();

    // Methods
    public int GetStudentCount()
    {
        return Students.Count;
    }

    public bool IsActive()
    {
        var currentYear = DateTime.Now.Year;
        var graduationYear = StartYear + (Specialty?.DurationYears ?? 4);
        return currentYear < graduationYear;
    }
}
