// Задача 1 (54). Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Задача 2 (56). Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Задача 3 (58). Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц. Например, даны 2 матрицы:
// Задача 4 (60). Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Задача 5 (62). Напишите программу, которая заполнит спирально массив 4 на 4.

Console.WriteLine("Инициализация программы");

bool inWork = true;
while (inWork)
{
    Console.Write("Выбери задачу: ");
    if (int.TryParse(Console.ReadLine(), out int i))
    {
        switch (i)
        {
            case 1:
                {
                    Task_1(); 
                break;
                }
            case 2:
                {
                    Task_2(); 
                break;
                }
            case 3:
                {
                    Task_3(); 
                break;
                }
            case 4:
                {
                    Task_4(); 
                break;
                }
            case 5:
                {
                    Task_5(); 
                break;
                }
            case -1: inWork = false; break;
        }
    }
}

void Task_1()
{
    int[,] matrix = new int[ReadInt("Первую длинну массива"), ReadInt("Вторую длинну массива")];
    GetRandArr(matrix);
    PrintMatrix(matrix);
    Console.WriteLine("\nНовая матрица:\n");
    int[,] newMatrix = DescArr(matrix);
    PrintMatrix(newMatrix);
}

void Task_2()
{
    int[,] matrix = new int[ReadInt("Первую длинну массива"), ReadInt("Вторую длинну массива")];
    GetRandArr(matrix);
    PrintMatrix(matrix);
    int[] sumArray = SumArr(matrix);
    MinArrSum(sumArray);
}

void Task_3()
{
    Console.WriteLine("Введите первую матрицу");
    int[,] matrix1 = new int[ReadInt("Первую длинну массива"), ReadInt("Вторую длинну массива")];
    GetRandArr(matrix1);
    PrintMatrix(matrix1);
    Console.WriteLine("Введите вторую матрицу");
    int[,] matrix2 = new int[ReadInt("Первую длинну массива"), ReadInt("Вторую длинну массива")];
    GetRandArr(matrix2);
    PrintMatrix(matrix2);
    CompositionMatrix(matrix1, matrix2);
}

void Task_4()
{
    int[,,] array = new int[ReadInt("Первую длинну массива"), ReadInt("Вторую длинну массива"), ReadInt("Третью длинну массива")];
    GetRandTreeArr(array);
}

void Task_5()
{
    int[,] array = new int[ReadInt("Первую длинну массива"), ReadInt("Вторую длинну массива")];
    PrintMatrix(SpiralArray(array));
}

int ReadInt(string argName)
{
    Console.Write($"Введите {argName}: ");
    int number = 0;
    while (!int.TryParse(Console.ReadLine(), out number))
    {
        Console.WriteLine("Вы ввели не число! Введите число!!!");
    }
    return number;
}

void GetRandArr(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(1, 10);//[1; 10)
        }
    }
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[] SumArr(int[,] matrix)
{
    int[] sum = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum[i] += matrix[i, j];
        }
    }
    return sum;
}

int[,] DescArr(int[,] matrix)
{
    int temp;
    int minK;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            minK = 0;
            for (int k = 1; k < matrix.GetLength(1) - j; k++)
            {
                if (matrix[i, minK] > matrix[i, k])
                {
                    minK = k;
                }
            }
            temp = matrix[i, minK];
            matrix[i, minK] = matrix[i, matrix.GetLength(1) - j - 1];
            matrix[i, matrix.GetLength(1) - j - 1] = temp;
        }
    }
    return matrix;
}

void MinArrSum(int[] array)
{
    int min = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if (array[min] > array[i])
        {
            min = i;
        }
    }
    Console.WriteLine($"Наименьшая сумма элементов находится в {min + 1} строке");
}

void CompositionMatrix(int[,] a, int[,] b)
{
    if (a.GetLength(1) == b.GetLength(0))
    {
        int[,] c = new int[a.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < c.GetLength(0); i++)
        {
            for (int j = 0; j < c.GetLength(1); j++)
            {
                for (int k = 0; k < b.GetLength(0); k++)
                {
                    c[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        PrintMatrix(c);
    }
    else
    {
        System.Console.WriteLine("решение не возможно ");
    }
}

int[,] SpiralArray(int[,] array)
{
    int n = array.GetLength(0);
    int value = 1;
    int rowStart = 0;
    int rowEnd = n - 1;
    int colStart = 0;
    int colEnd = n - 1;

    while (value <= n * n)
    {
        for (int i = colStart; i <= colEnd; i++)
        {
            array[rowStart, i] = value;
            value++;
        }
        for (int i = rowStart + 1; i <= rowEnd; i++)
        {
            array[i, colEnd] = value;
            value++;
        }
        for (int i = colEnd - 1; i >= colStart; i--)
        {
            array[rowEnd, i] = value;
            value++;
        }
        for (int i = rowEnd - 1; i >= rowStart + 1; i--)
        {
            array[i, colStart] = value;
            value++;
        }
        rowStart++;
        rowEnd--;
        colStart++;
        colEnd--;
    }
    return array;
}

void GetRandTreeArr(int[,,] array)
{
    Random random = new Random();
    bool[] usedNumbs = new bool[90];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                do
                {
                    array[i, j, k] = random.Next(10, 100);
                }
                while (usedNumbs[array[i, j, k] - 10]);
                usedNumbs[array[i, j, k] - 10] = true;
                Console.Write($"{array[i, j, k]}\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

Console.WriteLine("Программа завершила работу");