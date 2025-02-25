using MediatR;
namespace Application.UseCases.Commands;

/// <summary>
/// Запись создания Drug
/// </summary>
/// <param name="Name"></param>
/// <param name="Manufacturer"></param>
/// <param name="CountryName"></param>
public record CreateDrugCommand(string Name, string Manufacturer, string CountryCodeId, string CountryName) : IRequest<Guid>;
