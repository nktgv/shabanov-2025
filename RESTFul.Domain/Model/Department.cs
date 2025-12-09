namespace RESTFul.Domain.Model;

public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public string DepartmentCode { get; set; } = string.Empty;
    public int FacultyId { get; set; }
    public int HeadTeacherId { get; set; }
    public DateTime EstablishmentDate { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public Faculty? Faculty { get; set; }
    public Teacher? HeadTeacher { get; set; }
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    public ICollection<AcademicGroup> AcademicGroups { get; set; } = new List<AcademicGroup>();
    public ICollection<Specialization> Specializations { get; set; } = new List<Specialization>();
}
