using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using MediatR;

namespace Application.UseCases.Commands;

/// <summary>
/// Обновление DrugStore (аптеки)
/// </summary>
/// <param name="_drugStoreReadRepository"></param>
/// <param name="_drugStoreWriteRepository"></param>
public class UpdateDrugStoreCommandHandler (
    IDrugStoreReadRepository _drugStoreReadRepository, 
    IDrugStoreWriteRepository _drugStoreWriteRepository) : IRequestHandler<UpdateDrugStoreCommand>
{
    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task Handle(UpdateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStores = await _drugStoreReadRepository.SearchDrugStoreByAddress(request.address, cancellationToken);

        if (drugStores.Count() <= 0)
        {
            throw new KeyNotFoundException($"DrugStore {request.address} does not exist");
        }
        
        var drugStore = drugStores.First();
        
        await _drugStoreWriteRepository.UpdateAsync(drugStore, cancellationToken);
    }
}