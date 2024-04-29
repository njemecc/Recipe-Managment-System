using MediatR;
using RMS.Application.Common.Dto.NSI_Authentication;

namespace RMS.Application.NSI_Authentication;

public record BeginLoginCommand(string EmailAddresses) : IRequest<BeginLoginResponseDto>;
