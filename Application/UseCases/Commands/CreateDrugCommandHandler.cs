using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands;

/// <summary>
/// Создание Drug 
/// </summary>
/// <param name="_drugReadRepository"></param>
/// <param name="countryReadRepository"></param>
public class CreateDrugCommandHandler (IDrugWriteRepository _drugWriteRepository, ICountryReadRepository countryReadRepository) : IRequestHandler<CreateDrugCommand, Guid>
{
    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<Guid> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
    {
        var countries = await countryReadRepository.SearchCountriesByNameAsync(request.CountryName, cancellationToken);

        if (countries.Count() <= 0)
        {
            throw new KeyNotFoundException($"Country {request.CountryName} does not exist");
        }

        var drug = new Drug(request.Name, request.Manufacturer, countries.First().Code, countries.First(), null);

        await _drugWriteRepository.AddAsync(drug, cancellationToken);

        return drug.Id;
    }
}