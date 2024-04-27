using Microsoft.AspNetCore.Mvc;
using RMS.Application.Ingredients.commands;
using RMS.Application.Ingredients.queries;

namespace RMS.Api.Controllers;

public class IngredientController : ApiBaseController
{

    [HttpGet]
    public async Task<IActionResult> GetIngredientsByUserId([FromQuery] IngredientsGetByRecipeIdQuery query) => Ok(await Mediator.Send(query));

    [HttpPost]
    public async Task<IActionResult> Create(IngredientCreateCommand command) => Ok(await Mediator.Send(command));
}