using System;

namespace _4_1_2
{
    internal class _4_1_2
    {
        static private int _matrixStringNumber;
        static private int _matrixColumnNumber;
        static private int _sumMatrixElements;
        static private bool _isItRandomMatrix = true;

        static private int[,] _firstRandomMatrix;
        static private int[,] _secondRandomMatrix;
        static private int[,] _thirdMatrix;

        static private string _userInputString;
        static private bool _isUserInputCorrect;

        static private Random random = new Random();

        static void Main()
        {
            Console.WriteLine("Случайная матрица\n");
            Console.WriteLine("Введите количество строк в будущей матрице");
            UserStringInput(ref _matrixStringNumber);
            Console.WriteLine("\nВведите количество столбцов в будущей матрице");
            UserStringInput(ref _matrixColumnNumber);
            Console.WriteLine("\nВаша матрица№1:\n");
            MatrixGenerate(ref _firstRandomMatrix);
            Console.WriteLine("\nВаша матрица№2:\n");
            MatrixGenerate(ref _secondRandomMatrix);
            Console.WriteLine("\nСложение матриц:\n");
            _isItRandomMatrix = false;
            MatrixGenerate(ref _thirdMatrix);
            Console.ReadLine();
        }
        /// <summary>
        /// Пользовательский ввод и его проверка на корректность
        /// </summary>
        /// <param name="requiredData"></param>
        static void UserStringInput(ref int requiredData)
        {
            _isUserInputCorrect = false;

            while (!_isUserInputCorrect)
            {
                _userInputString = Console.ReadLine();

                if (int.TryParse(_userInputString, out int result) && result > 0) //Преобразуется ли строка в число
                {
                    requiredData = result;
                    _isUserInputCorrect = true;
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректные данные! Повторите ввод");
                }
            }
        }
        /// <summary>
        /// Универсальный генератор матрицы
        /// </summary>
        /// <param name="matrix"></param>
        static void MatrixGenerate(ref int[,] matrix)
        {
            _sumMatrixElements = 0;
            matrix = new int[_matrixStringNumber, _matrixColumnNumber];

            for (int stringIndex = 0; stringIndex < _matrixStringNumber; stringIndex++)
            {
                for (int columnIndex = 0; columnIndex < _matrixColumnNumber; columnIndex++)
                {
                    //Дополнительное условие на то, рандомно ли генерируется матрица или это будет сложение матриц
                    if (_isItRandomMatrix)
                    {
                        matrix[stringIndex, columnIndex] = random.Next(10);
                    }
                    else
                    {
                        //сложение матриц сделано под конкретную задачу, с жёстко заданными матрицами
                        matrix[stringIndex, columnIndex] =
                            _firstRandomMatrix [stringIndex, columnIndex] + _secondRandomMatrix[stringIndex, columnIndex];
                    }

                    Console.Write($"{matrix[stringIndex, columnIndex],3}"); //вывод матрицы на экран

                    _sumMatrixElements += matrix[stringIndex, columnIndex]; // подсчёт суммы матрицы
                }

                Console.WriteLine("\n");
            }

            Console.Write($"Сумма всех элементов матрицы: {_sumMatrixElements}");
        }
    }
}
