using MediatR;
using RMS.Application.Common.Dto.NSI_Authentication;
using RMS.Application.Common.Interfaces;

namespace RMS.Application.NSI_Authentication;

public class CompleteLoginHandler(IAuthService authService) : IRequestHandler<CompleteLoginCommand, CompleteLoginResponseDto>
{
    public async Task<CompleteLoginResponseDto> Handle(CompleteLoginCommand request, CancellationToken cancellationToken) => await authService.CompleteLoginAsync(request.ValidationToken);
}