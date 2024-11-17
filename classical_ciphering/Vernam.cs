using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace classical_ciphering
{
    internal class Vernam
    {
        private string key; 

        public Vernam(string key)
        {
            this.key = key;
        }

        public string Encrypt(string plaintext)
        {
            string preparedText = PrepareText(plaintext);

            if (preparedText.Length != this.key.Length)
            {
                return "Error: Key length must be equal to plaintext length";
            }
            byte[] Bytes = new byte[preparedText.Length];

            for (int i = 0; i < preparedText.Length; i++)
            {
                Bytes[i] = (byte)(preparedText[i] ^ key[i]);
            }
            string cipherText=Convert.ToBase64String(Bytes);
            return cipherText;

        }

        public string Decrypt(string ciphertext)
        {
            byte [] preparedText =Convert.FromBase64String( PrepareText(ciphertext));

            if (preparedText.Length != this.key.Length)
            {
                return "Error: Key length must be equal to ciphertext length";
            }
            StringBuilder decryptedText=new StringBuilder();

            for (int i = 0; i < preparedText.Length; i++)
            {
                char decryptedChar = (char)(preparedText[i] ^ key[i]);
                decryptedText.Append(decryptedChar);
            }
            return decryptedText.ToString();
        }

        private string PrepareText(string text)
        {
            return text.Replace(" ", "");
        }

        private int ConvertCharToBinary(char ch)
        {
            return ch;
        }
        private char ConvertBinaryToChar(int binary)
        {
            return (char)binary;
        }
    }
}
