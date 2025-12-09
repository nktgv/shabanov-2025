using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Model;

public class AcademicGroup
{
    public int GroupId { get; set; }
    public string GroupNumber { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public int SpecializationId { get; set; }
    public int Course { get; set; }
    public int StudyYear { get; set; }
    public StudyForm FormOfStudy { get; set; }
    public int StudentsCount { get; set; }
    public int? CuratorId { get; set; }

    // Navigation properties
    public Department? Department { get; set; }
    public Specialization? Specialization { get; set; }
    public Teacher? Curator { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
}
