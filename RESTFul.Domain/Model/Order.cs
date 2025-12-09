using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Model;

public class Order
{
    public int OrderId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public OrderType OrderType { get; set; }
    public DateTime OrderDate { get; set; }
    public int CreatedBy { get; set; }
    public int? ApprovedBy { get; set; }
    public OrderStatus Status { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime EffectiveDate { get; set; }

    // Navigation properties
    public User? Creator { get; set; }
    public User? Approver { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<StudentMovement> StudentMovements { get; set; } = new List<StudentMovement>();
}
