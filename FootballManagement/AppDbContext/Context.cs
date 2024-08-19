using FootballManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballManagement.AppDbContext;

public class Context:DbContext
{
    public DbSet<Team>Teams { get; set; }
    public DbSet<Player>Players { get; set; }
    public DbSet<Game>Games { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=FMS;User Id = sa;Password = DB_Password;Integrated Security = true;Encrypt=False;Trusted_Connection = false ");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>().HasMany(t => t.Players).WithOne(p => p.Team).HasForeignKey(p=>p.TeamId);
        base.OnModelCreating(modelBuilder);
    }
}

