using Domain.Validators;
using Domain.Value_Objects;

namespace Domain.Entities;

public sealed class Profile : BaseEntity<Profile>
{

    /// <summary>
    /// Внешний идентификатор.
    /// </summary>
    public string ExternalId { get; private init; }


    // Навигационное свойство для связи с FavoriteDrug.
    public List<FavoriteDrug> FavoriteDrugs { get; private set; } = [];
}