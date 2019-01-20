using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = new int[] { 3, 8, 7, 5, 2, 1, 9, 6, -2, 15, 0};
            
            MergeSortIterative(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + ",");
            }
            Console.ReadLine();
        }

        private static void MergeSortIterative(int[] data)
        {
            for (int i = 1; i <= data.Length - 1; i = i * 2)
            {
                for (int left = 0; left < data.Length - 1; left += 2 * i)
                {
                    int right = Math.Min(left + 2 * i - 1, data.Length - 1);
                    int mid = left + i - 1;
                    if (mid > right)
                        mid = right;

                    Merge(data, left, mid, right);
                }
            }
        }

        private static void Merge(int[] numbers, int low, int mid, int high)
        {
            int[] tmp = new int[high - low + 1];

            int left = low;
            int right = mid + 1;
            int tmpIndex = 0;

            while ((left <= mid) && (right <= high))
            {
                if (numbers[left] < numbers[right])
                {
                    tmp[tmpIndex] = numbers[left];
                    left++;
                }
                else
                {
                    tmp[tmpIndex] = numbers[right];
                    right++;
                }
                tmpIndex++;
            }

            if (left <= mid)
            {
                while (left <= mid)
                {
                    tmp[tmpIndex] = numbers[left];
                    left++;
                    tmpIndex++;
                }
            }
            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = numbers[right];
                    right++;
                    tmpIndex++;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                numbers[low + i] = tmp[i];
            }
        }
    }
}
