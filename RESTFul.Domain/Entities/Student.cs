using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PassportSeries { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public StudentStatus Status { get; set; }
    public Guid GroupId { get; set; }

    // Navigation properties
    public Group Group { get; set; } = null!;
    public List<Enrollment> Enrollments { get; set; } = new();
    public List<AcademicPerformance> AcademicRecords { get; set; } = new();

    // Methods
    public string GetFullName()
    {
        return MiddleName != null
            ? $"{LastName} {FirstName} {MiddleName}"
            : $"{LastName} {FirstName}";
    }

    public int GetAge()
    {
        var today = DateTime.Today;
        var age = today.Year - BirthDate.Year;
        if (BirthDate.Date > today.AddYears(-age))
        {
            age--;
        }
        return age;
    }

    public bool IsActive()
    {
        return Status == StudentStatus.Active;
    }
}
