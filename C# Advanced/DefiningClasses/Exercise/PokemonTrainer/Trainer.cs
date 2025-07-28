﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer;

public class Trainer
{
    public override string ToString()
    {
        return $"{Name} {Badges} {Pokemons.Count}";
    }

    public Trainer(string name)
    {
        Name = name;
        Badges = 0;
        Pokemons = new();
    }
    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemons { get; set; }
}