using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classical_ciphering
{
    internal class Hill
    {

        private int[,] keyMatrix; 
        private int keyDeterminant; 
        private int keyInverse; 

        public Hill(int[,] key)
        {
            this.keyMatrix = key;
            this.keyDeterminant = CalculateDeterminant(keyMatrix);
            this.keyInverse = CalculateModularInverse(keyDeterminant, 26);
        }

        public string Encrypt(string plaintext)
        {
            int[,] plainPairs = PreparePlaintext(plaintext);
            int[,] encryptedPairs = MultiplyMatrices(keyMatrix, plainPairs);
            encryptedPairs = ModuloMatrix(encryptedPairs, 26);
            return ConvertToString(encryptedPairs);
        }

        public string Decrypt(string ciphertext)
        {
            int[,] cipherPairs = PrepareCiphertext(ciphertext);
            int[,] inverseKeyMatrix = KeyInverseMatrix();
            int[,] decryptedPairs = MultiplyMatrices(inverseKeyMatrix, cipherPairs);
            decryptedPairs = ModuloMatrix(decryptedPairs, 26);
            return ConvertToString(decryptedPairs);
        }

        private int CalculateDeterminant(int[,] m)
        {
            return (m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0]) % 26;
        }

        private int CalculateModularInverse(int a, int m)
        {
            int x;
            for ( x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                    return x;
            }
            
            return 0;
          
        }

        private int[,] PreparePlaintext(string plaintext)
        {
            plaintext = plaintext.Replace(" ", "").ToUpper();
            if (plaintext.Length % 2 != 0)
                plaintext += 'X'; 

            int[,] pairs = new int[2, plaintext.Length / 2];
            for (int i = 0; i < plaintext.Length; i += 2)
            {
                pairs[0, i / 2] = plaintext[i] - 'A';
                pairs[1, i / 2] = plaintext[i + 1] - 'A';
            }
            return pairs;
        }

        private int[,] PrepareCiphertext(string ciphertext)
        {
            ciphertext = ciphertext.ToUpper();
            int[,] pairs = new int[2, ciphertext.Length / 2];
            for (int i = 0; i < ciphertext.Length; i += 2)
            {
                pairs[0, i / 2] = ciphertext[i] - 'A';
                pairs[1, i / 2] = ciphertext[i + 1] - 'A';
            }
            return pairs;
        }

        private int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix2.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }

        private int[,] ModuloMatrix(int[,] matrix, int mod)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = (matrix[i, j] % mod + mod) % mod;
                }
            }
            return matrix;
        }

        private string ConvertToString(int[,] matrix)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                result.Append((char)(matrix[0, i] + 'A'));
                result.Append((char)(matrix[1, i] + 'A'));
            }
            return result.ToString();
        }

        private int[,] KeyInverseMatrix()
        {
            int[,] inverseMatrix = new int[2, 2];
            inverseMatrix[0, 0] = keyMatrix[1, 1] * keyInverse % 26;
            inverseMatrix[1, 1] = keyMatrix[0, 0] * keyInverse % 26;
            inverseMatrix[0, 1] = (-keyMatrix[0, 1] * keyInverse % 26 + 26) % 26;
            inverseMatrix[1, 0] = (-keyMatrix[1, 0] * keyInverse % 26 + 26) % 26;
            return inverseMatrix;
        }
    }


}
