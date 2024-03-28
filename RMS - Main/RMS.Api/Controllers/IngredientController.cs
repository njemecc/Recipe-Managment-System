using Microsoft.AspNetCore.Mvc;
using RMS.Application.Ingredients.queries;

namespace RMS.Api.Controllers;

public class IngredientController : ApiBaseController
{

    [HttpGet]
    public async Task<IActionResult> GetIngredientsByUserId([FromQuery] IngredientsGetByRecipeIdCommand command) => Ok(await Mediator.Send(command));

}