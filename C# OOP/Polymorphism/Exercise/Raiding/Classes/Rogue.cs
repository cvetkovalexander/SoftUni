using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Classes;

public class Rogue : BaseHero
{
    public override int Power => 80;
    public Rogue(string name) : base(name)
    {
    }

    public override string CastAbility()
        => $"{GetType().Name} - {Name} hit for {Power} damage";
    
}