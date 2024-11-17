using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classical_ciphering
{
        public class AffineHill
        {
            private string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i",
            "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            private int[,] keyMatrix;
            private static int[,] BMatrix;
            private Random random = new Random();

            public AffineHill(int[,] keyMatrix)
            {
                this.keyMatrix = keyMatrix;
            }

            private int[,] GenerateRandomBMatrix(int rows, int cols)
            {
                int[,] BMatrix = new int[rows, cols];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        BMatrix[i, j] = random.Next(0, 101);
                return BMatrix;
            }

            private string HillEncrypt(string message)
            {
                if (message.Length % 2 != 0)
                    message += "x"; 

                int[,] pairs = new int[2, message.Length / 2];
                for (int i = 0; i < message.Length; i += 2)
                {
                    pairs[0, i / 2] = message[i] - 'a';
                    pairs[1, i / 2] = message[i + 1] - 'a';
                }

                // حساب KX
                int[,] encryptedPairs = MultiplyMatrices(keyMatrix, pairs);

                BMatrix = GenerateRandomBMatrix(encryptedPairs.GetLength(0), encryptedPairs.GetLength(1));

                encryptedPairs = AddMatrices(encryptedPairs, BMatrix);
                encryptedPairs = ModuloMatrix(encryptedPairs, 26);

                return ConvertToString(encryptedPairs);
            }

            private string HillDecrypt(string cipher)
            {
                int[,] pairs = PrepareCiphertext(cipher);
                pairs = SubtractMatrices(pairs, BMatrix);
                int[,] inverseMatrix = KeyInverseMatrix();
                int[,] decryptedPairs = MultiplyMatrices(inverseMatrix, pairs);
                decryptedPairs = ModuloMatrix(decryptedPairs, 26);

                return ConvertToString(decryptedPairs);
            }

            public string Encrypt(string message)
            {
                return HillEncrypt(message);
            }

            public string Decrypt(string cipher)
            {
                return HillDecrypt(cipher);
            }

            private int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
            {
                int rows = matrix1.GetLength(0);
                int cols = matrix2.GetLength(1);
                int[,] result = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                    {
                        result[i, j] = 0;
                        for (int k = 0; k < matrix1.GetLength(1); k++)
                            result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                return result;
            }

            private int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
            {
                int rows = matrix1.GetLength(0);
                int cols = matrix1.GetLength(1);
                int[,] result = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        result[i, j] = matrix1[i, j] + matrix2[i, j];
                return result;
            }

            private int[,] SubtractMatrices(int[,] matrix1, int[,] matrix2)
            {
                int rows = matrix1.GetLength(0);
                int cols = matrix1.GetLength(1);
            int[,] result = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        result[i, j] = matrix1[i, j] - matrix2[i, j];
            return result;
            }

            private int[,] ModuloMatrix(int[,] matrix, int mod)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        matrix[i, j] = (matrix[i, j] % mod + mod) % mod;
                return matrix;
            }

            private string ConvertToString(int[,] matrix)
            {
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    result.Append((char)(matrix[0, i] + 'a'));
                    result.Append((char)(matrix[1, i] + 'a'));
                }
                return result.ToString();
            }

            private int[,] PrepareCiphertext(string cipher)
            {
                int[,] pairs = new int[2, cipher.Length / 2];
                for (int i = 0; i < cipher.Length; i += 2)
                {
                    pairs[0, i / 2] = cipher[i] - 'a';
                    pairs[1, i / 2] = cipher[i + 1] - 'a';
                }
                return pairs;
            }

            private int[,] KeyInverseMatrix()
            {
                int keyInverse = CalculateModularInverse(Determinant(keyMatrix), 26);
                int[,] inverseMatrix = new int[2, 2];

                inverseMatrix[0, 0] = keyMatrix[1, 1] * keyInverse % 26;
                inverseMatrix[1, 1] = keyMatrix[0, 0] * keyInverse % 26;
                inverseMatrix[0, 1] = (-keyMatrix[0, 1] * keyInverse % 26 + 26) % 26;
                inverseMatrix[1, 0] = (-keyMatrix[1, 0] * keyInverse % 26 + 26) % 26;

                return inverseMatrix;
            }

            private int CalculateModularInverse(int a, int m)
            {
                a = a % m;
                for (int x = 1; x < m; x++)
                    if ((a * x) % m == 1)
                        return x;
                return 0;
            }

            private int Determinant(int[,] matrix)
            {
                return (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) % 26;
            }
        }
    }
