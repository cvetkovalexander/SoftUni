using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList;

public class CustomLinkedStack<T> : IEnumerable<T>
{
    private Node? _top;
    private int _count;

    public int Count => this._count;

    public T this[int index]
    {
        get
        {
            this.InvalidIndex(index);

            int steps = this._count - (index + 1);
            Node? top = this._top;
            for (int i = 0; i < steps; i++)
                top = top.Previous;

            return top!.Value;
        }
    }
    public void Push(T value)
    {
        Node newNode = new Node { Value = value, Previous = this._top };
        this._top = newNode;
        this._count++;
    }

    public T Pop()
    {
        this.IsEmpty();
        T removed = this._top!.Value;
        Node? nextTop = this._top.Previous;
        this._top.Previous = null;

        this._top = nextTop;
        this._count--;

        return removed;
    }

    public T Peek()
    {
        this.IsEmpty();
        return this._top.Value;
    }

    public void ForEach(Action<T> action)
    {
        foreach (T value in this)
            action(value);
    }

    private void InvalidIndex(int index)
    {
        if (index < 0 || index >= this._count) throw new IndexOutOfRangeException("Index out of range!");
    }
    private void IsEmpty()
    {
        if (this._count == 0) throw new InvalidOperationException("Stack is empty");
    }

    private class Node
    {
        public T Value { get; set; } = default!;
        public Node? Previous { get; set; }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? top = this._top;
        while (top != null)
        {
            yield return top.Value;
            top = top.Previous;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

}