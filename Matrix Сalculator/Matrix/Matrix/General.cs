using System;
using System.IO;

namespace Matrix
{
    partial class Program
    {
        /// <summary>
        /// ContinueWork нужен для повтора решения ( выбора другой операции ) и выхода из программы.
        /// </summary>
        static void ContinueWork()
        {
            Console.WriteLine("\nНажмите [Backspace] для выбора другой операции.");
            Console.WriteLine("\nНажмите любую другую клавишу для выхода из программы.");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Backspace:
                    Console.Clear();
                    Main();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        /// <summary>
        /// OutputMatrix выводит матрицу в консоль.
        /// </summary>
        /// <param name="x">Кол-во строк в матрице.</param>
        /// <param name="y">Кол-во столбцов в матрице.</param>
        /// <param name="matrix">Матрица, которую нужно вывести в консоль.</param>
        static void OutputMatrix(int x, int y, double[,] matrix)
        {
            for (int i = 0; i < x; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < y; j++)
                {
                    Console.Write("{0,10} ", Math.Round(matrix[i, j],3));
                }
            }
        }
        /// <summary>
        /// Получение входных данных ( прямоугольной ( квадратной ) матрицы ).
        /// </summary>
        /// <returns> Полученная матрица в виде массива. </returns>
        static double[,] InputMatrix()
        {
            Console.WriteLine("\nВходные данные ( размерность матрицы и её содержимое ) :\n");
            Console.WriteLine("\t[1] Генерация данных случайным образом;");
            Console.WriteLine("\t[2] Ввод данных с консоли;");
            Console.WriteLine("\t[3] Считывание данных из файла;");
            Console.WriteLine("\nНажмите [1], [2] или [3], чтобы выбрать, каким способом задать входные данные.");
            // Выбор способа получения входных данных ( до тех пор, пока пользователь не нажмет верную клавишу ).
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (!((key.KeyChar == '1') || (key.KeyChar == '2') || (key.KeyChar == '3')))
            {
                Console.WriteLine("\n\tОшибка! Нажмите [1], [2] или [3], чтобы выбрать, каким способом задать входные данные.");
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                // Получение размерности и последующая генерация матрицы.
                case '1':
                    int[] dimension = new int[2];
                    dimension = DimensionGenerate();
                    return GenerateMatrix(dimension[0], dimension[1]);
                // Ввод размерности и заполнение матрицы с клавиатуры.
                case '2':
                    int[] demension = new int[2];
                    dimension = DimensionConsole();
                    return MatrixConsole(dimension[0], dimension[1]);
                // Получение матрицы из файла.
                case '3':
                    Console.WriteLine("\nВведите абсолюный путь к текстовому файлу, в котором находится матрица ( размерность будет определена автоматически ) : ");
                    return MatrixFromFile();
                default:
                    return null;
            }
        }
        /// <summary>
        /// Получение входных данных ( квадратной матрицы ).
        /// </summary>
        /// <returns> Полученная квадратная матрица в виде массива. </returns>
        static double[,] InputSquareMatrix()
        {
            Console.WriteLine("\nВходные данные ( размерность квадратной матрицы и её содержимое ) :\n");
            Console.WriteLine("\t[1] Генерация данных случайным образом;");
            Console.WriteLine("\t[2] Ввод данных с консоли;");
            Console.WriteLine("\t[3] Считывание данных из файла;");
            Console.WriteLine("\nНажмите [1], [2] или [3], чтобы выбрать, каким способом задать входные данные.");
            // Выбор способа получения входных данных ( до тех пор, пока пользователь не нажмет верную клавишу ).
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (!((key.KeyChar == '1') || (key.KeyChar == '2') || (key.KeyChar == '3')))
            {
                Console.WriteLine("\n\tОшибка! Нажмите [1], [2] или [3], чтобы выбрать, каким способом задать входные данные.");
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                // Получение размерности и последующая генерация квадратной матрицы.
                case '1':
                    int dimension;
                    dimension = DimensionSquareGenerate();
                    return GenerateMatrix(dimension, dimension);
                // Ввод размерности и заполнение квадратной матрицы с клавиатуры.
                case '2':
                    dimension = DimensionConsoleSquare();
                    return MatrixConsole(dimension, dimension);
                // Получение матрицы из файла.
                case '3':
                    Console.WriteLine("\nВведите абсолюный путь к текстовому файлу, в котором находится квадратная матрица ( размерность будет определена автоматически ) : ");
                    double[,] matrix = MatrixFromFile();
                    if (matrix!=null)
                    {
                        // Проверка, что полученная из файла матрица является квадратной.
                        if (matrix.GetLength(0) == matrix.GetLength(1))
                        {
                            return matrix;
                        }
                        else
                        {
                            Console.WriteLine("\n\tОшибка! Полученная из файла матрица не квадратная.");
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                default:
                    return null;
            }
        }
        /// <summary>
        /// Получение размерности прямоугольной ( квадратной ) матрицы.
        /// </summary>
        /// <returns> Массив из двух чисел - кол-во строк и столбцов в матрице. </returns>
        static int[] DimensionGenerate()
        {
            Console.WriteLine("\nРазмерность матрицы:\n");
            Console.WriteLine("\t[1] Ввести с клавиатуры;");
            Console.WriteLine("\t[2] Сгенерировать;");
            Console.WriteLine("\nНажмите [1] или [2], чтобы выбрать, каким способом задать размерность матрицы.");
            // Выбор способа получения размерности матрицы ( до тех пор, пока пользователь не нажмет верную клавишу ).
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (!((key.KeyChar == '1') || (key.KeyChar == '2')))
            {
                Console.WriteLine("\n\tОшибка! Нажмите [1] или [2], чтобы выбрать, каким способом задать размерность матрицы.");
                key = Console.ReadKey(true);
            }
            int[] dimension = new int[2];
            switch (key.KeyChar)
            {
                // Ввод размерности с клавиатуры.
                case '1':
                    return DimensionConsole();
                // Генерация размерности матрицы.
                case '2':
                    Console.WriteLine("\nЧисло строк в матрице:");
                    dimension[0] = RangeDimension();
                    Console.WriteLine("\nЧисло столбцов в матрице:");
                    dimension[1] = RangeDimension();
                    return dimension;
                default:
                    return null;
            }
        }
        /// <summary>
        /// Получение размерности квадратной матрицы.
        /// </summary>
        /// <returns> Число, соответствующее размерности квадратной матрицы. </returns>
        static int DimensionSquareGenerate()
        {
            Console.WriteLine("\nРазмерность матрицы:\n");
            Console.WriteLine("\t[1] Ввести с клавиатуры;");
            Console.WriteLine("\t[2] Сгенерировать;");
            Console.WriteLine("\nНажмите [1] или [2], чтобы выбрать, каким способом задать размерность матрицы.");
            // Выбор способа получения размерности матрицы ( до тех пор, пока пользователь не нажмет верную клавишу ).
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (!((key.KeyChar == '1') || (key.KeyChar == '2')))
            {
                Console.WriteLine("\n\tОшибка! Нажмите [1] или [2], чтобы выбрать, каким способом задать размерность матрицы.");
                key = Console.ReadKey(true);
            }
            int dimension = 0;
            switch (key.KeyChar)
            {
                // Ввод размерности с клавиатуры.
                case '1':
                    return DimensionConsoleSquare();
                // Генерация размерности квадратной матрицы.
                case '2':
                    Console.WriteLine("\nЧисло строк ( столбцов ) в матрице:");
                    dimension = RangeDimension();
                    return dimension;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Ввод размерности прямоугольной ( квадратной ) матрицы с клавиатуры.
        /// </summary>
        /// <returns> Массив из двух чисел - кол-во строк и столбцов в матрице. </returns>
        static int[] DimensionConsole()
        {
            int[] dimension = new int[2];
            int x, y;
            // Получение кол-ва строк в матрице ( натуральное число от 1 до 10 ) до тех пор, пока пользователь не введет верное число.
            Console.Write("\nВведите количество строк в матрице ( число должно быть натуральным ) :");
            while (!(int.TryParse(Console.ReadLine(), out x) && (x > 0)&&(x<=10)))
            {
                Console.Write("\n\tОшибка! Вы должны ввести натуральное число от 1 до 10: ");
            }
            // Получение кол-ва столбцов в матрице ( натуральное число от 1 до 10 ) до тех пор, пока пользователь не введет верное число.
            Console.Write("\nВведите количество столбцов в матрице ( число должно быть натуральным ) :");
            while (!(int.TryParse(Console.ReadLine(), out y) && (y > 0)&&(y<=10)))
            {
                Console.Write("\n\tОшибка! Вы должны ввести натуральное число от 1 до 10: ");
            }
            dimension[0] = x;
            dimension[1] = y;
            return dimension;
        }
        /// <summary>
        /// Ввод размерности квадратной матрицы с клавиатуры.
        /// </summary>
        /// <returns> Число, соответствующее размерности квадратной матрицы. </returns>
        static int DimensionConsoleSquare()
        {
            int dimension;
            // Получение размерности квадратной матрицы ( натуральное число от 1 до 10 ) до тех пор, пока пользователь не введет верное число.
            Console.Write("\nВведите количество строк ( столбцов ) в квадратной матрице ( число должно быть натуральным ) :");
            while (!(int.TryParse(Console.ReadLine(), out dimension) && (dimension > 0)&&(dimension<=10)))
            {
                Console.Write("\n\tОшибка! Вы должны ввести натуральное число от 1 до 10: ");
            }
            return dimension;
        }
        /// <summary>
        /// Получение диапазона чисел для генерации содержимого матрицы.
        /// </summary>
        /// <returns> Массив из двух чисел - границы диапазона для генерации. </returns>
        static int[] RangeMatrix()
        {
            int a, b;
            Console.WriteLine("\nВведите диапазон для генерации чисел в матрице:");
            // Нижняя граница диапазона.
            Console.Write("\n\tНижний предел ( включенный в диапазон ) - целое число:");
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("\n\tОшибка! Вы должны ввести целое число: ");
            }
            // Верхняя граница диапазона, больше либо равная нижней границе.
            Console.Write("\n\tВерхний предел ( не включенный в диапазон ) - целое число: ");
            while (!(int.TryParse(Console.ReadLine(), out b)&&(b>=a)))
            {
                Console.Write("\n\tОшибка! Вы должны ввести целое число >= нижнего предела: ");
            }
            int[] range = new int[] { a, b };
            return range;
        }
        /// <summary>
        /// Получение диапазона чисел для генерации размерности матрицы.
        /// </summary>
        /// <returns> Массив из двух чисел - границы диапазона для генерации. </returns>
        static int RangeDimension()
        {
            int a, b;
            Console.WriteLine("\nВведите диапазон для генерации числа:");
            // Нижняя граница - натуральное число от 1 до 10.
            Console.Write("\n\tНижний предел ( включенный в диапазон ) - натуральное число от 1 до 10:");
            while (!(int.TryParse(Console.ReadLine(), out a) && (a > 0)&&(a<=10)))
            {
                Console.Write("\n\tОшибка! Вы должны ввести натуральное число: ");
            }
            // Верхняя граница - натуральное число от 1 до 10, больше либо равная нижней границе.
            Console.Write("\n\tВерхний предел ( не включенный в диапазон ) - натуральное число от 1 до 10: ");
            while (!(int.TryParse(Console.ReadLine(), out b) && (b > 0)&&(b>=a)&&(b<=10)))
            {
                Console.Write("\n\tОшибка! Вы должны ввести натуральное число: ");
            }
            return NaturalNumber(a, b);
        }
        /// <summary>
        /// Генерация натурального числа ( размерности матрицы ).
        /// </summary>
        /// <param name="a"> Нижний предел для генерации числа. </param>
        /// <param name="b"> Верхний предел для генирации числа. </param>
        /// <returns> Сгенерированное натуральное число. </returns>
        static int NaturalNumber(int a, int b)
        {
            Random number = new Random();
            int x = number.Next(a, b);
            // Возможность сгенерировать другое число.
            Console.WriteLine("\nСгенерировано число: {0}", x);
            Console.WriteLine("\nНажмите [Enter], если число Вас не устраивает и Вы хотите сгенерировать другое.");
            Console.WriteLine("Нажмите [Backspace], если Вы хотите выбрать другой диапазон и сгенерировать число заново.");
            Console.WriteLine("Нажмите любую другую клавишу, чтобы продолжить");
            switch (Console.ReadKey(true).Key)
            {
                // Генерация другого числа в том же диапазоне.
                case ConsoleKey.Enter:
                    return NaturalNumber(a, b);
                // Генерация другого числа в другом диапазоне.
                case ConsoleKey.Backspace:
                    return RangeDimension();
                default:
                    return x;
            }
        }
        /// <summary>
        /// Генерирование содержимого матрицы.
        /// </summary>
        /// <param name="x"> Кол-во строк в матрице. </param>
        /// <param name="y"> Кол-во столбцов в матрице. </param>
        /// <returns> Сгенерированная матрица. </returns>
        static double[,] GenerateMatrix(int x, int y)
        {
            // Получение диапазона для генерации чисел в матрице.
            int[] range = RangeMatrix();
            Random number = new Random();
            double[,] matrix = new double[x, y];
            // Генерация элементов матрицы в полученном диапазоне с рандомным округлением, для заполнения как целыми, так и дробными числами.
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = Math.Round(number.Next(range[0], range[1]) + number.NextDouble(), number.Next(0, 3));
                }
            }
            // Вывод сгенерированной матрицы в консоль.
            Console.WriteLine("\nВы сгенерировали матрицу {0}x{1} :", x, y);
            OutputMatrix(x, y, matrix);
            return matrix;
        }
        /// <summary>
        /// Заполнение матрицы с клавиатуры.
        /// </summary>
        /// <param name="x"> Кол-во строк в матрице. </param>
        /// <param name="y"> Кол-во столбцов в матрице. </param>
        /// <returns> Полученная матрица. </returns>
        static double[,] MatrixConsole(int x, int y)
        {
            double[,] matrix = new double[x, y];
            for (int i = 0; i < x; i++)
            {
                // Построчный ввод элементов матрицы.
                Console.Write("\nВведите {0} элементов ( элемента ) строки {1} через пробел: ", y, i + 1);
                string[] row = Console.ReadLine().Trim(' ').Split(' ');
                for (int j = 0; j < y; j++)
                {
                    // Проверка, что в строках необходимое кол-во элементов и что введенные элементы можно преобразовать в числа.
                    if((row.Length==y)&&double.TryParse(row[j],out double element))
                    {
                        matrix[i, j] = element;
                    }
                    else
                    {
                        Console.WriteLine("\n\tОшибка! Проверьте корректность введенных элементов в строке.");
                        i--;
                        break;
                    }
                }
            }
            // Вывод полученной матрицы в консоль.
            Console.WriteLine("\nВы ввели матрицу {0}x{1} :", x, y);
            OutputMatrix(x, y, matrix);
            return matrix;
        }
       /// <summary>
       /// Получение матрицы из файла.
       /// </summary>
       /// <returns> Полученная матрица. </returns>
        static double[,] MatrixFromFile()
        {
            // Получение пути к файлу, где находится матрица.
            string path = Console.ReadLine();
            int x = 0, y;
            // Проверка, что файл существует и что он текстовый.
            if(File.Exists(path))
            {
                if(Path.GetExtension(path)==".txt")
                {
                    string[] textFile = File.ReadAllLines(path);
                    y = textFile[1].Trim(' ').Split(' ').Length;
                    // Построчное считывание матрицы из файла.
                    foreach(string line in textFile)
                    {
                        // Подсчёт кол-ва строк в переменной x, запись элементов очередной строки в массив row.
                        x++;
                        string[] row = line.Trim(' ').Split(' ');
                        // Проверка, что во всех строках одинаковое кол-во элементов.
                        if (y!=row.Length)
                        {
                            Console.WriteLine("\n\tОшибка! Количество элементов в строках различно.");
                            ContinueWork();
                            return null;
                        }
                        y = row.Length;
                    }
                    // Создание матрицы и проверка, что все элементы можно преобразовать в числа.
                    double[,] matrix = new double[x, y];
                    int i = 0;
                    foreach(string line in textFile)
                    {
                        string[] row = line.Split(' ');
                        for(int j=0;j<y;j++)
                        {
                            if(double.TryParse(row[j],out double element))
                            {
                                matrix[i, j] = element;
                            }
                            else
                            {
                                Console.WriteLine("\n\tОшибка! Проверьте корректность элементов матрицы ( невозможно преобразовать к числу ).");
                                ContinueWork();
                                return null;
                            }
                        }
                        i++;
                    }
                    // Вывод полученной матрицы в консоль.
                    Console.WriteLine("\nИз файла получена матрица {0}x{1} :", x, y);
                    OutputMatrix(x, y, matrix);
                    return matrix;
                }
                else
                {
                    Console.WriteLine("\n\tОшибка! Файл должен быть текстовым.");
                    ContinueWork();
                    return null;
                }
            }
            else
            {
                Console.WriteLine("\n\tОшибка! Такого файла не существует.");
                ContinueWork();
                return null;
            }
        }
        /// <summary>
        /// Получение СЛАУ.
        /// </summary>
        /// <returns> Расширенная матрица системы. </returns>
        static double[,] InputEquation()
        {
            // Получение расширенной матрицы системы.
            Console.WriteLine("Введите расширенную матрицу системы уравнений ( для решения методом Крамера кол-во неизвестных = кол-ву уравнений ) :");
            double[,] matrix = InputMatrix();
            // Проверка, что кол-во столбцов больше 1 и что кол-во столбцов на 1 больше кол-ва строк ( для решения методом Крамера ).
            if((matrix.GetLength(1)>1)&&(matrix.GetLength(0)+1==matrix.GetLength(1)))
            {
                // Вывод полученной СЛАУ в консоль.
                Console.WriteLine("\nПолученная СЛАУ:");
                int variables = matrix.GetLength(1) - 1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < variables; j++)
                    {
                        // Запись НЕ первой переменной в уравнении с арифметическим знаком.
                        if (j != 0)
                        {
                            // Выбор знака перед переменной в зависимости от знака коэффициента.
                            if (matrix[i, j] >= 0)
                            {
                                Console.Write("+ {0}*x{1} ", matrix[i, j], j + 1);
                            }
                            else
                            {
                                Console.Write("- {0}*x{1} ", matrix[i, j] * (-1), j + 1);
                            }
                        }
                        // Запись первой переменной в уравнении без арифметического знака.
                        else
                        {
                            Console.Write("{0}*x{1} ", matrix[i, j], j + 1);
                        }
                    }
                    Console.Write("= {0}", matrix[i, variables]);
                }
                return matrix;
            }
            else
            {
                Console.WriteLine("\n\tОшибка! В расширенной матрице системы уравнений должно быть больше одного столбца, кол-во неизвестных должно быть равно кол-ву уравнений.");
                return null;
            }
        }
    }
}
