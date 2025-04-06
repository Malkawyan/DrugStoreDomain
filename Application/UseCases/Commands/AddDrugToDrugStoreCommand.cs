using MediatR;

namespace Application.UseCases.Commands;

/// <summary>
/// Запись добавление препарата в аптеку
/// </summary>
public record AddDrugToDrugStoreCommand(Guid drugId, Guid drugStoreId, decimal cost, double count) : IRequest;