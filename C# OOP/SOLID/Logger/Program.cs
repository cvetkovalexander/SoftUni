using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.Serialization;
using Logging.Abstraction;
using Logging.Enums;
using Logging.Models;

namespace Logging;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        IAppender[] appenders = new IAppender[n];

        for (int i = 0; i < appenders.Length; i++)
        {
            string[] data = Console.ReadLine().Split();

            IFormatter<LogMessage> formatter = CreateFormatter(data[1]);
            ReportLevel reportThreshold = ReportLevel.Info;
            if (data.Length == 3)
                reportThreshold = Enum.Parse<ReportLevel>(data[2], ignoreCase: true);

            appenders[i] = CreateAppender(data[0], formatter, reportThreshold);
    
        }

        ILogger logger = new Logger(appenders.ToImmutableArray());
        logger.Initialize();
        ProcessMessages(logger);

        Console.WriteLine(logger);
    }

    private static void ProcessMessages(ILogger logger)
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] data = input.Split('|');
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(data[0], ignoreCase: true);
            string time = data[1];
            string message = data[2];

            logger.Log(reportLevel, time, message);
        }
    }
    private static IAppender CreateAppender(string type, IFormatter<LogMessage> formatter, ReportLevel reportThreshold)
    {
        string[] colors = Enum.GetNames<ConsoleColor>();
        int random = Random.Shared.Next(colors.Length);
        return type switch
        {
            "Console" => new ConsoleAppender(formatter, reportThreshold, colors[random]),
            "File" => new FileAppender(@"C:\Users\Admin\Desktop\C# OOP\SOLID\logs.txt", formatter, reportThreshold),
            _ => throw new InvalidOperationException("Invalid appender type.")
        };
    }

    private static IFormatter<LogMessage> CreateFormatter(string type)
    {
        //if (type == "Simple") return new SimpleLogMessageFormatter();
        //if (type == "Xml") return new XmlLogMessageFormatter();
        //if (type == "Json") return new JsonLogMessageFormatter();

        return type switch
        {
            "Simple" => new SimpleLogMessageFormatter(),
            "Xml" => new XmlLogMessageFormatter(),
            "Json" => new JsonLogMessageFormatter(),
            _ => throw new InvalidOperationException("Invalid formatter type")
        };
    }

    private static void Demo()
    {
        IFormatter<LogMessage> simpleFormatter = new SimpleLogMessageFormatter();
        IFormatter<LogMessage> xmlFormatter = new XmlLogMessageFormatter();
        IFormatter<LogMessage> jsonFormatter = new JsonLogMessageFormatter();
        IAppender consoleAppender = new ConsoleAppender(jsonFormatter, ReportLevel.Info);
        IAppender verboseFileAppender = new FileAppender(@"C:\Users\Admin\Desktop\C# OOP\SOLID\all_logs.txt", simpleFormatter, ReportLevel.Info);

        IAppender criticalFileAppender =
            new FileAppender(@"C:\Users\Admin\Desktop\C# OOP\SOLID\critical_logs.txt", xmlFormatter, ReportLevel.Error);

        ImmutableList<IAppender> appenders = new[] { consoleAppender, verboseFileAppender, criticalFileAppender }.ToImmutableList();
        ILogger logger = new Logger(appenders);

        logger.Log(ReportLevel.Error, "3/26/2015 2:08:11 PM", "Error parsing JSON.");
        logger.Log(ReportLevel.Info, "3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
    }
}