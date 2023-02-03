namespace GameOfFoodies.Domain.Common.Models;

// Clase base que han de heredar todos los value objects (objetos de valor) de nuestro proyecto
// => Regla DDD: dos value object son iguales si tienen los mismos valores 
public abstract class ValueObject: IEquatable<ValueObject>
{
    // Método que han de implementar todos los value objects (por contrato, ya que es abstracto)
    // => devuelve las propiedades del objeto en un orden definido
    public abstract IEnumerable<object> GetEqualityComponents();


    // Sobreescribimos el método Equals() de la clase object para comparar la igualdad de nuestros Value objects siuiendo la regla 
    public override bool Equals(object? obj)
    {
        // Nos aseguramos de que ambos objetos son del mismo tipo
        if(obj is null || obj.GetType() != GetType()){
            return false;
        }

        // Castemos a un ValueObject el objeto a comparar 
        var valueObject = (ValueObject)obj;

        // Dado que el objeto a comparar ahora es un ValueObject podemos llamar a su propio método GetEqualityComponents()
        // => Lo útilizamos para verificar que los valores de las propiedades de ambos objetos son iguales 
        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }


    // Anulamos los operadores == y != de la clase object para reescribirlos según nuestra regla de igualdad.
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return Equals(left, right);
    }

        public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !Equals(left, right);
    }

    // Anulamos el método getHashCode de la clase object dado que queremos dos objetos de valor con los mismos valores en sus propiedades pero también que devuelvan el mismo HashCode
    public override int GetHashCode()
    {
        //
        return GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x^y);
    }

    public bool Equals(ValueObject? other)
    {
        return Equals((object?)other);
    }
}