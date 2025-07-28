using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Contracts;

public interface ICommand
{
    char Operator { get; }
    int Value { get; }
    double Execute(double currentVal);
    double UnExecute(double currentVal);
}