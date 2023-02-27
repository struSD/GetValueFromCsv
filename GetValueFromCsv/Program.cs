using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    private static void Main(string[] args)
    {
        string filePath = "C:\\Users\\danul\\Downloads\\TouchPanelData.csv";
        string[] lines = File.ReadAllLines(filePath);
        string[] size = lines[0].Split(',');
        int rowCount = lines.Length;
        int matrixNum1 = int.Parse(size[0]);
        int matrixNum2 = int.Parse(size[1]);
        int colCount = matrixNum1 * matrixNum2;

        int[,] data = new int[rowCount - 1, colCount];

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            for (int j = 0; j < colCount; j++)
            {
                data[i - 1, j] = int.Parse(values[j]);
            }
        }

        GetMaxNumbers(data);
        GetMaxSingleNum(1, data);
        int[,] mass = GetMaxValuesArray(data);



        for (int i = 0; i < rowCount - 1; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                Console.Write(data[i, j] + " ");
            }
            Console.WriteLine();
        }

        void GetMaxSingleNum(int row, int[,] mass)
        {
            int rowNumber = row;
            int max = mass[rowNumber, 0];

            for (int j = 1; j < mass.GetLength(1); j++)
            {
                if (mass[rowNumber, j] > max)
                {
                    max = mass[rowNumber, j];
                }
            }
            Console.WriteLine("Max value on frame {0} - {1}", rowNumber, max);
        }

        void GetMaxNumbers(int[,] mass)
        {
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                int max = mass[i, 0];
                int pos = 0;

                for (int j = 1; j < mass.GetLength(1); j++)
                {
                    if (mass[i, j] > max)
                    {
                        max = mass[i, j];
                        pos = j;
                    }
                }
                Console.WriteLine($"Max value N={matrixNum1}; M={matrixNum2}\t X={pos}\t DIV{matrixNum2}={pos / matrixNum2};\t Y={pos}\t MOD{matrixNum2}={pos % matrixNum2}");

            }
        }

        int[,] GetMaxValuesArray(int[,] array)
        {
            int[,] maxValuesArray = new int[array.GetLength(0), 1];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int max = int.MinValue;

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                }

                maxValuesArray[i, 0] = max;
            }

            return maxValuesArray;
        }
    }
}


