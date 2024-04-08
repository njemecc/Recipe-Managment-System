using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Api.Auth.Constants;
using RMS.Application.Categories.commands;

namespace RMS.Api.Controllers;

public class CategoryController : ApiBaseController
{

    [HttpPost]
    [Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderBasicAuthenticationScheme))]
    public async Task<IActionResult> Create(CategoryCreateCommand command) => Ok(await Mediator.Send(command));

}