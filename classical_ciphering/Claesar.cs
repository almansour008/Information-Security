using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classical_ciphering
{
    internal class CaesarCipher
    {
        public string[] alphabet =
         {"a","b","c","d","e","f","g","h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w","x" ,"y","z"};
        public String encryption(string p, int k)
        {
            p = p.Replace(" ", "");
            p = p.ToLower();
            String c = "";
            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {

                    if (p[i].ToString() == alphabet[j])
                    {
                        c = c + alphabet[(j + k) % alphabet.Length];
                    }
                }
            }
            return c;
        }
        public String decryption(String c, int k)
        {
            string p = "";
            for (int i = 0; i < c.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (c[i].ToString() == alphabet[j])
                    {
                        p = p + alphabet[(j - k + alphabet.Length) % alphabet.Length];
                    }
                }
            }
            return p;
        }
    }
}
