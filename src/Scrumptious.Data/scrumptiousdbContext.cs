using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Scrumptious.Data
{
    public partial class scrumptiousdbContext : DbContext
    {
        public scrumptiousdbContext()
        {
        }

        public scrumptiousdbContext(DbContextOptions<scrumptiousdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Backlog> Backlog { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Sprint> Sprint { get; set; }
        public virtual DbSet<Step> Step { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:scrumptious.database.windows.net,1433;Initial Catalog=scrumptiousdb;Persist Security Info=False;User ID=sqladmin;Password=Admin123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backlog>(entity =>
            {
                entity.Property(e => e.FkSprintId).HasColumnName("fk_SprintId");

                entity.HasOne(d => d.FkSprint)
                    .WithMany(p => p.Backlog)
                    .HasForeignKey(d => d.FkSprintId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SprintId");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectDescription)
                    .IsRequired()
                    .HasColumnName("Project_Description")
                    .HasColumnType("text");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("Project_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.ProjectRequirements)
                    .IsRequired()
                    .HasColumnName("Project_Requirements")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Sprint>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.FkProjectId).HasColumnName("fk_ProjectId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SprintDescription)
                    .IsRequired()
                    .HasColumnName("Sprint_Description")
                    .HasColumnType("text");

                entity.Property(e => e.StartDate).HasColumnType("datetime2(0)");

                entity.HasOne(d => d.FkProject)
                    .WithMany(p => p.Sprint)
                    .HasForeignKey(d => d.FkProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProjectId");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.Property(e => e.FkTaskId).HasColumnName("fk_TaskId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StepDescription)
                    .IsRequired()
                    .HasColumnName("Step_Description")
                    .HasColumnType("text");

                entity.HasOne(d => d.FkTask)
                    .WithMany(p => p.Step)
                    .HasForeignKey(d => d.FkTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Step_TaskId");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.FkBacklogId).HasColumnName("fk_BacklogId");

                entity.Property(e => e.FkUserId).HasColumnName("fk_UserId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TaskDescription)
                    .IsRequired()
                    .HasColumnName("Task_Description")
                    .HasColumnType("text");

                entity.HasOne(d => d.FkBacklog)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.FkBacklogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_BacklogId");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
