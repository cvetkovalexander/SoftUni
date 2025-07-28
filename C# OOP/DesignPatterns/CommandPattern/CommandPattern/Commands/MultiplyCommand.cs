namespace CommandPattern.Commands;

public class MultiplyCommand : BaseCommand
{
    public MultiplyCommand(int value) : base(value, '*')
    {
    }

    public override double Execute(double currentVal)
        => currentVal * this.Value;

    public override double UnExecute(double currentVal)
       => currentVal / this.Value;
}