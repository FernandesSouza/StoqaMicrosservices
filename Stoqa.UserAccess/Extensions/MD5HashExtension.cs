using System.Security.Cryptography;
using System.Text;

namespace Stoqa.Identity.Extensions;

public static class Md5HashExtension
{
    public static string ConvertMd5(this string signature, Guid userId)
    {
        if (string.IsNullOrWhiteSpace(signature)) return string.Empty;

        var signatureProcessed = $"{signature}{userId.ToString()}";
        var dataBytes = MD5.HashData(Encoding.Default.GetBytes(signatureProcessed));
        var sbString = new StringBuilder();

        foreach (var pass in dataBytes)
        {
            sbString.Append(pass.ToString("x2"));
        }

        return sbString.ToString();
    }
}