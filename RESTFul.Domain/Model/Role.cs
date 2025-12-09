namespace RESTFul.Domain.Model;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<string> Permissions { get; set; } = new List<string>();
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }

    // Navigation properties
    public ICollection<User> Users { get; set; } = new List<User>();
}
