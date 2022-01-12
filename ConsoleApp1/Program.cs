using System;

namespace RandomArrayQuickSort
{
    class Program
    {
        public static void Main()
        {
            int[] inputArray = new int[10];
            Random randomArray = new Random();
            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = randomArray.Next(-99, 99);
            }
            Console.WriteLine($"InputArray: {string.Join(", ", inputArray)}");

            int[] sortedArray = QuickSort(inputArray, 0, inputArray.Length - 1);

            Console.WriteLine($"Sorted array: {string.Join(", ", sortedArray)}");

            Console.ReadLine();
        }

        private static int[] QuickSort(int[] array, int minNumber, int maxNumber)
        {
            if (minNumber >= maxNumber)
            {
                return array;
            }

            int basicNumber = GetBasicNumber(array, minNumber, maxNumber);

            QuickSort(array, minNumber, basicNumber - 1);
            QuickSort(array, basicNumber + 1, maxNumber);

            return array;
        }

        private static int GetBasicNumber(int[] array, int minNumber, int maxNumber)
        {
            int basic = minNumber - 1;

            for (int i = minNumber; i <= maxNumber; i++)
            {
                if (array[i] < array[maxNumber])
                {
                    basic++;
                    MoveNumbers(ref array[basic], ref array[i]);
                }
            }
            basic++;
            MoveNumbers(ref array[basic], ref array[maxNumber]);

            return basic;
        }

        private static void MoveNumbers(ref int leftNumber, ref int rightNumber)
        {
            int temp = leftNumber;
            leftNumber = rightNumber;
            rightNumber = temp;
        }
    }
}