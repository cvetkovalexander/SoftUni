using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Commands;
using CommandPattern.Contracts;

namespace CommandPattern;

public class Calculator
{
    private readonly List<ICommand> _commands = new();
    private readonly List<ICommand> _undoneCommands = new();

    public double Result { get; private set; }

    public void ExecuteCommand(ICommand command, bool isUndo = false)
    {
        this._commands.Add(command);
        this.Result = command.Execute(Result);

        if (!isUndo)
            this._undoneCommands.Clear();

    }

    public void Undo(int times)
    {
        for (int i = 0; i < times; i++)
        {
            if (this._commands.Count is 0) break;

            ICommand command = this._commands[^1];
            this.Result = command.UnExecute(this.Result);
            this._undoneCommands.Add(command);
            this._commands.Remove(command);
        }
    }

    public void Redo(int times)
    {
        for (int i = 0; i < times; i++)
        {
            if (this._undoneCommands.Count is 0) break;

            ICommand command = this._undoneCommands[^1];
            ExecuteCommand(command, true);

            this._undoneCommands.Remove(command);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new("0 ");
        foreach (var command in this._commands)
        {
            sb.Append($"{command.Operator} {command.Value} ");
        }

        sb.Append($"= {this.Result}");
        return sb.ToString();
    }
}