using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3.Skola.Models
{
    public partial class ToftaGymnasiumDbContext : DbContext
    {
        public ToftaGymnasiumDbContext()
        {
        }

        public ToftaGymnasiumDbContext(DbContextOptions<ToftaGymnasiumDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<StaffCourses> StaffCourses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentsCourses> StudentsCourses { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<VWgradeslastMonth> VWgradeslastMonth { get; set; }
        public virtual DbSet<VWstatisticsofGrades> VWstatisticsofGrades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-5M0EIGI; Initial Catalog=ToftaGymnasium; Integrated Security= True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.Property(e => e.ClassId).HasColumnName("Class_Id");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Program)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK_Grades");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.StaffId).HasColumnName("Staff_Id");

                entity.Property(e => e.StudentId).HasColumnName("Student_Id");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_Id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Courses_Subject");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.DateofEmployment).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StaffCourses>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StaffCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffCourses_Courses");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.StaffCourses)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffCourses_Staff");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalNr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Classes");
            });

            modelBuilder.Entity<StudentsCourses>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentsCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsCourses_Courses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsCourses_Students1");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Subject1)
                    .IsRequired()
                    .HasColumnName("Subject")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradeslastMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradeslastMonth");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWstatisticsofGrades>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWStatisticsofGrades");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
