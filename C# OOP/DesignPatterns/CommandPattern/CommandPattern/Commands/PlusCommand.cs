namespace CommandPattern.Commands;

public class PlusCommand : BaseCommand
{
    public PlusCommand(int value) : base(value, '+')
    {
    }

    public override double Execute(double currentVal)
        => currentVal + this.Value;

    public override double UnExecute(double currentVal)
        => currentVal - this.Value;
}