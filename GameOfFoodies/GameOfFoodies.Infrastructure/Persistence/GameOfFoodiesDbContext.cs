using GameOfFoodies.Domain.MenuAggregate;

using Microsoft.EntityFrameworkCore;

namespace GameOfFoodies.Infrastructure.Persistence;

public class GameOfFoodiesDbContext : DbContext
{
    public GameOfFoodiesDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Menu> Menus {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameOfFoodiesDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}