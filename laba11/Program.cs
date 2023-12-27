using System;
using System.Security.Cryptography;
using System.Text;

class DSAExample
{
    static void Main()
    {
        // Генерація ключів
        using (var dsa = new DSACryptoServiceProvider())
        {
            // Підписання повідомлення
            string message = "Hello, world!";
            byte[] data = Encoding.UTF8.GetBytes(message);

            byte[] signature = SignData(data, dsa);

            // Перевірка підпису
            bool isValid = VerifyData(data, signature, dsa);

            Console.WriteLine("Is signature valid? " + isValid);
        }
    }

    static byte[] SignData(byte[] data, DSACryptoServiceProvider dsa)
    {
        // Генерація підпису
        byte[] hash = SHA1.Create().ComputeHash(data);
        byte[] signature = dsa.SignHash(hash, "SHA1");

        return signature;
    }

    static bool VerifyData(byte[] data, byte[] signature, DSACryptoServiceProvider dsa)
    {
        // Верифікація підпису
        byte[] hash = SHA1.Create().ComputeHash(data);
        bool isValid = dsa.VerifyHash(hash, "SHA1", signature);

        return isValid;
    }
}