using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Collections;

public class AddRemoveCollection : IAddSupportable, IRemoveSupportable
{
    private readonly Queue<string> _queue = new();
    public int Add(string item)
    {
        this._queue.Enqueue(item);
        return 0;
    }

    public string Remove() => this._queue.Dequeue();
}