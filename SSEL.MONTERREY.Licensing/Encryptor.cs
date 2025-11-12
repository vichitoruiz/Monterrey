using System;
using System.Security.Cryptography;
using System.Text;

namespace SSEL.MONTERREY.Licensing;

public static class Encryptor
{
    private static readonly string Key = "SSEL_MONTERREY_AES_KEY_2025";

    public static string Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.Key = SHA256.HashData(Encoding.UTF8.GetBytes(Key));
        aes.IV = new byte[16];
        var enc = aes.CreateEncryptor(aes.Key, aes.IV);
        var bytes = Encoding.UTF8.GetBytes(plainText);
        var cipher = enc.TransformFinalBlock(bytes, 0, bytes.Length);
        return Convert.ToBase64String(cipher);
    }

    public static string Decrypt(string cipherText)
    {
        using var aes = Aes.Create();
        aes.Key = SHA256.HashData(Encoding.UTF8.GetBytes(Key));
        aes.IV = new byte[16];
        var dec = aes.CreateDecryptor(aes.Key, aes.IV);
        var bytes = Convert.FromBase64String(cipherText);
        var plain = dec.TransformFinalBlock(bytes, 0, bytes.Length);
        return Encoding.UTF8.GetString(plain);
    }
}
