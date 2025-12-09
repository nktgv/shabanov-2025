using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Entities;

public class Enrollment
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public EnrollmentType Type { get; set; }
    public DateTime Date { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public string Reason { get; set; } = string.Empty;
    public Guid? PreviousGroupId { get; set; }
    public Guid? NewGroupId { get; set; }
    public string? Comment { get; set; }

    // Navigation properties
    public Student Student { get; set; } = null!;
}
