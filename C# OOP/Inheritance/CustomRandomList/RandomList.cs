using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList;

public class RandomList : List<string>
{
    public string RandomString()
    {
        int ranIndex = Random.Shared.Next(this.Count);

        string randomValue = this[ranIndex];
        this.RemoveAt(ranIndex);

        return randomValue;
    }
}