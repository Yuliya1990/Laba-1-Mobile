using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes
{
    public static class BubbleSortArray
    {
        public static int BubbleSort(int[] arr)
        {
            int iterations = 0;
            int n = arr.Length;
            bool swapped;

            do
            {
                iterations++;

                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    iterations++;
                    if (arr[i - 1] > arr[i])
                    {
                        // Swap arr[i-1] and arr[i]
                        int temp = arr[i - 1];
                        arr[i - 1] = arr[i];
                        arr[i] = temp;

                        swapped = true; // Mark that a swap occurred
                    }
                }
            } while (swapped);

            return iterations;
        }
    }

}
