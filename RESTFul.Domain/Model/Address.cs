using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Model;

public class Address
{
    public int AddressId { get; set; }
    public int PersonId { get; set; }
    public AddressType AddressType { get; set; }
    public string Region { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string House { get; set; } = string.Empty;
    public string Apartment { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;

    // Navigation properties
    public Person? Person { get; set; }
}
