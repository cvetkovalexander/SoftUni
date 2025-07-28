using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort;

public class Quick<T> where T: IComparable
{
    public void QuickSort(T[] array, int start, int end)
    {
        if (end <= start) return;

        int pivot = Partition(array, start, end);
        QuickSort(array, start, pivot - 1);
        QuickSort(array, pivot + 1, end);
    }

    private static int Partition(T[] array, int start, int end)
    {
        T pivot = array[end];
        int i = start - 1;

        for (int j = start; j <= end - 1; j++)
        {
            if (array[j].CompareTo(pivot) < 0)
            {
                i++;
                (array[i], array[j]) = (array[j], array[i]);
            }
        }

        i++;
        (array[i], array[end]) = (array[end], array[i]);

        return i;
    }
}