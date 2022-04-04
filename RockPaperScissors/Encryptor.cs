using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissors {

    internal static class Encryptor {

        internal static string GenerateRandomKey() {

            RandomNumberGenerator generator = RandomNumberGenerator.Create();
            byte[] byteArray = new byte[32];

            generator.GetBytes(byteArray);
            string key = BitConverter.ToString(byteArray, 0).Replace("-", "");

            return key;

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