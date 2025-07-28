using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggyCustomEnumerator;

public class Lake :IEnumerable<int>
{
    private readonly int[] _stones;

    public Lake(IEnumerable<int> stones)
    {
        this._stones = stones.ToArray();
    }

    public IEnumerator<int> GetEnumerator() => new Enumerator(this._stones);

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class Enumerator : IEnumerator<int>
    {
        private readonly int[] _stones;
        private int _index;
        private bool _forward;

        public Enumerator(int[] stones)
        {
            this._stones = stones;
            this.Reset();
        }
        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (!HasNext()) return false;

            if (this._forward)
            {
                this._index += 2;
                if (this._index >= this._stones.Length)
                {
                    this._forward = false;
                    this._index = this._stones.Length - this._stones.Length % 2 - 1;
                }
            }
            else
            {
                this._index -= 2;
            }

            return this._index >= 0;    
        }

        public void Reset()
        {
            this._index = -2;
            this._forward = true;
        }

        public int Current => this._stones[this._index];

        object? IEnumerator.Current => this.Current;

        private bool HasNext() => this._index != -1;
    }
}