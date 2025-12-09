namespace RESTFul.Domain.Model;

public class Teacher : Person
{
    public int TeacherId { get; set; }
    public string Position { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public string AcademicDegree { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public decimal? Salary { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public Department? Department { get; set; }
    public ICollection<AcademicRecord> AcademicRecords { get; set; } = new List<AcademicRecord>();
    public ICollection<AcademicGroup> CuratedGroups { get; set; } = new List<AcademicGroup>();
    public ICollection<Department> HeadedDepartments { get; set; } = new List<Department>();
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
