using System;

namespace Matrix
{
    partial class Program
    {
        /// <summary>
        /// Выбор возможной операции.
        /// </summary>
        static void Menu()
        {
            Console.WriteLine("\t[1] Нахождение следа матрицы;");
            Console.WriteLine("\t[2] Транспонирование матрицы;");
            Console.WriteLine("\t[3] Сумма двух матриц;");
            Console.WriteLine("\t[4] Разность двух матриц;");
            Console.WriteLine("\t[5] Произведение двух матриц;");
            Console.WriteLine("\t[6] Умножение матрицы на число;");
            Console.WriteLine("\t[7] Нахождение определителя матрицы;");
            Console.WriteLine("\t[8] Решение СЛАУ методом Гаусса или Крамера;");
            Console.WriteLine("\nДля выбора операции нажмите соответствующую [клавишу] ( цифру от 1 до 8 ).");
            Console.WriteLine("Для выхода из программы нажмите [Escape].");
            ConsoleKeyInfo key = Console.ReadKey(true);
            // Запрос на выбор до тех пор, пока пользователь не нажмет нужную клавишу.
            while(!((((int)key.KeyChar>48)&((int)key.KeyChar<57))||(key.Key==ConsoleKey.Escape)))
            {
                Console.WriteLine("\n\tОшибка! Нажмите клавишу [1], [2], ... , [8] или [Escape].");
                key = Console.ReadKey(true);
            }
            try
            {
                if(key.Key!=ConsoleKey.Escape)
                {
                    switch (key.KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            Console.WriteLine("\n\tНахождение следа матрицы:");
                            Trace();
                            break;
                        case '2':
                            Console.Clear();
                            Console.WriteLine("\n\tТранспонирование матрицы:");
                            Transposition();
                            break;
                        case '3':
                            Console.Clear();
                            Console.WriteLine("\n\tСумма двух матриц:");
                            SumOfTwo(1);
                            break;
                        case '4':
                            Console.Clear();
                            Console.WriteLine("\n\tРазность двух матриц:");
                            SumOfTwo(-1);
                            break;
                        case '5':
                            Console.Clear();
                            Console.WriteLine("\n\tПроизведение двух матриц:");
                            Composition();
                            break;
                        case '6':
                            Console.Clear();
                            Console.WriteLine("\n\tУмножение матрицы на число:");
                            MultiplyByNumber();
                            break;
                        case '7':
                            Console.Clear();
                            Console.WriteLine("\n\tНахождение определителя матрицы:");
                            Console.WriteLine("\nОпределитель матрицы = {0:F3}.", Determinant(InputSquareMatrix()));
                            break;
                        case '8':
                            Console.Clear();
                            Console.WriteLine("\n\tРешение СЛАУ методом Крамера:");
                            KramerMethod();
                            break;
                        default:
                            break;
                    }
                    // Повтор решения или выход из программы после выполнения операции.
                    ContinueWork();
                }
            }
            // Вывод сообщения об исключении при его обнаружении.
            catch(Exception e)
            {
                Console.WriteLine("\n\t Ошибка {0}.", e.Message);
            }
        }
        /// <summary>
        /// Подсчет следа квадратной матрицы.
        /// </summary>
        static void Trace()
        {
            int i = 0;
            double trace = 0;
            // Получение квадратной матрицы.
            double[,] matrix = InputSquareMatrix();
            if (matrix!=null)
            {
                // Вычисления произведения элементов на главной диагонали.
                while (i < matrix.GetLength(0))
                {
                    trace += matrix[i, i];
                    i++;
                }
                Console.WriteLine("\n\nСлед матрицы = {0:F3}", trace);
            }
        }
        /// <summary>
        /// Транспозиция матрицы.
        /// </summary>
        static void Transposition()
        {
            // Получение прямоугольной ( квадратной ) матрицы.
            double[,] matrix = InputMatrix();
            Console.WriteLine("\nТранспонированная матрица:\n");
            if(matrix!=null)
            {
                // Транспонирование матрицы.
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        Console.Write("{0,10} ", matrix[j, i]);
                    }
                }
            }
        }
        /// <summary>
        /// Сложение двух матриц.
        /// </summary>
        /// <param name="sgn"> Знак + для сложения двух матриц, знак - для вычитания двух матриц. </param>
        static void SumOfTwo(int sgn)
        {
            // Получение двух матриц.
            double[,] matrix1 = InputMatrix();
            double[,] matrix2 = InputMatrix();
            int x, y;
            if((matrix1!=null)&&(matrix2!=null))
            {
                // Проверка, что матрицы одного размера.
                if ((matrix1.GetLength(0) == matrix2.GetLength(0)) && (matrix1.GetLength(1) == matrix2.GetLength(1)))
                {
                    x = matrix1.GetLength(0);
                    y = matrix1.GetLength(1);
                    double[,] result = new double[x, y];
                    // Выполнение нужной арифметической операции.
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            result[i, j] = Math.Round(matrix1[i, j] + sgn * matrix2[i, j], 3);
                        }
                    }
                    Console.WriteLine("\nРезультат операции:\n");
                    OutputMatrix(x, y, result);
                }
                else
                {
                    Console.WriteLine("\n\tОшибка! Матрицы должны быть одного размера.");
                }
            }
        }
        /// <summary>
        /// Произведение двух матриц.
        /// </summary>
        static void Composition()
        {
            // Получение матриц.
            double[,] matrix1 = InputMatrix();
            double[,] matrix2 = InputMatrix();
            if ((matrix1 != null)&&(matrix2!=null))
            {
                // Проверка, что кол-во столбцов первой матрицы = кол-ву строк второй матрицы.
                if (matrix1.GetLength(1) == matrix2.GetLength(0))
                {
                    int x = matrix1.GetLength(0), y = matrix2.GetLength(1), z = matrix1.GetLength(1); ;
                    double[,] result = new double[x, y];
                    // Выполнение арифметической операции.
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            for (int g = 0; g < z; g++)
                            {
                                result[i, j] += matrix1[i, g] * matrix2[g, j];
                            }
                        }
                    }
                    Console.WriteLine("\nРезультат операции:");
                    OutputMatrix(x, y, result);
                }
                else
                {
                    Console.WriteLine("\n\tОшибка! Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
                }
            }
        }
        /// <summary>
        /// Умножение матрицы на число.
        /// </summary>
        static void MultiplyByNumber()
        {
            double k;
            // Получение числа, на которое нужно умножить матрицу.
            Console.Write("\nВведите число, на которое нужно умножить матрицу: ");
            while(!double.TryParse(Console.ReadLine(),out k))
            {
                Console.Write("\n\tОшибка! Невозможно преобразовать ввод в число.\n\nВведите число, на которое нужно умножить матрицу: ");
            }
            // Получение матрицы.
            double[,] matrix = InputMatrix();
            if(matrix!=null)
            {
                // Выполнение арифметической операции.
                Console.WriteLine("\nРезультат умножения матрицы на число: ");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write("{0,10}", Math.Round(matrix[i, j] * k, 3));
                    }
                }
            }
        }
        /// <summary>
        /// Вычисление определителя матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица, у которой нужно вычислить определитель. </param>
        /// <returns> Определитель полученной матрицы. </returns>
        static double Determinant(double[,] matrix)
        {
            int i = 0, j = 0, x = matrix.GetLength(0), sgn = 1;
            // Приведение матрицы к ступенчатому виду методом Гаусса.
            while (i < x && j < x)
            {
                if (matrix[i, j] != 0)
                {
                    for (int g = i + 1; g < x; g++)
                    {
                        if (matrix[g, j] != 0)
                        {
                            double coefficient = -(matrix[g, j] / matrix[i, j]);
                            for (int f = 0; f < x; f++)
                            {
                                matrix[g, f] += coefficient * matrix[i, f];
                            }
                        }
                    }
                    i++;
                    j++;
                }
                else
                {
                    int g = i + 1;
                    while ((g < x) && (matrix[g, j] == 0))
                    {
                        g++;
                    }
                    if (g < x)
                    {
                        for (int f = 0; f < x; f++)
                        {
                            double element = matrix[i, f];
                            matrix[i, f] = matrix[g, f];
                            matrix[g, f] = element;
                            // Меняем знак определителя, когда меняем строки местами.
                            sgn *= (-1);
                        }
                    }
                    else
                    {
                        i++;
                        j++;
                    }
                }
            }
            double determinant = 1;
            // Вычисление определителя = произведению элементов на главной диагонали нижнетреугольной матрицы.
            for (i = 0; i < x; i++)
            {
                determinant *= matrix[i, i];
            }
            determinant *= sgn;
            return determinant;
        }
        /// <summary>
        /// Метод Крамера для решения СЛАУ.
        /// </summary>
        static void KramerMethod()
        {
            // Получение расширенной матрицы системы.
            double[,] matrix = InputEquation();
            if (matrix!=null)
            {
                int x = matrix.GetLength(0), y = matrix.GetLength(1);
                double[,] coefficients = new double[x, y - 1];
                double[,] determinant = new double[x, y - 1];
                // Записываем матрицу системы отдельно.
                for (int i = 0; i<x;i++)
                {
                    for (int j=0;j<y-1;j++)
                    {
                        coefficients[i, j] = matrix[i, j];
                        determinant[i, j] = matrix[i, j];
                    }
                }
                // Вычисляем определитель матрицы системы.
                double det = Determinant(coefficients);
                // Проверка, равен ли определитель матрицы системы нулю.
                if(det!=0)
                {
                    Console.Write("\nРешение СЛАУ:\n");
                    // Поочередно находим значение каждой из переменных.
                    for(int m=0;m<y-1;m++)
                    {
                        // Заменяем столбец в матрице системы столбцом свободных членов и находим его определитель.
                        double[,] variableMatrix = new double[x,y-1];
                        for (int i = 0; i < x; i++)
                        {
                            for (int j = 0; j < y - 1; j++)
                            {
                                variableMatrix[i, j] = determinant[i, j];
                            }
                        }
                        for (int i = 0; i < x; i++)
                        {
                            variableMatrix[i, m] = matrix[i, y - 1];
                        }
                        double detX = Determinant(variableMatrix);
                        // Формула Крамера.
                        Console.Write("x{0} = {1} ", m + 1, Math.Round(detX / det, 3));
                    }
                }
                else
                {
                    Console.WriteLine("\n\tОшибка! Решение методом Крамера невозможно, так как определитель матрицы системы = 0.");
                }
            }
        }
    }
}
