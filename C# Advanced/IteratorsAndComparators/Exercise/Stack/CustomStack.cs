using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Stack;

public class CustomStack<T> : IEnumerable<T>
{
    private readonly List<T> _buffer;

    public CustomStack()
    {
        this._buffer = new();
    }

    public void Push(params T[] items)
    {
        for (int i = 0; i < items.Length; i++)
            this._buffer.Add(items[i]);
    }

    public void Pop()
    {
        if (this._buffer.Count == 0)
        {
            Console.WriteLine("No elements");
            return;
        }
        this._buffer.RemoveAt(this._buffer.Count - 1);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this._buffer.Count - 1; i >= 0; i--)
            yield return this._buffer[i];

        for (int i = this._buffer.Count - 1; i >= 0; i--)
            yield return this._buffer[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}