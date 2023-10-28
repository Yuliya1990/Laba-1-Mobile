using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes
{
    public static class MergeSortArray
    {
        static int Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            int iterations = 1;
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
            return iterations;
        }

        //сортировка слиянием
        static int MergeSort(int[] array, int lowIndex, int highIndex)
        {
            int iterations = 0;
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                iterations += MergeSort(array, lowIndex, middleIndex);
                iterations += MergeSort(array, middleIndex + 1, highIndex);
                iterations += Merge(array, lowIndex, middleIndex, highIndex);
            }

            return iterations;
        }

        public static int MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }




    }
}
