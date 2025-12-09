namespace RESTFul.Domain.Model;

public class Faculty
{
    public int FacultyId { get; set; }
    public string FacultyName { get; set; } = string.Empty;
    public string FacultyCode { get; set; } = string.Empty;
    public int DecanId { get; set; }
    public DateTime EstablishmentDate { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public Teacher? Decan { get; set; }
    public ICollection<Department> Departments { get; set; } = new List<Department>();
}
