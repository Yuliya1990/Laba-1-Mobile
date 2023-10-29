using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes
{
    public static class SelectionSortArray
    {
        private static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static int SelectionSort(int[] arr, int n)
        {
            int iterations = 0;
            for (int i = 0; i < n - 1; i++)
            {
                iterations++;
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    iterations++;
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                swap(arr, min, i);
            }
            return iterations;
        }
    }
}
