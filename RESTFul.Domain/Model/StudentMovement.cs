using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Model;

public class StudentMovement
{
    public int MovementId { get; set; }
    public int StudentId { get; set; }
    public MovementType MovementType { get; set; }
    public DateTime MovementDate { get; set; }
    public int? FromGroupId { get; set; }
    public int? ToGroupId { get; set; }
    public int OrderId { get; set; }
    public string Reason { get; set; } = string.Empty;
    public bool IsApproved { get; set; }

    // Navigation properties
    public Student? Student { get; set; }
    public AcademicGroup? FromGroup { get; set; }
    public AcademicGroup? ToGroup { get; set; }
    public Order? Order { get; set; }
}
