using System.Text.Json;
using System;

namespace SSEL.MONTERREY.Licensing;

public static class LicenseManager
{
    private static readonly string LicenseFile = Path.Combine(AppContext.BaseDirectory, "license.dat");

    public static bool IsLicenseValid(out LicenseModel? lic)
    {
        lic = null;
        if (!File.Exists(LicenseFile)) return false;

        try
        {
            var enc = File.ReadAllText(LicenseFile);
            var json = Encryptor.Decrypt(enc);
            lic = JsonSerializer.Deserialize<LicenseModel>(json);

            if (lic is null) return false;

            if (lic.ExpirationDate < DateTime.Today)
                return false;

            var hwid = HWIDGenerator.GetHardwareId();
            return hwid.Equals(lic.HardwareId, StringComparison.OrdinalIgnoreCase);
        }
        catch { return false; }
    }

    public static void SaveLicense(LicenseModel license)
    {
        var json = JsonSerializer.Serialize(license, new JsonSerializerOptions { WriteIndented = true });
        var enc = Encryptor.Encrypt(json);
        File.WriteAllText(LicenseFile, enc);
    }
}
