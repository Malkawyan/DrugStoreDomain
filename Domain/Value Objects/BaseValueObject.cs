namespace Domain.Value_Objects;

/// <summary>
/// Базовый объект-значение
/// </summary>
public class BaseValueObject
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Сравнение
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is BaseValueObject other && Name == other.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}