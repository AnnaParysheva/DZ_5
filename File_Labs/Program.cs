using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите размерность первой матрицы:");
        Console.Write("Количество строк: ");
        int rows1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Количество столбцов: ");
        int cols1 = Convert.ToInt32(Console.ReadLine());
        int[,] matrix1 = new int[rows1, cols1];
        Console.WriteLine("Введите элементы первой матрицы: ");
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols1; j++)
            {
                matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        Console.WriteLine("Введите размерность второй матрицы: ");
        Console.Write("Количество строк: ");
        int rows2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Количество столбцов: ");
        int cols2 = Convert.ToInt32(Console.ReadLine());
        int[,] matrix2 = new int[rows2, cols2];
        Console.WriteLine("Введите элементы второй матрицы: ");
        for (int i = 0; i < rows2; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                matrix2[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        Console.WriteLine("Первая матрица:");
        PrintMatrix(matrix1);
        Console.WriteLine("Вторая матрица:");
        PrintMatrix(matrix2);
        int[,] result = MultiplyMatrices(matrix1, matrix2);
        Console.WriteLine("Результат умножения матриц:");
        PrintMatrix(result);
    }
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);
        if (cols1 != rows2)
        {
            throw new Exception("Невозможно умножить матрицы: количество столбцов первой матрицы не равно количеству строк второй матрицы.");
        }
        int[,] result = new int[rows1, cols2];
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return result;
    }
}