namespace Domain.Entities;

/// <summary>
/// Избранный препарат
/// </summary>
public class FavoriteDrug : BaseEntity
{

    public FavoriteDrug(Guid profileId, Guid drugId, Guid drugStoreId)
    {
        ProfileId = profileId;
        DrugId = drugId;
        DrugStoreId = drugStoreId;
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