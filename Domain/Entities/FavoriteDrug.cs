using Ardalis.GuardClauses;
using Domain.Primitives;

namespace Domain.Entities;

/// <summary>
/// Избранный препарат
/// </summary>
public class FavoriteDrug : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="profileId"></param>
    /// <param name="drugId"></param>
    /// <param name="drugStoreId"></param>
    public FavoriteDrug(Guid profileId, Guid drugId, Guid drugStoreId, Profile profile, Drug drug, DrugStore drugStore)
    {
        ProfileId = Guard.Against.Null(profileId, nameof(profileId),ValidationMessage.NullOrWhiteSpaceOrEmpty);
        DrugId = Guard.Against.Null(drugId, nameof(drugId),ValidationMessage.NullOrWhiteSpaceOrEmpty);;
        DrugStoreId = Guard.Against.Null(drugStoreId, nameof(drugStoreId),ValidationMessage.NullOrWhiteSpaceOrEmpty);;

        Profile = Guard.Against.Null(profile, nameof(profile), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        Drug = Guard.Against.Null(drug, nameof(drug), ValidationMessage.NullOrWhiteSpaceOrEmpty); 
        DrugStore = Guard.Against.Null(drugStore, nameof(drugStore), ValidationMessage.NullOrWhiteSpaceOrEmpty);
    }
    /// <summary>
    /// Идентификатор профиля пользователя
    /// </summary>
    public Guid ProfileId { get; private set; }
    
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public Guid DrugId { get; private set; }
    
    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public Guid DrugStoreId { get; private set; }
    
    /// <summary>
    /// Навигационное свойство к профилю пользователя
    /// </summary>
    public Profile Profile { get; private set; }
    
    /// <summary>
    /// Навигационное свойство к препарату
    /// </summary>
    public Drug Drug { get; private set; }
    
    /// <summary>
    /// Навигационное свойство к аптеке
    /// </summary>
    public DrugStore DrugStore { get; private set; }
}