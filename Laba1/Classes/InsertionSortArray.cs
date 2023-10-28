﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes
{
    public static class InsertionSortArray
    {
        public static int InsertionSort(int[] arr)
        {
            int iterations = 0;
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1] that are greater than key
                // to one position ahead of their current position
                while (j >= 0 && arr[j] > key)
                {
                    iterations++;
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
            return iterations;
        }

    }
}
