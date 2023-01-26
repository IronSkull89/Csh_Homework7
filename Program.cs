using System.Data.Common;
using System.Threading.Tasks;

int countTasks = 3;
int task;

string[] tasks = new string[countTasks];
tasks[0] = "1. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.";
tasks[1] = "2. Программа, которая на вход принимает число, и проверяет есть ли такое число в двумерном массиве,\r\nа также возвращает сообщение о том, что оно найдено или же указание, что такого элемента нет.";
tasks[2] = "3. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.";
int SelectionTask(string[] tasks, int countTasks)
{
    for (int i = 0; i < countTasks; i++)
    {
        Console.WriteLine(tasks[i]);
    }

    Console.Write($"Выберите задачу (от 1 до {countTasks}): ");
    if (!int.TryParse(Console.ReadLine(), out int task) || task > countTasks || task < 1)
    {
        Console.Clear();
        task = SelectionTask(tasks, countTasks);
    }
    return task;
}

int[,] CreateRandomInt2DArray(int row, int column, int minValue, int maxValue)
{
    int[,] array = new int[row, column];

    if (minValue > maxValue) 
    {
        int temp = minValue;
        minValue = maxValue;
        maxValue = temp;
    }

    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(minValue, maxValue + 1);
        }
    }
    return array;
}

double[,] CreateRandomDouble2DArray(int row, int column, double minValue, double maxValue)
{
    double[,] array = new double[row, column];

    if (minValue > maxValue)
    {
        double temp = minValue;
        minValue = maxValue;
        maxValue = temp;
    }

    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
    return array;
}

void PrintDoubleArray1D(double[] array, int digits)
{
    int widthColumn = GetMaxLengthDoubleItem1DArray(array) + digits + 2;

    foreach (var item in array)
    {
        Console.Write(String.Format("{0," + widthColumn + "}", Math.Round(item, digits)));
    }
}

void PrintIntArray2D(int[,] array, int interval)
{
    int widthColumn = GetMaxLengthIntItem2DArray(array) + interval;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(String.Format("{0," + widthColumn + "}", array[i, j]));
        }
        Console.WriteLine();
    }
}

void PrintDoubleArray2D(double[,] array, int digits)
{
    int widthColumn = GetMaxLengthDoubleItem2DArray(array) + digits + 2;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(String.Format("{0," + widthColumn + "}", Math.Round(array[i, j], digits)));
        }
        Console.WriteLine();
    }
}

int GetMaxLengthDoubleItem1DArray(double[] array)
{
    int maxLength = 0;
    int itemLength = 0;

    for (int i = 0; i < array.Length; i++)
    {
        itemLength = Convert.ToInt32(array[i]).ToString().Length;
        if (maxLength < itemLength) maxLength = itemLength;
    }
    return maxLength;
}

int GetMaxLengthIntItem2DArray(int[,] array)
{
    int maxLength = 0;
    int itemLength = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            itemLength = array[i, j].ToString().Length;
            if (maxLength < itemLength) maxLength = itemLength;
        }
    }
    return maxLength;
}

int GetMaxLengthDoubleItem2DArray(double[,] array)
{
    int maxLength = 0;
    int itemLength = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            itemLength = Convert.ToInt32(array[i, j]).ToString().Length;
            if (maxLength < itemLength) maxLength = itemLength;
        }
    }
    return maxLength;
}


// Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
int SetNumber(string greet)
{
    Console.Write(greet);
    if (!int.TryParse(Console.ReadLine(), out int number)) number = SetNumber(greet);
    return number;
}

// Напишите программу, которая на вход принимает число, и проверяет есть ли такое число в двумерном массиве,
//   а также возвращает сообщение о том, что оно найдено или же указание, что такого элемента нет.
int[] FindInArray2D(int[,] array, int number)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (number == array[i, j]) return new int[] { i, j };
        }
    }
    return new int[] { -1, -1 };
}

// Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
double[] AverageColumns(int[,] array)
{
    int countRow = array.GetLength(0);
    int countColumn = array.GetLength(1);
    double[] average = new double[countColumn];
    int sum;
    for (int j = 0; j < countColumn; j++)
    {
        sum = 0;
        for (int i = 0; i < countRow; i++)
        {
            sum += array[i, j];
        }
        average[j] = Convert.ToDouble(sum) / countRow;
    }
    return average;
}

//--------------------------------------------
string? working = "Y";
while (working.ToLower() == "Y".ToLower())
{
    Console.Clear();
    task = SelectionTask(tasks, countTasks);
    if (task == 1)
    {
        int countRow = SetNumber("Введите количество строк в массиве: ");
        int countColumn = SetNumber("Введите количество столбцов в массиве: ");
        PrintDoubleArray2D(CreateRandomDouble2DArray(countRow, countColumn, -10, 10), 2);
    }
    else if (task == 2)
    {
        int[,] array2 = CreateRandomInt2DArray(6, 6, -10, 10);
        PrintIntArray2D(array2, 2);
        int findNumber = SetNumber("Введите искомое число: ");
        int[] findIndex = FindInArray2D(array2, findNumber);

        if (findIndex[0] == -1) Console.WriteLine($"Число {findNumber} не найдено");
        else Console.WriteLine($"Число {findNumber} находится на позиции ({String.Join(",", findIndex)})");
    }
    else if (task == 3)
    {
        int countRow = 4;
        int countColumn = 6;
        int digits = 3;
        int interval = digits + 1;
        int[,] array3 = CreateRandomInt2DArray(countRow, countColumn, 0, 10);
        PrintIntArray2D(array3, interval);
        double[] averageColumn = AverageColumns(array3);
        Console.Write("   ");
        for (int i = 0; i < countColumn; i++)
        {
            Console.Write($"Av({i}) ");
        }
        Console.WriteLine();
        PrintDoubleArray1D(averageColumn, digits);
        Console.WriteLine();
    }

    Console.WriteLine("Введите 'Y' для продолжения или любой другой символ для закрытия...");
    working = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(working))
    {
        working = "n";
    }
}