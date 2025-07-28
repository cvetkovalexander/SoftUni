using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Collections;

public class AddCollection : IAddSupportable
{
    private readonly List<string> _list = new();
    public int Add(string item)
    {
        this._list.Add(item);
        return this._list.Count - 1;
    }
}