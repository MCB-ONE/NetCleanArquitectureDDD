using GameOfFoodies.Domain.Common.Models;

namespace GameOfFoodies.Domain.Common.ValueObjects;

public class Puntuacion : ValueObject
{
    public Puntuacion(double valor)
    {
        Valor = valor;
    }

    public double Valor { get; private set; }

    public static Puntuacion CreateNew(double puntuacion = 0)
    {
        return new Puntuacion(puntuacion);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Valor;
    }
}