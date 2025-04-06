using MediatR;
using Domain.Value_Objects;

namespace Application.UseCases.Commands;

/// <summary>
/// Запись обновления аптеки
/// </summary>
public record UpdateDrugStoreCommand(string drugNetwork, int number, Address address) : IRequest;