using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMergeSort;

public class Mergesort<T> where T : IComparable
{
    public void Sort(T[] arr)
    {
        int length = arr.Length;
        if (length <= 1) return; //base case

        int middle = length / 2;
        T[] leftArr = new T[middle];
        T[] rightArr = new T[length - middle];

        int i = 0; // left array
        int j = 0; // right array

        for (; i < length; i++)
        {
            if (i < middle)
                leftArr[i] = arr[i];
            else
            {
                rightArr[j] = arr[i];
                j++;
            }
        }
        Sort(leftArr);
        Sort(rightArr);
        Merge(leftArr, rightArr, arr);
    }

    private static void Merge(T[] leftArr, T[] rightArr, T[] array)
    {
        int leftSize = array.Length / 2;
        int rightSize = array.Length - leftSize;
        int i = 0; //original array
        int l = 0; //left array
        int r = 0; //right array

        //check the conditions for merging
        while (l < leftSize && r < rightSize)
        {
            if (leftArr[l].CompareTo(rightArr[r]) < 0)
            {
                array[i++] = leftArr[l++];
            }
            else
            {
                array[i++] = rightArr[r++];
            }
        }

        while (l < leftSize)
        {
            array[i++] = leftArr[l++];
        }

        while (r < rightSize)
        {
            array[i++] = rightArr[r++];
        }
    }
}