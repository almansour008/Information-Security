using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classical_ciphering
{
    public class ADFGVX
    {
        private readonly char[,] polybiusSquare;
        private readonly string[] symbols = { "A", "D", "F", "G", "V", "X" };
        private string keyword;

        
        public ADFGVX(string keyword)
        {
            this.keyword = keyword.ToUpper();

            polybiusSquare = new char[,]
            {
            { 'A', 'B', 'C', 'D', 'E', 'F' },
            { 'G', 'H', 'I', 'J', 'K', 'L' },
            { 'M', 'N', 'O', 'P', 'Q', 'R' },
            { 'S', 'T', 'U', 'V', 'W', 'X' },
            { 'Y', 'Z', '0', '1', '2', '3' },
            { '4', '5', '6', '7', '8', '9' }
            };
        }

        public string Encrypt(string message)
        {
            message = message.ToUpper().Replace(" ", "");
            StringBuilder substituted = new StringBuilder();

            // Step 1: Polybius square substitution
            foreach (char ch in message)
            {
                for (int row = 0; row < 6; row++)
                {
                    for (int col = 0; col < 6; col++)
                    {
                        if (polybiusSquare[row, col] == ch)
                        {
                            substituted.Append(symbols[row]);
                            substituted.Append(symbols[col]);
                        }
                    }
                }
            }

            // Step 2: Transposition with the keyword
            string substitutedText = substituted.ToString();
            return Transpose(substitutedText);
        }

        public string Decrypt(string encryptedText)
        {
            // Step 1: Inverse transposition
            string substitutedText = InverseTranspose(encryptedText);

            // Step 2: Polybius square lookup
            StringBuilder decrypted = new StringBuilder();
            for (int i = 0; i < substitutedText.Length; i += 2)
            {
                int row = Array.IndexOf(symbols, substitutedText[i].ToString());
                int col = Array.IndexOf(symbols, substitutedText[i + 1].ToString());
                decrypted.Append(polybiusSquare[row, col]);
            }

            return decrypted.ToString();
        }

     
        private string Transpose(string text)
        {
            int columns = keyword.Length;
            int rows = (int)Math.Ceiling((double)text.Length / columns);
            char[,] transpositionTable = new char[rows, columns];

            // Fill the table with text characters row by row
            for (int i = 0; i < text.Length; i++)
            {
                int row = i / columns;
                int col = i % columns;
                transpositionTable[row, col] = text[i];
            }

            // Sort columns by the keyword's alphabetical order
            char[] sortedKeyword = keyword.ToCharArray();
            Array.Sort(sortedKeyword);

            StringBuilder transposed = new StringBuilder();

            foreach (char letter in sortedKeyword)
            {
                int originalCol = keyword.IndexOf(letter);

                for (int row = 0; row < rows; row++)
                {
                    if (transpositionTable[row, originalCol] != '\0')
                        transposed.Append(transpositionTable[row, originalCol]);
                }
            }

            return transposed.ToString();
        }

        private string InverseTranspose(string transposedText)
        {
            int columns = keyword.Length;
            int rows = (int)Math.Ceiling((double)transposedText.Length / columns);
            char[,] transpositionTable = new char[rows, columns];

            // Sort columns by the keyword's alphabetical order
            char[] sortedKeyword = keyword.ToCharArray();
            Array.Sort(sortedKeyword);

            // Fill the table column by column based on sorted keyword
            int index = 0;
            foreach (char letter in sortedKeyword)
            {
                int originalCol = keyword.IndexOf(letter);

                for (int row = 0; row < rows && index < transposedText.Length; row++)
                {
                    transpositionTable[row, originalCol] = transposedText[index++];
                }
            }

            // Read the table row by row to get the original substituted text
            StringBuilder substitutedText = new StringBuilder();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (transpositionTable[row, col] != '\0')
                        substitutedText.Append(transpositionTable[row, col]);
                }
            }

            return substitutedText.ToString();
        }
    }


}

