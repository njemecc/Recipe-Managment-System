using RMS.Domain.Entities;

namespace RMS.Application.Common.Dto.Recipe;


//dodati kasnije i listu ingrediants
public record RecipeDetailsDto(string Title, string Instruction, string UserName, string CategoryName);