using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators;

public class Library : IEnumerable<Book>
{
    public List<Book> Books { get; set; }

    public Library(params Book[] books)
    {
        Books = books.ToList();
        this.Books.Sort(new BookComparator());
    }

    public IEnumerator<Book> GetEnumerator() => this.Books.GetEnumerator();
    
        //LibraryIterator iterator = new(this.Books);
        //return iterator;

        //for (int i = 0; i < this.Books.Count; i++)
        //    yield return this.Books[i];
    

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    
    //private class LibraryIterator : IEnumerator<Book>
    //{
    //    private  readonly List<Book> _books;
    //    private int _index;
    //    public Book Current => this._books[this._index];
    //    object IEnumerator.Current => this.Current;

    //    public LibraryIterator(List<Book> books)
    //    {
    //        _books = books;
    //        this.Reset();
    //    }
    //    public bool MoveNext()
    //    {
    //        if (this._index >= this._books.Count) return false;
    //        return ++this._index < this._books.Count;
    //    }

    //    public void Reset()
    //    {
    //        this._index = -1;
    //    }

    //    public void Dispose()
    //    {
    //    }
    //}
}