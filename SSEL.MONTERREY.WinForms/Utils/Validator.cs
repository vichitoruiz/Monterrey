namespace SSEL.MONTERREY.WinForms.Utils;

public static class Validator
{
    public static bool IsNumeric(string input) => decimal.TryParse(input, out _);
    public static bool IsEmail(string email) =>
        !string.IsNullOrWhiteSpace(email) && email.Contains('@') && email.Contains('.');
}
