using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxOfString;

public  class ListOfBoxes<T> where T: IComparable
{
    public ListOfBoxes()
    {
        this.Boxes = new List<Box<T>>();
    }

    public List<Box<T>> Boxes;

    //public void Swap(int firstIndex, int secondIndex)
    //{
    //    (this.Boxes[firstIndex], this.Boxes[secondIndex]) = (this.Boxes[secondIndex], this.Boxes[firstIndex]);
    //}

    //public void PrintBoxes()
    //{
    //    foreach (var t in this.Boxes)
    //        Console.WriteLine(t);
    //}

    public int Compare(T value)
    {
        int count = 0;
        foreach (var box in Boxes)
        {
            if (box.Value.CompareTo(value) == 1) count++;
        }
        return count;
    }
}