namespace SSEL.MONTERREY.Application.Helpers;

/// <summary>
/// Resultado estandarizado para operaciones de aplicación.
/// </summary>
public record Result(bool Success, string? Message = null)
{
    public static Result Ok(string? msg = null) => new(true, msg);
    public static Result Fail(string msg) => new(false, msg);
}
