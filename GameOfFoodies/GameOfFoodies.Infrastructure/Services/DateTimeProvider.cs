using GameOfFoodies.Aplication.Common.Interfaces.Services;  
namespace GameOfFoodies.Infrastructure.Services;

public class DateTimeProvider: IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;

}