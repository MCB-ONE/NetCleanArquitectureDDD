using GameOfFoodies.Aplication.Common.Interfaces.Persistence;
using GameOfFoodies.Domain.MenuAggregate;

namespace GameOfFoodies.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly GameOfFoodiesDbContext _dbContext;

    public MenuRepository(GameOfFoodiesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);

        _dbContext.SaveChanges();
    }
}