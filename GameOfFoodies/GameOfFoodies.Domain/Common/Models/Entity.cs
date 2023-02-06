namespace GameOfFoodies.Domain.Common.Models;

// Clase base que han de heredar todos las entities (oentidades) de nuestro proyecto
// => Regla DDD: dos entities son iguales si tienen el mismo Id
public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
{
    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    // Anulamos los operadores == y != de la clase object para reescribirlos según nuestra regla de igualdad.
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

        // Anulamos el método getHashCode de la clase object dado que queremos dos objetos de valor con los mismos valores en sus propiedades pero también que devuelvan el mismo HashCode
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    #pragma warning disable CS8618
    protected Entity()
    {
    }
    #pragma warning disable CS8618
}