namespace RESTFul.Domain.Model;

public class Report
{
    public int ReportId { get; set; }
    public string ReportName { get; set; } = string.Empty;
    public int TemplateId { get; set; }
    public int GeneratedBy { get; set; }
    public DateTime GenerationDate { get; set; }
    public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
    public string FilePath { get; set; } = string.Empty;
    public long? FileSize { get; set; }

    // Navigation properties
    public User? Generator { get; set; }
}
