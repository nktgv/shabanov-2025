namespace RESTFul.Domain.Model;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public int? PersonId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public bool IsActive { get; set; }
    public int FailedLoginAttempts { get; set; }

    // Navigation properties
    public Person? Person { get; set; }
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    public ICollection<Report> GeneratedReports { get; set; } = new List<Report>();
    public ICollection<Order> CreatedOrders { get; set; } = new List<Order>();
    public ICollection<Order> ApprovedOrders { get; set; } = new List<Order>();
}
