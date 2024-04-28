using Microsoft.AspNetCore.Mvc;
using RMS.Application.Authentication.commands;
using RMS.Application.Categories.commands;

namespace RMS.Api.Controllers;

public class AuthController: ApiBaseController
{
   [HttpPost]
    public async Task<IActionResult> LoginUser(LoginCommand command) => Ok(await Mediator.Send(command));
}