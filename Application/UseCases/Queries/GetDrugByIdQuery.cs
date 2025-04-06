using MediatR;
using Domain.Entities;

namespace Application.UseCases.Queries;

/// <summary>
/// Запись выбора Drug по ID
/// </summary>
/// <param name="Id"></param>
public record GetDrugByIdQuery(Guid Id) : IRequest<Drug>;
