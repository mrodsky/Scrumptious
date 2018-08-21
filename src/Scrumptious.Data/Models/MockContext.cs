using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scrumptious.Library.Models;
using Scrumptious.Data.Models;


namespace Scrumptious.Data
{
    public partial class MockContext : DbContext
    {
        public MockContext()
        {
        }

        public MockContext(DbContextOptions<scrumptiousdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Models.Backlog> Backlog { get; set; }
        public virtual DbSet<Models.Project> Project { get; set; }
        public virtual DbSet<Models.Sprint> Sprint { get; set; }
        public virtual DbSet<Models.Step> Step { get; set; }
        public virtual DbSet<Models.Task> Task { get; set; }
        public virtual DbSet<Models.User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MockDBContext");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Backlog>(entity =>
            {
                entity.Property(e => e.FkSprintId).HasColumnName("fk_SprintId");

                entity.HasOne(d => d.FkSprint)
                    .WithMany(p => p.Backlog)
                    .HasForeignKey(d => d.FkSprintId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SprintId");
            });

            modelBuilder.Entity<Models.Project>(entity =>
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

            modelBuilder.Entity<Models.Sprint>(entity =>
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

            modelBuilder.Entity<Models.Step>(entity =>
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

            modelBuilder.Entity<Models.Task>(entity =>
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

            modelBuilder.Entity<Models.User>(entity =>
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
