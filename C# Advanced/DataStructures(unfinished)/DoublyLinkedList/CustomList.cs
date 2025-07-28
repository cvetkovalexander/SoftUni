using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList;

public class CustomList<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 4;
    private T[]? _buffer;
    private int _count;

    public int Count => _count;

    public CustomList() : this(DefaultCapacity)
    {
        
    }
    public CustomList(int capacity)
    {
        if (capacity <= 0) throw new ArgumentException("Capacity cannot be zero or negative!");
        this._buffer = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            if (InvalidIndex(index)) throw new IndexOutOfRangeException("Index is out of range!");
            return _buffer[index];
        }
        set
        {
            if (InvalidIndex(index)) throw new IndexOutOfRangeException("Index is out or range!");
            _buffer[index] = value;
        }
    }

    public void Add(T value)
    {
        this.GrowIfNecessary();
        this._buffer[this._count++] = value;
    }

    public T RemoveAt(int index)
    {
        if (InvalidIndex(index)) throw new IndexOutOfRangeException($"Index is out of range!");
        T removed = this._buffer[index]!;

        for (int i = index; i < this._count; i++)
            this._buffer[i] = this._buffer[i + 1];

        this._buffer[--this._count] = default; 
        return removed;
    }

    public void Insert(int index, T value)
    {
        if (index == this.Count)
        {
            this.Add(value);
            return;
        }
        if (InvalidIndex(index)) throw new IndexOutOfRangeException("Index is out of range!");

        this.GrowIfNecessary();
        for (int i = this._count - 1; i >= index; i--)
            this._buffer[i + 1] = this._buffer[i];

        this._buffer[index] = value;
        this._count++;
    }

    public bool Contains(T value)
    {
        for (int i = 0; i < this._buffer.Length; i++)
            if (EqualityComparer<T>.Default.Equals(this._buffer[i], value)) return true;

        return false;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        if (InvalidIndex(firstIndex)) throw new IndexOutOfRangeException($"Index {firstIndex} is invalid");
        if (InvalidIndex(secondIndex)) throw new IndexOutOfRangeException($"Index {secondIndex} is invalid");

        (this._buffer[firstIndex], this._buffer[secondIndex]) = (this._buffer[secondIndex], this._buffer[firstIndex]);
    }

    private void GrowIfNecessary()
    {
        if (this.Count == this._buffer.Length) this.Grow();
    }

    public void ForEach(Action<T> action)
    {
        for (int i = 0; i < this._count; i++)
            action(this._buffer[i]);
    }

    public void PrintList()
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (i > 0) Console.Write(", ");
            Console.Write(this._buffer[i]);

        }
        Console.WriteLine();
    }

    private void Grow()
    {
        T?[] newBuffer = new T?[2 * this._buffer.Length];
        Array.Copy(this._buffer, newBuffer, this._buffer.Length);
        this._buffer = newBuffer;
    }

    private bool InvalidIndex(int index)
    {
        return index < 0 || index >= this.Count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
            yield return this._buffer[i]!;
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

}
