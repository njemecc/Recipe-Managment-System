namespace RMS.Application.Common.Exceptions;

internal class AuthException(string message, object? additionalData = null) : BaseException(message,
    additionalData);