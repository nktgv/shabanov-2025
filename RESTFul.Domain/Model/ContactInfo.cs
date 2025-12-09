using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Model;

public class ContactInfo
{
    public int ContactId { get; set; }
    public int PersonId { get; set; }
    public ContactType ContactType { get; set; }
    public string ContactValue { get; set; } = string.Empty;
    public bool IsPrimary { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedDate { get; set; }

    // Navigation properties
    public Person? Person { get; set; }
}
