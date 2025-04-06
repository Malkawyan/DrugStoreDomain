namespace Application.UseCases.Commands;
using MediatR;

/// <summary>
/// Обновление препарата 
/// </summary>
/// <param name="Name"></param>
/// <param name="Manufacturer"></param>
/// <param name="CountryCodeId"></param>
/// <param name="CountryName"></param>
public record UpdateDrugCommand(string Name, string Manufacturer, string CountryCodeId, string CountryName) : IRequest;