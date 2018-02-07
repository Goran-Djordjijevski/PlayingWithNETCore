using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace HashingPasswordConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Password();

            byte[] salt = Salt();

            CreateHashPassword(password, salt);

            Console.ReadLine();
        }

        private static void CreateHashPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: password,
                            salt: salt,
                            prf: KeyDerivationPrf.HMACSHA1,
                            iterationCount: 1000,
                            numBytesRequested: 256 / 8));

            Console.WriteLine($"Hashed: {hashed}");
        }

        private static byte[] Salt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string convertSalt = Convert.ToBase64String(salt);
            Console.WriteLine($"Salt: {convertSalt}");
            return salt;
        }

        private static string Password()
        {
            Console.Write("Enter a password: ");
            string password = Console.ReadLine();
            return password;
        }
    }
}
