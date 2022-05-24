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
                entity.HasKey(e => new { e.ProjectSurveyId, e.AccountOwnerId, e.TechLeadId })
                    .HasName("PK_ProjectSurveyOwner")
                    .IsClustered(false);

                entity.ToTable("ProjectOwner");

                entity.HasIndex(e => new { e.ProjectSurveyId, e.AccountOwnerId, e.TechLeadId }, "UQ_surveyEmp")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ProjectOwnerId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.AccountOwner)
                    .WithMany(p => p.ProjectOwnerAccountOwners)
                    .HasForeignKey(d => d.AccountOwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectOw__Accou__5772F790");

                entity.HasOne(d => d.ProjectSurvey)
                    .WithMany(p => p.ProjectOwners)
                    .HasForeignKey(d => d.ProjectSurveyId)
                    .HasConstraintName("FK__ProjectOw__Proje__567ED357");

                entity.HasOne(d => d.TechLead)
                    .WithMany(p => p.ProjectOwnerTechLeads)
                    .HasForeignKey(d => d.TechLeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectOw__TechL__58671BC9");
            });

            modelBuilder.Entity<ProjectSurvey>(entity =>
            {
                entity.ToTable("ProjectSurvey");

                entity.Property(e => e.SurveyDate).HasColumnType("date");

                entity.HasOne(d => d.Platform)
                    .WithMany(p => p.ProjectSurveys)
                    .HasForeignKey(d => d.PlatformId)
                    .HasConstraintName("FK__ProjectSu__Platf__1E3A7A34");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectSurveys)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__ProjectSu__Proje__1D4655FB");

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
