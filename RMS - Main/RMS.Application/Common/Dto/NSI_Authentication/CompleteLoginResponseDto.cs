namespace RMS.Application.Common.Dto.NSI_Authentication;

public record CompleteLoginResponseDto(string? EmailAdresses = null, List<string>? Roles = null, string? JwtToken = null);