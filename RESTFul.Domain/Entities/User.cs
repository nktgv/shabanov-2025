using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public UserRole Role { get; set; }

    // Navigation properties
    public List<Group> CuratedGroups { get; set; } = new();
    public List<AcademicPerformance> TaughtPerformances { get; set; } = new();

    // Methods
    public string GetFullName()
    {
        return MiddleName != null
            ? $"{LastName} {FirstName} {MiddleName}"
            : $"{LastName} {FirstName}";
    }

    public bool HasRole(UserRole role)
    {
        return Role == role;
    }
}
