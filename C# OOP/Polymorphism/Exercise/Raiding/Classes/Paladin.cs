using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Classes;

public class Paladin : BaseHero
{
    public override int Power => 100;
    public Paladin(string name) : base(name)
    {
    }

    public override string CastAbility()
        => $"{GetType().Name} - {Name} healed for {Power}";
    
        
}