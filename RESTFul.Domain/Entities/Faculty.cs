namespace RESTFul.Domain.Entities;

public class Faculty
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public Guid DeanId { get; set; }

    // Navigation properties
    public User Dean { get; set; } = null!;
    public List<Specialty> Specialties { get; set; } = new();
    public List<User> Staff { get; set; } = new();

    // Methods
    public int GetSpecialtyCount()
    {
        return Specialties.Count;
    }

    public int GetStudentCount()
    {
        return Specialties
            .SelectMany(s => s.Groups)
            .SelectMany(g => g.Students)
            .Count();
    }
}
