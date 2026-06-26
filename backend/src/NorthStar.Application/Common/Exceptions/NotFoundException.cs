namespace NorthStar.Application.Common.Exceptions;

/// <summary>Thrown when a requested entity does not exist (or is not visible to the caller).</summary>
public sealed class NotFoundException : Exception
{
    public NotFoundException(string entity, object key)
        : base($"{entity} '{key}' was not found.")
    {
    }
}
