using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList;

public class CustomLinkedQueue<T> : IEnumerable<T>
{
    private Node? _head, _tail;
    private int _count;

    public int Count => this._count;

    public int this[int index]
    {
        get
        {
            this.InvalidIndex(index);

            Node head = this._head;
            for (int i = 0; i < index; i++)
                head = head.Next;

            return head.Value;
        }
    }

    public void Enqueue(int value)
    {
        Node newNode = new Node {Value = value};

        if (this._count == 0)
        {
            this._head = newNode;
            this._tail = newNode;
            return;
        }
        this._tail!.Next = newNode;
        this._tail = newNode;
        this._count++;
    }

    public int Dequeue()
    {
        this.IsEmpty();

        int removed = this._head.Value;

        if (this._count == 1)
        {
            this._head = null;
            this._tail = null;
        }
        else
        {
            Node nextHead = this._head.Next!;
            this._head.Next = null;
            this._head = nextHead;
        }
        this._count--;
        return removed;
    }

    public int Peek()
    {
        this.IsEmpty();
        return this._head!.Value;
    }

    public void ForEach(Action<int> action)
    {
        Node? head = this._head;
        while (head != null)
        {
            action(head.Value);
            head = head.Next;
        }
    }

    private void InvalidIndex(int index)
    {
        if (index < 0 || index >= this._count) throw new IndexOutOfRangeException("Index out of range!");
    }

    private void IsEmpty()
    {
        if (this._count == 0) throw new InvalidOperationException("Queue is empty");
    }
    private class Node
    {
        public int Value { get; set; }
        public Node? Next { get; set; }
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
