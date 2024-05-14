using MediatR;
using RMS.Application.Common.Dto.Ingredient;

namespace RMS.Application.Ingredients.commands;

public record IngredientCreateCommand(IngredientCreateDto Ingredient) : IRequest<IngredientDetailsDto>;

