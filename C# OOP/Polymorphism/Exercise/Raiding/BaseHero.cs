using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding;

public abstract class BaseHero : IHero
{
    public string Name { get; }
    public abstract int Power { get; }

    protected BaseHero(string name)
    {
        this.Name = name;
    }

    public abstract string CastAbility();
}