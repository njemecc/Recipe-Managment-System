using MediatR;
using RMS.Application.Common.Dto.Ingredient;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Mappers;
using RMS.Domain.Entities;

namespace RMS.Application.Ingredients.commands
{
    public class IngredientCreateCommandHandler(IPostgresDbContext dbContext) : IRequestHandler<IngredientCreateCommand, IngredientDetailsDto>
    {
        public async Task<IngredientDetailsDto> Handle(IngredientCreateCommand request, CancellationToken cancellationToken)
        {
            var newIngredient = await dbContext.Ingredients.AddAsync(new Ingredient(request.Ingredient.Name));

            
            await dbContext.SaveChangesAsync(CancellationToken.None);

            return newIngredient.Entity.FromEntityToIngredientDetailsDto();

        }
    }
}

