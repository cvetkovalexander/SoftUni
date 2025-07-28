using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList;

public class CustomGenericLinkedList<T>
{
    private int _count;
    public Node<T> First { get; set; }
    public Node<T> Last { get; set; }

    public int Count => _count;

    public void AddFirst(T value)
    {
        this._count++;
        Node<T> node = new Node<T>(value);
        if (this.First == null)
        {
            this.First = node;
            this.Last = node;
            return;
        }
        First.Previous = node;
        node.Next = First;
        First = node;
    }

    public void AddLast(T value)
    {
        this._count++;
        Node<T> node = new Node<T>(value);
        if (this.Last == null)
        {
            this.First = node;
            this.Last = node;
            return;
        }

        Last.Next = node;
        node.Previous = Last;
        Last = node;
    }

    public Node<T> RemoveFirst()
    {
        Node<T> oldHead = First;
        Node<T> newHead = First.Next;
        First.Next = null;
        if (newHead != null)
        {
            newHead.Previous = null;
        }
        else
        {
            Last = null;
        }
        First = newHead;
        this._count--;

        return oldHead;
    }

    public Node<T> RemoveLast()
    {
        Node<T> oldTail = Last;
        Node<T> newTail = Last.Previous;
        if (newTail != null)
        {
            newTail.Next = null;
        }
        else
        {
            First = null;
        }
        Last.Previous = null;
        Last = newTail;
        this._count--;

        return oldTail;
    }

    public void ForEach(Action<T> action)
    {
        Node<T> current = First;
        while (current != null)
        {
            action(current.Value);
            current = current.Next;
        }
    }

    public T[] ToArray()
    {
        T[] array = new T[Count];
        int index = 0;
        this.ForEach(x => array[index++] = x);
        return array;
    }
}