using System;
namespace SSEL.MONTERREY.Licensing;

public static class LicenseValidator
{
    public static bool ValidateAtStartup()
    {
        if (!LicenseManager.IsLicenseValid(out var license))
        {
            MessageBox.Show("Licencia inválida o caducada.\nContacte a soporte o ingrese una nueva licencia.",
                "SSEL MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}
