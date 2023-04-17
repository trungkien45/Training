using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Training.Common
{
    public class AesAlgorithm
    {
        public static string AesEncryptString(string plainText, byte[] key)
        {
            using var aesAlg = Aes.Create();
            int i = 0;
            var Key = new byte[32];
            var IV = new byte[16];
            for (i = 0; i < 32; i++)
            {
                Key[i] = key[i];
            }
            aesAlg.Key = Key;

            for (; i < 48; i++)
            {
                IV[i - 32] = key[i];
            }
            aesAlg.IV = IV;

            // Encrypt the string to bytes
            byte[] encrypted = null;
            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }


            // Return the encrypted bytes from the memory stream.

            // Combine the IV and encrypted data into a single string
            return Convert.ToBase64String(encrypted);
        }
        public static string AesDecryptString(string cipherText, byte[] key)
        {
            string plaintext = null;

            byte[] buffer = Convert.FromBase64String(cipherText);
            using Aes aesAlg = Aes.Create();
            int i = 0;
            var Key = new byte[32];
            var IV = new byte[16];
            for (i = 0; i < 32; i++)
            {
                Key[i] = key[i];
            }
            aesAlg.Key = Key;

            for (; i < 48; i++)
            {
                IV[i - 32] = key[i];
            }
            aesAlg.IV = IV;
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(buffer))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            return plaintext;


        }
    }
}
