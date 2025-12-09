using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Model;

public class Enrollment
{
    public int EnrollmentId { get; set; }
    public int StudentId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public EnrollmentType EnrollmentType { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public int OrderId { get; set; }
    public string EnrollmentBasis { get; set; } = string.Empty;
    public bool IsValid { get; set; }

    // Navigation properties
    public Student? Student { get; set; }
    public Order? Order { get; set; }
}
