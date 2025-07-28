using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList;

public class Node<T>
{
    public Node(T value, Node<T> next = null, Node<T> previous = null)
    {
        Value = value;
        Next = next;
        Previous = previous;
    }
    public T Value { get; set; }
    public Node<T> Next{ get; set; }
    public Node<T> Previous { get; set; }
    public override string ToString()
    {
        return $"{Previous.Value}<-{Value}->{Next.Value}";
    }
}