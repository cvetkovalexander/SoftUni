using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator;

public class ListyIterator<T> : IEnumerable<T>
{
    private  readonly List<T> _collection;
    private int _index;

    public T Current => this.GetCurrenElement();

    public ListyIterator(params T[] items)
    {
        this._collection = items.ToList();
        }

    public bool Move()
    {
        if (!HasNext()) return false;

        this._index++;
        return true;
    }

    public bool HasNext()
    {
        return this._index < this._collection.Count - 1;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this._collection.Count; i++)
            yield return this._collection[i];
    }
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private T GetCurrenElement()
    {
        if (this._index >= this._collection.Count)
            throw new InvalidOperationException("Invalid Operation!");

        return this._collection[this._index];
    }
}





