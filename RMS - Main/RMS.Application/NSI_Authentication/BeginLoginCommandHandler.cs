using MediatR;
using RMS.Application.Common.Dto.NSI_Authentication;
using RMS.Application.Common.Interfaces;

namespace RMS.Application.NSI_Authentication;

public class BeginLoginCommandHandler
{
    public class BeginLoginHandler(IAuthService authService) : IRequestHandler<BeginLoginCommand, BeginLoginResponseDto>
    {
        public async Task<BeginLoginResponseDto> Handle(BeginLoginCommand request, CancellationToken cancellationToken) => await authService.BeginLoginAsync(request.EmailAddresses);
    }
}