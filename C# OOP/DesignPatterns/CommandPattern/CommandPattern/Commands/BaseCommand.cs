using CommandPattern.Contracts;

namespace CommandPattern.Commands;

public abstract class BaseCommand : ICommand
{
    protected BaseCommand(int value, char @operator)
    {
        this.Value = value;
        this.Operator = @operator;
    }

    public char Operator { get; }
    public int Value { get; }
    public abstract double Execute(double currentVal);
    public abstract double UnExecute(double currentVal);
}