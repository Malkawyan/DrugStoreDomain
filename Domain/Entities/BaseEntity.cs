using Domain.Interfaces;
﻿using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Domain.Entities;

/// <summary>
/// Базовая сущность
/// </summary>
public abstract class BaseEntity<T> where T : BaseEntity<T>
{
    
    private readonly List<IDomainEvent> _domainEvents = [];
    
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Выполняет валидацию сущности с использованием указанного валидатора.
    /// </summary>
    /// <param name="validator">Валидатор FluentValidator.</param>
    protected void ValidateEntity(AbstractValidator<T> validator)
    {
        var validationResult = validator.Validate((T)this);
        if (validationResult.IsValid)
        {
            return;
        }

        var errorMessages = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
        throw new ValidationException(errorMessages);
    }

    
    /// <summary>
    /// Время создания объекта
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Сравнение идентификаторов
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        /*if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }
        var id = ((BaseEntity)obj).Id;
        return id == Id;*/

        return obj is BaseEntity<T> other && Id == other.Id;
    }

    /// <summary>
    /// Сравнение GetHashCode
    /// Если два объекта равны согласно Equals(), их хэш-коды, возвращаемые GetHashCode(), также должны быть равны.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    /// <summary>
    /// Переопределение ==
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator == (BaseEntity<T> left, BaseEntity<T> right)
    {
        if (left is null || right is null)
        {
            return false;
        }
        
        return left.Equals(right);
    }
    
    /// <summary>
    /// Переопределение !=
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(BaseEntity<T> left, BaseEntity<T> right)
    {
        if (left is null || right is null)
        {
            return false;
        }
        
        return !(left == right);
    }
    
    

    #region Методы доменных событий

    /// <summary>
    /// Возврат списка событий только для чтения
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.AsReadOnly();
    }

    /// <summary>
    /// Очищение domainEvent
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    /// <summary>
    /// Добавление DomainEvent
    /// </summary>
    /// <param name="domainEvent"></param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    #endregion
}