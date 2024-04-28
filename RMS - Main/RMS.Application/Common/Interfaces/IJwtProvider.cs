using RMS.Domain.Entities;

namespace RMS.Application.Common.Interfaces;

public interface IJwtProvider
{
    string GenerateJwt(ApplicationUser user);
}