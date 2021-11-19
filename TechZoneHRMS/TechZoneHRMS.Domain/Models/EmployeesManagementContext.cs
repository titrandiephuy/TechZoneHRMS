using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TechZoneHRMS.API.Models
{
    public partial class EmployeesManagementContext : DbContext
    {
        public EmployeesManagementContext()
        {
        }

        public EmployeesManagementContext(DbContextOptions<EmployeesManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EducationLevel> EducationLevels { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<InChange> InChanges { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=tcp:techzonehrmsdb.database.windows.net,1433;Initial Catalog=EmployeesManagement;Persist Security Info=False;User ID=techzonehrmsdb;Password=Marphantom081093;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentLocation)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DepartmentPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EducationLevel>(entity =>
            {
                entity.ToTable("EducationLevel");

                entity.Property(e => e.Degree)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Major)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EmployeeAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EmployeeAvatar).IsRequired();

                entity.Property(e => e.EmployeePhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ethnicity)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PlaceOfOrigin)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Depar__4F7CD00D");

                entity.HasOne(d => d.EducationLevel)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EducationLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Educa__5165187F");

                entity.HasOne(d => d.Salary)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SalaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Salar__5070F446");
            });

            modelBuilder.Entity<InChange>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("InChange");

                entity.Property(e => e.EmployeedDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__InChange__Employ__5FB337D6");

                entity.HasOne(d => d.Position)
                    .WithMany()
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK__InChange__Positi__60A75C0F");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.HasKey(e => e.LeaveId)
                    .HasName("PK__Leaves__796DB95904E85C93");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LeaveName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leaves__Employee__6383C8BA");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("Salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
