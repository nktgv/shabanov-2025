using Microsoft.EntityFrameworkCore;
using RESTFul.Domain.Entities;

namespace RESTFul.Infrastructure;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    // Core entities
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<Faculty> Faculties { get; set; }

    // Academic entities
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<AcademicPerformance> AcademicPerformances { get; set; }

    // Movement entities
    public DbSet<Enrollment> Enrollments { get; set; }

    // System entities
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureStudentEntity(modelBuilder);
        ConfigureGroupEntity(modelBuilder);
        ConfigureSpecialtyEntity(modelBuilder);
        ConfigureFacultyEntity(modelBuilder);
        ConfigureAcademicPerformanceEntity(modelBuilder);
        ConfigureEnrollmentEntity(modelBuilder);
        ConfigureUserEntity(modelBuilder);
    }

    private void ConfigureStudentEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(s => s.MiddleName)
                .HasMaxLength(100);

            entity.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(s => s.Phone)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(s => s.PassportSeries)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(s => s.PassportNumber)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(s => s.AcademicRecords)
                .WithOne(ar => ar.Student)
                .HasForeignKey(ar => ar.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private void ConfigureGroupEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(g => g.Id);

            entity.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(g => g.Code)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(g => g.Specialty)
                .WithMany(s => s.Groups)
                .HasForeignKey(g => g.SpecialtyId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Curator)
                .WithMany(u => u.CuratedGroups)
                .HasForeignKey(g => g.CuratorId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void ConfigureSpecialtyEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(s => s.Code)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(s => s.Faculty)
                .WithMany(f => f.Specialties)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void ConfigureFacultyEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(f => f.Id);

            entity.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(f => f.ShortName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(f => f.Dean)
                .WithMany()
                .HasForeignKey(f => f.DeanId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(f => f.Staff)
                .WithMany()
                .UsingEntity(j => j.ToTable("FacultyStaff"));
        });
    }

    private void ConfigureAcademicPerformanceEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicPerformance>(entity =>
        {
            entity.HasKey(ap => ap.Id);

            entity.Property(ap => ap.GradeLetter)
                .HasMaxLength(50);

            entity.HasOne(ap => ap.Student)
                .WithMany(s => s.AcademicRecords)
                .HasForeignKey(ap => ap.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ap => ap.Subject)
                .WithMany(s => s.Performances)
                .HasForeignKey(ap => ap.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ap => ap.Teacher)
                .WithMany(u => u.TaughtPerformances)
                .HasForeignKey(ap => ap.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void ConfigureEnrollmentEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.OrderNumber)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Reason)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.Comment)
                .HasMaxLength(1000);

            entity.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private void ConfigureUserEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);

            entity.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.MiddleName)
                .HasMaxLength(100);

            entity.HasMany(u => u.CuratedGroups)
                .WithOne(g => g.Curator)
                .HasForeignKey(g => g.CuratorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(u => u.TaughtPerformances)
                .WithOne(ap => ap.Teacher)
                .HasForeignKey(ap => ap.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
