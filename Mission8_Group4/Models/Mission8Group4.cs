using Microsoft.EntityFrameworkCore;
using Mission8_Group4.Models;

namespace Mission8_Group4.Models;

public class Mission8Group4 : DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    public Mission8Group4(){} // Used when creating the migration
    public Mission8Group4(DbContextOptions<Mission8Group4> options) : base(options) {} // Used when the app is run
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=mission8_group4.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
            new Category { id = 1, name = "Home" },
            new Category { id = 2, name = "School" },
            new Category { id = 3, name = "Work" },
            new Category { id = 4, name = "Church" }
        );
        modelBuilder.Entity<Task>().HasData(
            new Task { id = 1, categoryId = 1, name = "Crises", quadrant = 1 },
            new Task { id = 2, categoryId = 2, name = "Pressing Problems", quadrant = 1 },
            new Task { id = 3, categoryId = 3, name = "Projects with Deadlines", quadrant = 1 },
            new Task { id = 4, categoryId = 1, name = "Relationship Building", quadrant = 2 },
            new Task { id = 5, categoryId = 2, name = "Planning", quadrant = 2 },
            new Task { id = 6, categoryId = 3, name = "Recreation", quadrant = 2 },
            new Task { id = 7, categoryId = 1, name = "Interruptions", quadrant = 3 },
            new Task { id = 8, categoryId = 2, name = "Some Phone Calls", quadrant = 3 },
            new Task { id = 9, categoryId = 3, name = "Some Mail", quadrant = 3 },
            new Task { id = 10, categoryId = 4, name = "Some Reports", quadrant = 3 },
            new Task { id = 11, categoryId = 1, name = "Busy Work", quadrant = 4 },
            new Task { id = 12, categoryId = 2, name = "Some Phone Calls", quadrant = 4 },
            new Task { id = 13, categoryId = 3, name = "Some Mail", quadrant = 4 },
            new Task { id = 14, categoryId = 4, name = "Time Wasters", quadrant = 4 }
        );
    }
}