namespace Domain.Entities;
/// <summary>
/// Профиль пользователя
/// </summary>
public class Profile : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userId"></param>
    public Profile(Guid userId)
    {
        UserId = userId;
    }
    
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid UserId { get; private set; }
}