using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Entities;

public class Specialty
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public Guid FacultyId { get; set; }
    public int DurationYears { get; set; }
    public EducationLevel Level { get; set; }

    // Navigation properties
    public Faculty Faculty { get; set; } = null!;
    public List<Group> Groups { get; set; } = new();

    // Methods
    public string GetFullName()
    {
        return $"{Code} - {Name}";
    }
}
