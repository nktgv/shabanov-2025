namespace RESTFul.Domain.Model;

public class DocumentType
{
    public int DocumentTypeId { get; set; }
    public string TypeName { get; set; } = string.Empty;
    public string TypeCode { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public int? ValidityPeriod { get; set; }
    public string Description { get; set; } = string.Empty;

    // Navigation properties
    public ICollection<PersonalDocument> PersonalDocuments { get; set; } = new List<PersonalDocument>();
}
