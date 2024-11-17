using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classical_ciphering
{
    internal class Vigenere
    {

        private string key;

        public Vigenere(string key)
        {
            this.key = key.ToUpper();
        }

        public string Encrypt(string plaintext)
        {
            string preparedText = PrepareText(plaintext);
            string extendedKey = ExtendKey(preparedText.Length);
            StringBuilder ciphertext = new StringBuilder();

            for (int i = 0; i < preparedText.Length; i++)
            {
                int p = ConvertCharToInt(preparedText[i]);
                int k = ConvertCharToInt(extendedKey[i]);
                int c = (p + k) % 26;
                ciphertext.Append(ConvertIntToChar(c));
            }

            return ciphertext.ToString();
        }

        public string Decrypt(string ciphertext)
        {
            string preparedText = PrepareText(ciphertext);
            string extendedKey = ExtendKey(preparedText.Length);
            StringBuilder plaintext = new StringBuilder();

            for (int i = 0; i < preparedText.Length; i++)
            {
                int c = ConvertCharToInt(preparedText[i]);
                int k = ConvertCharToInt(extendedKey[i]);
                int p = (c - k + 26) % 26; 
                plaintext.Append(ConvertIntToChar(p));
            }

            return plaintext.ToString();
        }

        private string PrepareText(string text)
        {
            text = text.Replace(" ", "").ToUpper();
            return text;
        }

        private string ExtendKey(int length)
        {
            StringBuilder extendedKey = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                extendedKey.Append(this.key[i % this.key.Length]);
            }
            return extendedKey.ToString();
        }

        private int ConvertCharToInt(char ch)
        {
            return ch - 'A';
        }

        private char ConvertIntToChar(int num)
        {
            return (char)(num + 'A');
        }
    }

}

