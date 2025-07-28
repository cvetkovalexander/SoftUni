using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Classes;

public class Warrior : BaseHero
{
    public override int Power => 100;
    public Warrior(string name) : base(name)
    {
    }
    public override string CastAbility()
        => $"{GetType().Name} - {Name} hit for {Power} damage";
    
}