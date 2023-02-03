using GameOfFoodies.Domain.Common.Models;

namespace GameOfFoodies.Domain.Common.ValueObjects;

public sealed class PuntuacionMedia : ValueObject
{
    public PuntuacionMedia(double valor, int numPuntuaciones)
    {
        Valor = valor;
        NumPuntuaciones = numPuntuaciones;
    }

    public double Valor {get; private set;}
    public int NumPuntuaciones {get; private set;}

    public static PuntuacionMedia CreateNew(double puntuacion = 0, int numPuntuaciones = 0)
    {
        return new PuntuacionMedia(puntuacion, numPuntuaciones);
    }

    public void AddNewPuntuacion(Puntuacion puntuacion)
    {
        Valor = ((Valor * NumPuntuaciones) + puntuacion.Valor) / ++NumPuntuaciones;
    }

    public void RemovePuntuacion(Puntuacion puntuacion)
    {
        Valor = ((Valor * NumPuntuaciones) - puntuacion.Valor) / ++NumPuntuaciones;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Valor;
    }
}