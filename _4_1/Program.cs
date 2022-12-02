using System;

namespace _4_1
{
    internal class Program
    {
        static private int _matrixStringNumber;
        static private int _matrixColumnNumber;
        static private int _sumMatrixElements;
        static private string _userInputString;
        static private int[,] _randomMatrix;
        static private bool _isUserInputCorrect;

        static void Main()
        {
            Console.WriteLine("Случайная матрица\n");
            Console.WriteLine("Введите количество строк в будущей матрице");
            UserStringInput(ref _matrixStringNumber);
            Console.WriteLine("\nВведите количество столбцов в будущей матрице");
            UserStringInput(ref _matrixColumnNumber);
            Console.WriteLine("\nВаша матрица:\n");
            RandomMatrixGenerate();
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

                if (int.TryParse(_userInputString, out int result) && result > 0)
                {
                    requiredData = result;
                    _isUserInputCorrect = true;
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректные данные!");
                }
            }
        }

        static void RandomMatrixGenerate()
        {
            Random random = new Random();

            _randomMatrix = new int[_matrixStringNumber, _matrixColumnNumber];

            for (int stringIndex = 0; stringIndex < _matrixStringNumber; stringIndex++)
            {
                for (int columnIndex = 0; columnIndex < _matrixColumnNumber; columnIndex++)
                {
                    _sumMatrixElements += _randomMatrix[stringIndex, columnIndex] = random.Next(10);
                    Console.Write($"{_randomMatrix[stringIndex, columnIndex],3}");
                }
                Console.WriteLine("\n");
            }
            Console.Write($"Сумма всех элементов матрицы: {_sumMatrixElements}");
        }
    }
}
