using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Api.Auth.Constants;
using RMS.Application.Categories.commands;
using RMS.Application.Ingredients.commands;

namespace RMS.Api.Webhooks;


[Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderBasicAuthenticationScheme))]
public class IngredientCreationWebHook : BaseWebhook
{
    [HttpPost]
    public async Task<IActionResult> Create(IngredientCreateCommand command) => Ok(await Mediator.Send(command));
}