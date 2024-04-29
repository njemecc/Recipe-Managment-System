using RMS.Application.Common.Dto.NSI_Authentication;

namespace RMS.Application.Common.Interfaces;

public interface IAuthService
{
    Task<BeginLoginResponseDto> BeginLoginAsync(string emailAddress);
    Task<CompleteLoginResponseDto> CompleteLoginAsync(string token);
}