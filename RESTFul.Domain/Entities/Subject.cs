namespace RESTFul.Domain.Entities;

public class Subject
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int Credits { get; set; }

    // Navigation properties
    public List<AcademicPerformance> Performances { get; set; } = new();
}
