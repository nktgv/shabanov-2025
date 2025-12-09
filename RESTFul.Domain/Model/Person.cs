using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Model;

public abstract class Person
{
    public int PersonId { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    // Navigation properties
    public ICollection<PersonalDocument> Documents { get; set; } = new List<PersonalDocument>();
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<ContactInfo> Contacts { get; set; } = new List<ContactInfo>();
}
