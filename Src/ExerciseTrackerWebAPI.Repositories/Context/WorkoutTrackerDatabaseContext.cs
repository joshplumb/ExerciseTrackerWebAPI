using System;
using System.Collections.Generic;
using ExerciseTrackerWebAPI.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTrackerWebAPI.Repositories.Temp;

public partial class WorkoutTrackerDatabaseContext : DbContext
{
    public WorkoutTrackerDatabaseContext()
    {
    }

    public WorkoutTrackerDatabaseContext(DbContextOptions<WorkoutTrackerDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExerciseModel> Exercises { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       //=> optionsBuilder.UseSqlServer("Server=DESKTOP-SGR7071\\SQLEXPRESS;Database=WorkoutTrackerDatabase;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseModel>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("PK_Workout");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.ExerciseName).HasMaxLength(50);
            entity.Property(e => e.Weight).HasColumnType("numeric(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
