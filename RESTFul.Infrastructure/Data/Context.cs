namespace RESTFul.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RESTFul.Domain.Model;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    // Person and derived entities
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    // Organizational entities
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<AcademicGroup> AcademicGroups { get; set; }
    public DbSet<Specialization> Specializations { get; set; }

    // Academic entities
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<AcademicRecord> AcademicRecords { get; set; }
    public DbSet<Grade> Grades { get; set; }

    // Student movement entities
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<StudentMovement> StudentMovements { get; set; }
    public DbSet<Order> Orders { get; set; }

    // Document and address entities
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<PersonalDocument> PersonalDocuments { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ContactInfo> ContactInfos { get; set; }

    // System entities
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigurePersonEntities(modelBuilder);
        ConfigureOrganizationalEntities(modelBuilder);
        ConfigureAcademicEntities(modelBuilder);
        ConfigureStudentMovementEntities(modelBuilder);
        ConfigureDocumentEntities(modelBuilder);
        ConfigureSystemEntities(modelBuilder);
    }

    private void ConfigurePersonEntities(ModelBuilder modelBuilder)
    {
        // Configure TPH (Table-Per-Hierarchy) for Person
        modelBuilder.Entity<Person>()
            .HasDiscriminator<string>("PersonType")
            .HasValue<Student>("Student")
            .HasValue<Teacher>("Teacher");

        // Student configuration
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Group)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // Teacher configuration
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Department)
            .WithMany(d => d.Teachers)
            .HasForeignKey(t => t.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private void ConfigureOrganizationalEntities(ModelBuilder modelBuilder)
    {
        // Faculty configuration
        modelBuilder.Entity<Faculty>()
            .HasOne(f => f.Decan)
            .WithMany()
            .HasForeignKey(f => f.DecanId)
            .OnDelete(DeleteBehavior.Restrict);

        // Department configuration
        modelBuilder.Entity<Department>()
            .HasOne(d => d.Faculty)
            .WithMany(f => f.Departments)
            .HasForeignKey(d => d.FacultyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Department>()
            .HasOne(d => d.HeadTeacher)
            .WithMany(t => t.HeadedDepartments)
            .HasForeignKey(d => d.HeadTeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        // AcademicGroup configuration
        modelBuilder.Entity<AcademicGroup>()
            .HasOne(g => g.Department)
            .WithMany(d => d.AcademicGroups)
            .HasForeignKey(g => g.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AcademicGroup>()
            .HasOne(g => g.Specialization)
            .WithMany(s => s.AcademicGroups)
            .HasForeignKey(g => g.SpecializationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AcademicGroup>()
            .HasOne(g => g.Curator)
            .WithMany(t => t.CuratedGroups)
            .HasForeignKey(g => g.CuratorId)
            .OnDelete(DeleteBehavior.SetNull);

        // Specialization configuration
        modelBuilder.Entity<Specialization>()
            .HasOne(s => s.Department)
            .WithMany(d => d.Specializations)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private void ConfigureAcademicEntities(ModelBuilder modelBuilder)
    {
        // AcademicRecord configuration
        modelBuilder.Entity<AcademicRecord>()
            .HasOne(ar => ar.Student)
            .WithMany(s => s.AcademicRecords)
            .HasForeignKey(ar => ar.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AcademicRecord>()
            .HasOne(ar => ar.Subject)
            .WithMany(s => s.AcademicRecords)
            .HasForeignKey(ar => ar.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AcademicRecord>()
            .HasOne(ar => ar.Teacher)
            .WithMany(t => t.AcademicRecords)
            .HasForeignKey(ar => ar.TeacherId)
            .OnDelete(DeleteBehavior.SetNull);

        // Grade configuration
        modelBuilder.Entity<Grade>()
            .HasOne(g => g.AcademicRecord)
            .WithMany(ar => ar.Grades)
            .HasForeignKey(g => g.RecordId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Teacher)
            .WithMany(t => t.Grades)
            .HasForeignKey(g => g.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private void ConfigureStudentMovementEntities(ModelBuilder modelBuilder)
    {
        // Enrollment configuration
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Order)
            .WithMany(o => o.Enrollments)
            .HasForeignKey(e => e.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        // StudentMovement configuration
        modelBuilder.Entity<StudentMovement>()
            .HasOne(sm => sm.Student)
            .WithMany(s => s.Movements)
            .HasForeignKey(sm => sm.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StudentMovement>()
            .HasOne(sm => sm.FromGroup)
            .WithMany()
            .HasForeignKey(sm => sm.FromGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StudentMovement>()
            .HasOne(sm => sm.ToGroup)
            .WithMany()
            .HasForeignKey(sm => sm.ToGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StudentMovement>()
            .HasOne(sm => sm.Order)
            .WithMany(o => o.StudentMovements)
            .HasForeignKey(sm => sm.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Order configuration
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Creator)
            .WithMany(u => u.CreatedOrders)
            .HasForeignKey(o => o.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Approver)
            .WithMany(u => u.ApprovedOrders)
            .HasForeignKey(o => o.ApprovedBy)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private void ConfigureDocumentEntities(ModelBuilder modelBuilder)
    {
        // PersonalDocument configuration
        modelBuilder.Entity<PersonalDocument>()
            .HasOne(pd => pd.Person)
            .WithMany(p => p.Documents)
            .HasForeignKey(pd => pd.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PersonalDocument>()
            .HasOne(pd => pd.DocumentType)
            .WithMany(dt => dt.PersonalDocuments)
            .HasForeignKey(pd => pd.DocumentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Address configuration
        modelBuilder.Entity<Address>()
            .HasOne(a => a.Person)
            .WithMany(p => p.Addresses)
            .HasForeignKey(a => a.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        // ContactInfo configuration
        modelBuilder.Entity<ContactInfo>()
            .HasOne(ci => ci.Person)
            .WithMany(p => p.Contacts)
            .HasForeignKey(ci => ci.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureSystemEntities(ModelBuilder modelBuilder)
    {
        // User configuration
        modelBuilder.Entity<User>()
            .HasOne(u => u.Person)
            .WithMany()
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity(j => j.ToTable("UserRoles"));

        // Report configuration
        modelBuilder.Entity<Report>()
            .HasOne(r => r.Generator)
            .WithMany(u => u.GeneratedReports)
            .HasForeignKey(r => r.GeneratedBy)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure JSON columns
        modelBuilder.Entity<Role>()
            .Property(r => r.Permissions)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

        modelBuilder.Entity<Report>()
            .Property(r => r.Parameters)
            .HasConversion(
                v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions)null),
                v => System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(v, (System.Text.Json.JsonSerializerOptions)null) ?? new Dictionary<string, object>()
            );
    }
}
