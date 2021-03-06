using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Models
{
    public partial class TechnologyStackContext : DbContext
    {
        public TechnologyStackContext()
        {
        }

        public TechnologyStackContext(DbContextOptions<TechnologyStackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Platform> Platforms { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectOwner> ProjectOwners { get; set; } = null!;
        public virtual DbSet<ProjectSurvey> ProjectSurveys { get; set; } = null!;
        public virtual DbSet<Technology> Technologies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:sl-technology-stack-db-srv.database.windows.net,1433;Initial Catalog=TechnologyStack;Persist Security Info=False;User ID=tsDbAdmin;Password=PtsDb@999;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.ToTable("Platform");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.KimbleUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("KimbleURL");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Project__Company__1A69E950");
            });

            modelBuilder.Entity<ProjectOwner>(entity =>
            {
                entity.HasKey(e => e.ProjectOwnerId)
                    .HasName("PK__ProjectO__82758B8F1B6E0F73")
                    .IsClustered(false);

                entity.ToTable("ProjectOwner");

                entity.HasIndex(e => new { e.ProjectId, e.AccountOwnerId, e.TechLeadId }, "UQ_surveyEmp")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.HasOne(d => d.AccountOwner)
                    .WithMany(p => p.ProjectOwnerAccountOwners)
                    .HasForeignKey(d => d.AccountOwnerId)
                    .HasConstraintName("FK__ProjectOw__Accou__79C80F94");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectOwners)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ProjectOw__Proje__78D3EB5B");

                entity.HasOne(d => d.TechLead)
                    .WithMany(p => p.ProjectOwnerTechLeads)
                    .HasForeignKey(d => d.TechLeadId)
                    .HasConstraintName("FK__ProjectOw__TechL__7ABC33CD");
            });

            modelBuilder.Entity<ProjectSurvey>(entity =>
            {
                entity.ToTable("ProjectSurvey");

                entity.Property(e => e.SurveyDate).HasColumnType("date");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectSurveys)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__ProjectSu__Proje__1D4655FB");

                entity.HasMany(d => d.Platforms)
                    .WithMany(p => p.ProjectSurveys)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectSurveyPlatform",
                        l => l.HasOne<Platform>().WithMany().HasForeignKey("PlatformId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProjectSu__Platf__6F4A8121"),
                        r => r.HasOne<ProjectSurvey>().WithMany().HasForeignKey("ProjectSurveyId").HasConstraintName("FK__ProjectSu__Proje__6E565CE8"),
                        j =>
                        {
                            j.HasKey("ProjectSurveyId", "PlatformId").IsClustered(false);

                            j.ToTable("ProjectSurveyPlatform");

                            j.HasIndex(new[] { "ProjectSurveyId", "PlatformId" }, "UQ_ProjectSurveyPlatform").IsUnique().IsClustered();
                        });

                entity.HasMany(d => d.Technologies)
                    .WithMany(p => p.ProjectSurveys)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectSurveyTechnology",
                        l => l.HasOne<Technology>().WithMany().HasForeignKey("TechnologyId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProjectSu__Techn__2C88998B"),
                        r => r.HasOne<ProjectSurvey>().WithMany().HasForeignKey("ProjectSurveyId").HasConstraintName("FK__ProjectSu__Proje__2B947552"),
                        j =>
                        {
                            j.HasKey("ProjectSurveyId", "TechnologyId").IsClustered(false);

                            j.ToTable("ProjectSurveyTechnology");

                            j.HasIndex(new[] { "ProjectSurveyId", "TechnologyId" }, "UQ_ProjectSurveyTechnology").IsUnique().IsClustered();
                        });
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.ToTable("Technology");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
