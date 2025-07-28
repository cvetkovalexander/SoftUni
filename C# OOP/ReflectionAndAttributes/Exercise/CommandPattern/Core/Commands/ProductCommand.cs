using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands;

public class ProductCommand : ICommand
{
    public string Execute(string[] args)
    {
        long product = 1;
        for (int i = 0; i < args.Length; i++)
        {
            if (int.TryParse(args[i], out int num)) product *= num;
            else return $"Value at index {i} is not a valid integer.";
        }

        return $"The product is: {product}.";
    }
}