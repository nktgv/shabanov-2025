namespace RESTFul.Domain.Model;

public class PersonalDocument
{
    public int DocumentId { get; set; }
    public int PersonId { get; set; }
    public int DocumentTypeId { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string SeriesNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string IssuedBy { get; set; } = string.Empty;

    // Navigation properties
    public Person? Person { get; set; }
    public DocumentType? DocumentType { get; set; }
}
