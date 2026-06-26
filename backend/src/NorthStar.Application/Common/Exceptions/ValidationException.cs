namespace NorthStar.Application.Common.Exceptions;

/// <summary>Thrown when a request fails validation; mapped to HTTP 400 in the API.</summary>
public sealed class ValidationException : Exception
{
    public ValidationException(IReadOnlyDictionary<string, string[]> errors)
        : base("One or more validation errors occurred.")
        => Errors = errors;

    public IReadOnlyDictionary<string, string[]> Errors { get; }
}
