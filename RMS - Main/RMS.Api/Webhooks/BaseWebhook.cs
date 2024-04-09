﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RMS.Api.Webhooks;

[ApiController]
[Route("webhook/[controller]/[action]")]
public class BaseWebhook : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

}