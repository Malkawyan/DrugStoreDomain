using Domain.Value_Objects;
using MediatR;

namespace Application.UseCases.Commands;

/// <summary>
/// Запись создания аптеки
/// </summary>
/// <param name="drugNetwork"></param>
/// <param name="Number"></param>
/// <param name="address"></param>
public record CreateDrugStoreCommand(string drugNetwork, int Number, Address address) : IRequest<Guid>;