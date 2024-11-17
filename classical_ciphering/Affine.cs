using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classical_ciphering
{
    internal class Affine
    {
        public string[] alphabet =
         {"a","b","c","d","e","f","g","h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w","x" ,"y","z"};
        public  bool GCD(int a, int m)
        {
            while (m != 0)
            {
                int temp = m;
                m = a % m;
                a = temp;
            }
            if (a == 1)
                return true;
            else
                return false;
        }
        public  int extendedEuclidean(int a, int m)
        {
            int alphabet = m;
            int n0 = 0,
                n1 = 1;
            int x, y;

            if (a % m == 0)
                return -1;

            while (a > 1)
            {
                x = a / m;
                y = m;
                m = a % m;
                a = y;
                y = n0;
                n0 = n1 - x * n0;
                n1 = y;
            }
            if (n1 < 0)
                n1 += alphabet;
            return n1;
        }
        public  string affineEncryption( string message, int a, int b)
        {
            message = message.Replace(" ", "");
            bool z = GCD(a, alphabet.Length);
            if (!z)
                return "the key is a valid value";
            else
            {
                String e = "";
                for (int i = 0; i < message.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {

                        if (message[i].ToString() == alphabet[j])
                        {
                            e = e + alphabet[(a * j + b) % alphabet.Length];
                        }
                    }
                }
                return e;
            }

        }
        public string affineDecryption(string cipher, int a_inverse, int b)
        {
            string message = "";
            for (int i = 0; i < cipher.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (cipher[i].ToString() == alphabet[j])
                    {
                        message = message + alphabet[(a_inverse * ((j - b) + alphabet.Length)) % alphabet.Length];
                    }
                }
            }
            return message;
        }
    }
}
