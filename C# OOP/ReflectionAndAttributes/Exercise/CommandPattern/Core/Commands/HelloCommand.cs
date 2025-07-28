using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands;

public class HelloCommand : ICommand
{
    public string Execute(string[] args)
    {
        StringBuilder sb = new();
        for (int i = 0; i < args.Length; i++)
        {
            if (i > 0) sb.AppendLine();
            sb.Append($"Hello, {args[i]}");
        }

        return sb.ToString();
    }
}