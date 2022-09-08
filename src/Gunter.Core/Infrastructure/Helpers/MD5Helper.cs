using System.Security.Cryptography;
using System.Text;

namespace Gunter.Core.Infrastructure.Helpers
{
    public static class MD5Helper
    {

        public static string GetHash(string itemString)
        {
            using var md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes($"{itemString}");
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }

    }
}
