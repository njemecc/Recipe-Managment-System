using MediatR;
using RMS.Application.Common.Dto.Category;

namespace RMS.Application.Categories.commands;

public record CategoryCreateCommand(CategoryCreateDto Category) : IRequest<CategoryDetailsDto>;