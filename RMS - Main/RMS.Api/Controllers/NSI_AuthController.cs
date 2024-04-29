using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RMS.Application.NSI_Authentication;

namespace RMS.Api.Controllers;

public class NSI_AuthController:ApiBaseController
{


    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Beginlogin(BeginLoginCommand command) => Ok(await Mediator.Send(command));

    [AllowAnonymous]
    [HttpGet("{validationToken}/CompleteLogin")]

    public async Task<ActionResult> CompleteLogin([FromRoute] string validationToken) =>
        Ok(await Mediator.Send(new CompleteLoginCommand(validationToken)));
}