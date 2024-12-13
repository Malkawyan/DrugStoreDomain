namespace Domain.Primitives;
/// <summary>
/// Сообщения для валидации
/// </summary>
public static class ValidationMessage
{
    /// <summary>
    /// Сообщение о неверной длине (два параметра)
    /// </summary>
    public const string LenghtMessage = 
        "Поле  {PropertyName} должно содержать от {MinLength} до {MaxLength} символов.";

    /// <summary>
    /// Сообщение о неверной длине (один параметр)
    /// </summary>
    public const string LengthMessageSingle = 
        "Поле {PropertyName} должно содержать ровно {Length} символов.";
    
    /// <summary>
    /// Сообщение о неверный символах
    /// </summary>
    public const string MessageSymbols = 
        "Поле {PropertyName} должно содержать только символы: {Pattern} ";

    /// <summary>
    /// Сообщение о недопустимости символов
    /// </summary>
    public const string MessageNoSymbols =
        "Поле {PropertyName} не должно содержать символы : {Pattern}";
    
    /// <summary>
    /// Два символа после запятой
    /// </summary>
    public const string CostTooManyDecimalPlaces = 
        "Поле {PropertyName} должно содержать не более двух знаков после запятой.";

    /// <summary>
    /// Проверка на целое число
    /// </summary>
    public const string IntCheck =
        "Поле {PropertyName} должно быть целым числом";

    /// <summary>
    /// Не более 10000 в поле Count
    /// </summary>
    public const string MaxValueMessage =
        "Значение поля {PropertyName} не должно превышать 10000";

    /// <summary>
    /// Проверка на пустое поле
    /// </summary>
    public const string NullOrWhiteSpaceOrEmpty =
        "Поле {PropertyName} не может быть пустым";

    /// <summary>
    /// Проверка на отрицательные числа и 0
    /// </summary>
    public const string NegativeOrZero =
        "Поле {PropertyName}  не может принимать отрицательные числа и 0";

    /// <summary>
    /// Проверка на действующий ISO
    /// </summary>
    public const string Iso =
        "Поле {PropertyName} должно содержать действующий ISO - код страны";
}