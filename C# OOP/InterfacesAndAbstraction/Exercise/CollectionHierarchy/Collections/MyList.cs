using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Collections;

public class MyList : IAddSupportable, IRemoveSupportable, ICountable
{
    private readonly Stack<string> _stack = new();
    public int Count => this._stack.Count;
    public int Add(string item)
    {
        this._stack.Push(item);
        return 0;
    }

    public string Remove() => this._stack.Pop();

}