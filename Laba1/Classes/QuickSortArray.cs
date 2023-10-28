using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes
{
    public static class QuickSortArray
    {
        private static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        private static int partition(int[] a, int start, int end)
        {
            // Pick the rightmost element as a pivot from the array
            int pivot = a[end];

            // elements less than the pivot will be pushed to the left of `pIndex`
            // elements more than the pivot will be pushed to the right of `pIndex`
            // equal elements can go either way
            int pIndex = start;

            // each time we find an element less than or equal to the pivot, `pIndex`
            // is incremented, and that element would be placed before the pivot.
            for (int i = start; i < end; i++)
            {
                if (a[i] <= pivot)
                {
                    swap(a, i, pIndex);
                    pIndex++;
                }
            }

            // swap `pIndex` with pivot
            swap(a, pIndex, end);

            // return `pIndex` (index of the pivot element)
            return pIndex;
        }


        // Quicksort routine
        public static int Quicksort(int[] a, int start, int end)
        {
            int iterations = 0;
            // base condition
            if (start >= end)
            {
                return iterations;
            }

            // rearrange elements across pivot
            int pivot = partition(a, start, end);

            // recur on subarray containing elements that are less than the pivot
            iterations += Quicksort(a, start, pivot - 1);

            // recur on subarray containing elements that are more than the pivot
            iterations += Quicksort(a, pivot + 1, end);

            // Кожне порівняння та обмін внутрішнього циклу також збільшує лічильник ітерацій
            iterations += (end - start + 1);

            return iterations;

        }
    }
}
