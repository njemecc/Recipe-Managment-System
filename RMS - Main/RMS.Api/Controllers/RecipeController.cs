using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMS.Api.Auth.Constants;
using RMS.Application.Recipes.commands;
using RMS.Application.Common.Interfaces;
using RMS.Application.Recipes.queries;

namespace RMS.Api.Controllers;

public class RecipeController(IPostgresDbContext dbContext): ApiBaseController
{
    
    [HttpPost]
    public async Task<IActionResult> Create(RecipeCreateCommand command) => Ok(await Mediator.Send(command));

    [HttpGet]
    public async Task<IActionResult> GetRecipeByUserId([FromQuery]RecipeGetByIdQuery query) => Ok(await Mediator.Send(query));
}