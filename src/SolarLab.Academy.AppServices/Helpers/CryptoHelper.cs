using System.Security.Cryptography;
using System.Text;

namespace SolarLab.Academy.AppServices.Helpers;

public static class CryptoHelper
{
    public static string GetBase64Hash(string stringToEncrypt)
    {
        var buffer = Encoding.UTF8.GetBytes(stringToEncrypt);
        var sha = SHA256.Create() as HashAlgorithm;
        var hash = sha.ComputeHash(buffer);

        return Convert.ToBase64String(hash);
    }
}
