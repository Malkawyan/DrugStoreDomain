using Ardalis.GuardClauses;
using Domain.Primitives;

namespace Domain.Entities;
/// <summary>
/// Профиль пользователя
/// </summary>
public class Profile : BaseEntity<Profile>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userId"></param>
    public Profile(Guid userId)
    {
        UserId = Guard.Against.NullOrEmpty(userId, nameof(userId), ValidationMessage.NullOrWhiteSpaceOrEmpty);
    }
    
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid UserId { get; private set; }
}