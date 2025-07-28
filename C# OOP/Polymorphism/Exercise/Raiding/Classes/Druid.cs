using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Classes;

public class Druid : BaseHero
{
    public override int Power => 80;
    public Druid(string name) : base(name)
    {
    }

    public override string CastAbility() 
        => $"{GetType().Name} - {Name} healed for {Power}";
}