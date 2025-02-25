using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands;

/// <summary>
/// Обновление Drug
/// </summary>
/// <param name="_drugWriteRepository"></param>
/// <param name="_drugReadRepository"></param>
/// <param name="_countryReadRepository"></param>
public class UpdateDrugCommanHadler(
    IDrugWriteRepository _drugWriteRepository,
    IDrugReadRepository _drugReadRepository,
    ICountryReadRepository _countryReadRepository) : IRequestHandler<UpdateDrugCommand>
{
    /// <summary>
    /// Handle UpdateDrug
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
    {
        var drugs = await _drugReadRepository.SearchDrugsByName(request.Name, cancellationToken);

        if (drugs.Count() <= 0)
        {
            throw new KeyNotFoundException($"Drug {request.Name} does not exist");
        }
        
        var drug = drugs.First();
        
        var countries = await _countryReadRepository.SearchCountriesByNameAsync(request.CountryName, cancellationToken);

        if (countries.Count() <= 0)
        {
            throw new KeyNotFoundException($"Country {request.CountryName} does not exist");
        }
        
        var country = countries.First();
        
        await _drugWriteRepository.UpdateAsync(drug, cancellationToken);
    }
}
