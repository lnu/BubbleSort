using System;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // array to be sorted
            int[] toSort = GenerateRandomIntArray(0, 100, 1000);

            Console.WriteLine(string.Join(',', toSort));

            ClassicSort((int[])toSort.Clone());
            WhileSort((int[])toSort.Clone());
            OptimizedWhileSort((int[])toSort.Clone());
        }

        static int[] GenerateRandomIntArray(int min, int max, int length)
        {
            var tmp = new int[length];

            Random randNum = new Random();
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = randNum.Next(min, max);
            }
            return tmp;
        }

        static void ClassicSort(int[] toSort)
        {
            int iteration = 0;
            for (int i = 0; i < toSort.Length - 1; i++)
            {
                for (int j = 0; j < toSort.Length - 1 - i; j++)
                {
                    iteration++;
                    if (toSort[j] > toSort[j + 1])
                    {
                        Swap(ref toSort[i], ref toSort[i + 1]);
                    }
                }
            }
            Console.WriteLine(iteration);
            Console.WriteLine(string.Join(',', toSort));
        }

        static void WhileSort(int[] toSort)
        {
            int iteration = 0;
            bool swapped = false;
            int length = toSort.Length;
            do
            {
                swapped = false;
                for (int i = 0; i < length - 1; i++)
                {
                    iteration++;
                    if (toSort[i] > toSort[i + 1])
                    {
                        Swap(ref toSort[i], ref toSort[i + 1]);
                        swapped = true;
                    }
                }
                length--;
            }
            while (swapped == true);
            Console.WriteLine(iteration);
            Console.WriteLine(string.Join(',', toSort));
        }

        static void OptimizedWhileSort(int[] toSort)
        {
            int iteration = 0;
            int length = toSort.Length;
            do
            {
                int newLength = 0;
                for (int i = 1; i <= length - 1; i++)
                {
                    iteration++;
                    if (toSort[i - 1] > toSort[i])
                    {
                        Swap(ref toSort[i], ref toSort[i - 1]);
                        newLength = i;
                    }
                }
                length = newLength;
            }
            while (length > 0);

            Console.WriteLine(iteration);
            Console.WriteLine(string.Join(',', toSort));
        }

        static void Swap(ref int a, ref int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }
}
