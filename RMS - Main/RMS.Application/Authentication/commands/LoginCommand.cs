using MediatR;

namespace RMS.Application.Authentication.commands;

public record LoginCommand(string Email): IRequest<string>;

