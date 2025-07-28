using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands;

public class SumCommand : ICommand
{
    public string Execute(string[] args)
    {
        long sum = 0;
        for (int i = 0; i < args.Length; i++)
        {
            if (int.TryParse(args[i], out int num)) sum += num;
            else return $"Value at index {i} is not a valid integer.";
        }

        return $"The sum is: {sum}";
    }
}