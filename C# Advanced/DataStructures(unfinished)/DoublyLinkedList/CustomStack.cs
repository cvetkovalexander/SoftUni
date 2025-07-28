using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList;

public class CustomStack<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 4;
    private T[] _buffer;
    private int _count;

    public int Count => _count;

    public CustomStack() : this(DefaultCapacity)
    {
        
    }

    public T this[int index]
    {
        get
        {
            this.InvalidIndex(index);
            return this._buffer[index];
        }
    }

    public CustomStack(int capacity)
    {
        if (capacity <= 0) throw new ArgumentException("Capacity cannot be zero or negative!");

        this._buffer = new T[capacity];
    }

    public void Push(int value)
    {
        this.GrowIfNecessary();
        this._buffer[this._count++] = value;
    }

    public int Pop()
    {
        this.IsEmpty();

        int last = this._buffer[this._count - 1];
        this._buffer[--this._count] = default;

        return last;
    }

    public int Peek()
    {
        this.IsEmpty();
        return this._buffer[this._count - 1];
    }

    public void ForEach(Action<int> action)
    {
        for (int i = this._count - 1; i >= 0; i--)
            action(this._buffer[i]);
    }

    public void PrintStack()
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (i > 0) Console.Write(", ");
            Console.Write(this._buffer[i]);
        }
        Console.WriteLine();
    }

    private void InvalidIndex(int index)
    {
        if (index < 0 || index >= this._buffer.Length) throw new IndexOutOfRangeException("Index out of range!");
    }

    private void IsEmpty()
    {
        if (this._count == 0) throw new InvalidOperationException("Stack is empty");
    }

    private void GrowIfNecessary()
    {
        if (this._count == this._buffer.Length)
            this.Grow();
    }

    private void Grow()
    {
        int[] newBuffer = new int[2 * this._buffer.Length];
        Array.Copy(this._buffer, newBuffer, this._buffer.Length);
        this._buffer = newBuffer;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}