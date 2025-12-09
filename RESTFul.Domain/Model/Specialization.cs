using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Model;

public class Specialization
{
    public int SpecializationId { get; set; }
    public string SpecializationName { get; set; } = string.Empty;
    public string SpecializationCode { get; set; } = string.Empty;
    public DegreeType DegreeType { get; set; }
    public int Duration { get; set; }
    public int Credits { get; set; }
    public int DepartmentId { get; set; }

    // Navigation properties
    public Department? Department { get; set; }
    public ICollection<AcademicGroup> AcademicGroups { get; set; } = new List<AcademicGroup>();
}
