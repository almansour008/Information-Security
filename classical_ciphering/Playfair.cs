using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classical_ciphering
{
    internal class Playfair
    {
        private string key;
        private char[,] keySquare;

        private const string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";

        public Playfair(string key)
        {
            this.key = key;
            this.keySquare = CreateKeySquare(key);
        }

        private char[,] CreateKeySquare(string key)
        {
            string cleanedKey = PrepareKey(key);
            char[,] square = new char[5, 5];
            HashSet<char> usedLetters = new HashSet<char>();
            int index = 0;

            foreach (char character in cleanedKey)
            {
                if (!usedLetters.Contains(character))
                {
                    square[index / 5, index % 5] = character;
                    usedLetters.Add(character);
                    index++;
                }
            }

            // Fill the remaining spots with unused letters
            foreach (char letter in alphabet)
            {
                if (!usedLetters.Contains(letter))
                {
                    square[index / 5, index % 5] = letter;
                    index++;
                }
            }

            return square;
        }

        public string Encrypt(string plaintext)
        {
            string preparedText = PrepareText(plaintext);
            List<string> digraphs = CreateDigraphs(preparedText);
            StringBuilder ciphertext = new StringBuilder();

            foreach (string digraph in digraphs)
            {
                ciphertext.Append(EncryptDigraph(digraph));
            }

            return ciphertext.ToString();
        }

        public string Decrypt(string ciphertext)
        {
            string preparedText = PrepareText(ciphertext);
            List<string> digraphs = CreateDigraphs(preparedText);
            StringBuilder plaintext = new StringBuilder();

            foreach (string digraph in digraphs)
            {
                plaintext.Append(DecryptDigraph(digraph));
            }

            return plaintext.ToString();
        }

        private List<string> CreateDigraphs(string text)
        {
            List<string> digraphs = new List<string>();
            for (int i = 0; i < text.Length; i += 2)
            {
                char first = text[i];
                char second = (i + 1 < text.Length) ? text[i + 1] : 'X';

                if (first == second)
                {
                    second = 'X';
                }

                digraphs.Add($"{first}{second}");
            }
            return digraphs;
        }

        private string EncryptDigraph(string digraph)
        {
            (int row1, int col1) = FindPosition(digraph[0]);
            (int row2, int col2) = FindPosition(digraph[1]);

            if (row1 == row2)
            {
                return $"{keySquare[row1, (col1 + 1) % 5]}{keySquare[row2, (col2 + 1) % 5]}";
            }
            else if (col1 == col2)
            {
                return $"{keySquare[(row1 + 1) % 5, col1]}{keySquare[(row2 + 1) % 5, col2]}";
            }
            else
            {
                return $"{keySquare[row1, col2]}{keySquare[row2, col1]}";
            }
        }

        private string DecryptDigraph(string digraph)
        {
            (int row1, int col1) = FindPosition(digraph[0]);
            (int row2, int col2) = FindPosition(digraph[1]);

            if (row1 == row2)
            {
                return $"{keySquare[row1, (col1 + 4) % 5]}{keySquare[row2, (col2 + 4) % 5]}";
            }
            else if (col1 == col2)
            {
                return $"{keySquare[(row1 + 4) % 5, col1]}{keySquare[(row2 + 4) % 5, col2]}";
            }
            else
            {
                return $"{keySquare[row1, col2]}{keySquare[row2, col1]}";
            }
        }

        private (int, int) FindPosition(char ch)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (keySquare[i, j] == ch)
                    {
                        return (i, j);
                    }
                }
            }
            throw new ArgumentException("Character not found in key square");
        }
        private string PrepareText(string text)
        {
            StringBuilder prepared = new StringBuilder();
            foreach (char ch in text.ToUpper())
            {
                if (ch == 'J') prepared.Append('I');
                else if (alphabet.Contains(ch)) prepared.Append(ch);
            }
            return prepared.ToString();
        }

        private string PrepareKey(string key)
        {
            HashSet<char> seen = new HashSet<char>();
            StringBuilder cleanedKey = new StringBuilder();

            foreach (char ch in key.ToUpper())
            {
                char processedChar = (ch == 'J') ? 'I' : ch;
                if (alphabet.Contains(processedChar) && !seen.Contains(processedChar))
                {
                    seen.Add(processedChar);
                    cleanedKey.Append(processedChar);
                }
            }

            return cleanedKey.ToString();
        }
    }

}

