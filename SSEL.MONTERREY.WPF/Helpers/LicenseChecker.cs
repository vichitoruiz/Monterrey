using System.IO;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SSEL.MONTERREY.WPF.Helpers;

public static class LicenseChecker
{
    private static readonly string LicenseFile = Path.Combine(AppContext.BaseDirectory, "license.txt");
    private static readonly string ValidLicenseHash = "E2C93E0B987F1DCD1E95C9AFD3BDE12A"; // Ejemplo

    public static bool ValidateLocalLicense()
    {
        if (!File.Exists(LicenseFile))
            return false;

        var licenseContent = File.ReadAllText(LicenseFile).Trim();
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(licenseContent));
        var licenseHash = Convert.ToHexString(hash);

        return licenseHash.Equals(ValidLicenseHash, StringComparison.OrdinalIgnoreCase);
    }
}
