namespace CommandPattern.Commands;

public class DivideCommand : BaseCommand
{
    public DivideCommand(int value) : base(value, '/')
    {
    }

    public override double Execute(double currentVal)
        => currentVal / this.Value;

    public override double UnExecute(double currentVal)
        => currentVal * this.Value;
}