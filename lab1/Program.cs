namespace RLab1;

class Program
{
    static void Main()
    {
        double[] array = { 2.5, -3.7, 1.8, 0, 5.2, -4.1, 6.3, -7.5, 9.0 }; // Пример входного массива

        // 1. Вычисляем произведение положительных элементов массива
        double positiveProduct = array.Where(x => x > 0).Aggregate(1.0, (current, x) => current * x);
        Console.WriteLine("Произведение положительных элементов массива: " + positiveProduct);

        // 2. Находим сумму элементов массива, расположенных до минимального элемента
        double minElement = array.Min();
        double sumBeforeMin = array.Take(Array.IndexOf(array, minElement)).Sum();
        Console.WriteLine("Сумма элементов до минимального элемента: " + sumBeforeMin);

        // 3. Упорядочиваем четные и нечетные элементы по возрастанию
        var evenSorted = array.Where((x, i) => i % 2 == 0).OrderBy(x => x).ToArray();
        var oddSorted = array.Where((x, i) => i % 2 != 0).OrderBy(x => x).ToArray();

        Console.WriteLine("Упорядоченные четные элементы: " + string.Join(", ", evenSorted));
        Console.WriteLine("Упорядоченные нечетные элементы: " + string.Join(", ", oddSorted));


        int[,] matrix = new int[,]
        {
            { 1, 2, 3, 0 },
            { 4, -5, 6, 7 },
            { 8, 9, 0, -10 },
            { -11, 12, 13, 14 }
        }; // Пример входной матрицы

        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        // 1. Находим количество отрицательных элементов в строках, содержащих хотя бы один нулевой элемент
        int negativeCount = 0;
        for (int i = 0; i < rows; i++)
        {
            bool containsZero = false;
            foreach (int element in matrix.Cast<int>().Skip(i * columns).Take(columns))
            {
                if (element == 0)
                {
                    containsZero = true;
                    break;
                }
            }

            if (containsZero)
            {
                negativeCount += matrix.Cast<int>().Skip(i * columns).Take(columns).Count(x => x < 0);
            }
        }

        Console.WriteLine("Количество отрицательных элементов в строках с нулями: " + negativeCount);

        // 2. Находим номера строк и столбцов седловых точек матрицы
        for (int i = 0; i < rows; i++)
        {
            int rowMax = matrix.GetLength(1) - 1;
            int columnMin = 0;

            for (int j = 0; j < columns; j++)
            {
                if (matrix[i, j] < matrix[i, rowMax])
                {
                    rowMax = j;
                }
            }

            bool isSaddlePoint = true;
            for (int k = 0; k < rows; k++)
            {
                if (matrix[k, rowMax] > matrix[i, rowMax])
                {
                    isSaddlePoint = false;
                    break;
                }
            }

            if (isSaddlePoint)
            {
                Console.WriteLine("Saddle point at: " + i + ", " + rowMax);
            }
        }
    }
}
