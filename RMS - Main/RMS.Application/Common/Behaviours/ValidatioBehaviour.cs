using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using RMS.Application.Common.Extensions;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace RMS.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context,
            cancellationToken)));

        var failures = validationResults.Where(r => r.Errors.Count != 0)
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Count != 0)
            throw new ValidationException(failures.ToGroup().ToString());

        return await next();
    }
}