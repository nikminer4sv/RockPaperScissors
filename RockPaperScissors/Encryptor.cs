using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissors {

    internal static class Encryptor {

        internal static string GenerateRandomKey() {
	    byte[] byteArray = new byte[32];
            RandomNumberGenerator generator = RandomNumberGenerator.Create();
            generator.GetBytes(byteArray);
            return BitConverter.ToString(byteArray, 0).Replace("-", "");
        }

        internal static string GenerateHMAC(string text, string key) {
            var encoding = new ASCIIEncoding();
            var textBytes = encoding.GetBytes(text);
            var keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (var hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

    }

}
