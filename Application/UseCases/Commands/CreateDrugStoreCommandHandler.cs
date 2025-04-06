using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using Domain.Value_Objects;
using MediatR;

namespace Application.UseCases.Commands;

/// <summary>
/// Создание Аптеки
/// </summary>
/// <param name="_drugStoreWriteRepository"></param>
public class CreateDrugStoreCommandHandler (IDrugStoreWriteRepository _drugStoreWriteRepository) : IRequestHandler<CreateDrugStoreCommand, Guid>
{
    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Guid> Handle(CreateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = new DrugStore(request.drugNetwork, request.Number, request.address);

        await _drugStoreWriteRepository.AddAsync(drugStore, cancellationToken);

        return drugStore.Id;
    }
}