using System.Security.Cryptography;
using System.Text;

namespace AudioStreaming.Domain;

public static class Crypto
{
    public static string HashSHA256(this string plainText)
    {
        SHA256 criptoProvider = SHA256.Create();

        byte[] btexto = Encoding.UTF8.GetBytes(plainText);

        var criptoResult = criptoProvider.ComputeHash(btexto);

        return Convert.ToHexString(criptoResult);
    }
}
