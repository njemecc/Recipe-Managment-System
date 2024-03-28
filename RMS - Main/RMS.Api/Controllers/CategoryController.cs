using Microsoft.AspNetCore.Mvc;
using RMS.Application.Categories.commands;

namespace RMS.Api.Controllers;

public class CategoryController : ApiBaseController
{

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateCommand command) => Ok(await Mediator.Send(command));

}