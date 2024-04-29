using MediatR;
using RMS.Application.Common.Dto.NSI_Authentication;

namespace RMS.Application.NSI_Authentication;

public record CompleteLoginCommand(string ValidationToken) : IRequest<CompleteLoginResponseDto>;
