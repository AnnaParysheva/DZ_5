using System;
using System.Collections.Generic;

namespace Tumakov_Labs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task2();
            TaskDZ3();
            Task3();
            Console.ReadKey();;
        }
        static void Task3()
        {
            Random rand = new Random();
            double[,] temperature = new double[12, 30];
            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    temperature[month, day] = rand.Next(-40, 40);
                }
            }
            double[] averageTemperatures = CalculateAverageTemperatures(temperature);
            Console.WriteLine("Средние температуры за каждый месяц:");
            for (int month = 0; month < averageTemperatures.Length; month++)
            {
                Console.WriteLine($"{averageTemperatures[month]:N2} C");
            }
            Array.Sort(averageTemperatures);
            Console.WriteLine("\nОтсортированные средние температуры:");
            foreach (var avgTemp in averageTemperatures)
            {
                Console.WriteLine($"{avgTemp:F2} C");
            }
        }
        static void TaskDZ3()
        { 
            Console.WriteLine("Домашнее задание 6.3");
            Dictionary<string, int[]> monthTemperatures = new Dictionary<string, int[]>
            {
            { "Январь", new int[30] },
            { "Февраль", new int[30] },
            { "Март", new int[30] },
            { "Апрель", new int[30] },
            { "Май", new int[30] },
            { "Июнь", new int[30] },
            { "Июль", new int[30] },
            { "Август", new int[30] },
            { "Сентябрь", new int[30] },
            { "Октябрь", new int[30] },
            { "Ноябрь", new int[30] },
            { "Декабрь", new int[30] }
            };
            Random random = new Random();
            foreach (var month in monthTemperatures.Keys)
            {
                for (int day = 0; day < 30; day++)
                {
                    monthTemperatures[month][day] = random.Next(-40, 40);
                }
            }
            double[] monthlyAverages = ComputeMonthlyAverages(monthTemperatures);
            Console.WriteLine("Средние температуры за каждый месяц:");
            int index = 0;
            foreach (var month in monthTemperatures.Keys)
            {
                Console.WriteLine($"{month}: {monthlyAverages[index]:N2} C");
                index++;
            }
            Array.Sort(monthlyAverages);
            Console.WriteLine("\nОтсортированные средние температуры:");
            foreach (var avgTemp in monthlyAverages)
            {
                Console.WriteLine($"{avgTemp:F2} C");
            }
        }
        static void Task2()
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
        static double[] ComputeMonthlyAverages(Dictionary<string, int[]> temperaturesByMonth)
        {
            double[] averages = new double[12];
            int index = 0;
            foreach (var month in temperaturesByMonth)
            {
                double total = 0;
                foreach (var temp in month.Value)
                {
                    total += temp;
                }
                averages[index] = total / month.Value.Length; 
                index++;
            }

            return averages;
        }
        
        static double[] CalculateAverageTemperatures(double[,] temperatures)
        {
            double[] averages = new double[12];

            for (int month = 0; month < 12; month++)
            {
                double sum = 0;
                for (int day = 0; day < 30; day++)
                {
                    sum += temperatures[month, day];
                }
            averages[month] = sum / 30;
        }
        return averages;
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
                throw new Exception("Невозможно умножить матрицы, так как количество столбцов первой матрицы не равно количеству строк второй матрицы.");
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
}
