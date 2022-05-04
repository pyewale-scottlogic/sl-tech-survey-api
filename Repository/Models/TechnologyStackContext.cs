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
        public virtual DbSet<ProjectTechStack> ProjectTechStacks { get; set; } = null!;
        public virtual DbSet<Survey> Surveys { get; set; } = null!;
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

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Project__Company__44952D46");
            });

            modelBuilder.Entity<ProjectOwner>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProjectOwner");

                entity.HasIndex(e => new { e.ProjectSurveyId, e.AccountOwnerId, e.TechLeadId }, "UQ_surveyEmp")
                    .IsUnique()
                    .IsClustered();

                entity.HasOne(d => d.AccountOwner)
                    .WithMany()
                    .HasForeignKey(d => d.AccountOwnerId)
                    .HasConstraintName("FK__ProjectOw__Accou__603D47BB");

                entity.HasOne(d => d.ProjectSurvey)
                    .WithMany()
                    .HasForeignKey(d => d.ProjectSurveyId)
                    .HasConstraintName("FK__ProjectOw__Proje__5F492382");

                entity.HasOne(d => d.TechLead)
                    .WithMany()
                    .HasForeignKey(d => d.TechLeadId)
                    .HasConstraintName("FK__ProjectOw__TechL__61316BF4");
            });

            modelBuilder.Entity<ProjectSurvey>(entity =>
            {
                entity.ToTable("ProjectSurvey");

                entity.HasIndex(e => e.PlatformId, "IX_ProjectSurvey_PlatformId");

                entity.HasIndex(e => e.ProjectId, "IX_ProjectSurvey_ProjectId");

                entity.HasIndex(e => e.SurveyId, "IX_ProjectSurvey_SurveyId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SurveyDate).HasColumnType("date");

                entity.HasOne(d => d.Platform)
                    .WithMany(p => p.ProjectSurveys)
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectSu__Platf__51EF2864");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectSurveys)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectSu__Proje__5006DFF2");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.ProjectSurveys)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectSu__Surve__50FB042B");
            });

            modelBuilder.Entity<ProjectTechStack>(entity =>
            {
                entity.ToTable("ProjectTechStack");

                entity.HasIndex(e => e.ProjectSurveyId, "IX_ProjectTechStack_ProjectSurveyId");

                entity.HasIndex(e => e.TechnologyId, "IX_ProjectTechStack_TechnologyId");

                entity.HasOne(d => d.ProjectSurvey)
                    .WithMany(p => p.ProjectTechStacks)
                    .HasForeignKey(d => d.ProjectSurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectTe__Proje__59904A2C");

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.ProjectTechStacks)
                    .HasForeignKey(d => d.TechnologyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectTe__Techn__5A846E65");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.HasIndex(e => new { e.Quarter, e.Year }, "UQ_surveyYear")
                    .IsUnique();

                entity.Property(e => e.SurveyId).ValueGeneratedNever();

                entity.Property(e => e.Year).HasMaxLength(4);
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
