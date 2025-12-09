using RESTFul.Domain.Enums;

namespace RESTFul.Domain.Model;

public class Student : Person
{
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public int AdmissionYear { get; set; }
    public StudentStatus Status { get; set; }
    public StudyForm StudyForm { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public DateTime? GraduationDate { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public AcademicGroup? Group { get; set; }
    public ICollection<AcademicRecord> AcademicRecords { get; set; } = new List<AcademicRecord>();
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<StudentMovement> Movements { get; set; } = new List<StudentMovement>();
}
