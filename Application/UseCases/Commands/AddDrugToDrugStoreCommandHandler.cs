using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands;

/// <summary>
/// Добавление препарата в аптеку
/// </summary>
/// <param name="_drugStoreReadRepository"></param>
/// <param name="_drugItemWriteRepository"></param>
public class AddDrugToDrugStoreCommandHandler (
    IDrugStoreReadRepository _drugStoreReadRepository, 
    IDrugItemWriteRepository _drugItemWriteRepository) : IRequestHandler<AddDrugToDrugStoreCommand>
{
    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="requset"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task Handle(AddDrugToDrugStoreCommand requset, CancellationToken cancellationToken)
    {
        var drugStore = await _drugStoreReadRepository.GetByIdAsync(requset.drugStoreId, cancellationToken);
        if (drugStore == null)
        {
            throw new KeyNotFoundException($"DrugStore with ID {requset.drugStoreId} not found.");
        }

        var drugItem = new DrugItem(requset.drugId, requset.drugStoreId, requset.cost, requset.count);
        
        await _drugItemWriteRepository.AddAsync(drugItem, cancellationToken);
    } 
}