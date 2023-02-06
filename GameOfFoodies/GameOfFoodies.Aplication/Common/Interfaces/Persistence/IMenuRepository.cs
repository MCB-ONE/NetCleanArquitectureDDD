using GameOfFoodies.Domain.MenuAggregate;

namespace GameOfFoodies.Aplication.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}