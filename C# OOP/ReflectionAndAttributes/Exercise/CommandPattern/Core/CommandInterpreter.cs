using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core;

public class CommandInterpreter : ICommandInterpreter
{
    private readonly Dictionary<string, List<Type>> _cachedCommandTypes = new();
    public CommandInterpreter()
    {
        ExtractCommands(Assembly.GetCallingAssembly());
    }

    public void ExtractCommands(Assembly assembly)
    {
        foreach (Type commandType in assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ICommand))))
        {
            string commandName = commandType.Name;
            if (!this._cachedCommandTypes.ContainsKey(commandName))
                this._cachedCommandTypes[commandType.Name] = new();

            this._cachedCommandTypes[commandName].Add(commandType);
        }
    }

    public string Read(string args)
    {
        string[] data = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string commandName = data[0] + "Command";

        // 1. Dynamically find the command type that should be executed

        // 1.1 Validate that the command type implements the 'ICommand' interface
        // if a.IsAssignableFrom(b), then b.IsAssignableFrom(a)

        // We can't use this piece of code because we don't know the 'full name' of the command types.
        // Type commandType = Assembly.GetCallingAssembly().GetType(commandName, throwOnError: false);

        //Type[] commandTypes = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name == commandName && t.IsAssignableTo(typeof(ICommand))).ToArray();
        //if (commandTypes.Length > 1) return "Error: Multiple commands were detected.";
        //if (commandTypes.Length == 0) return "Error: Unrecognized command.";

        if (!this._cachedCommandTypes.ContainsKey(commandName)) return "Error: Unrecognized command.";

        List<Type> commandTypes = this._cachedCommandTypes[commandName];
        if (commandTypes.Count > 1) return "Error: Multiple commands detected.";



        // 2. Create a new command instance
        ICommand command;
        try
        {
            command = (ICommand) Activator.CreateInstance(commandTypes[0]);
             //command = Activator.CreateInstance(commandType) as ICommand;
        }
        catch (Exception e)
        {
            return $"Error: Could not create instance of the specified command. Message: {e.Message}";
        }

        // 3. Execute
        return command.Execute(data[1..]);
    }
}