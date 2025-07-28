using Logging.Abstraction;
using Logging.Enums;

namespace Logging.Models;

public class ConsoleAppender : BaseAppender
{
    private readonly ConsoleColor _foregroundColor;
    public ConsoleAppender(IFormatter<LogMessage> formatter, ReportLevel reportThreshold) : base(formatter, reportThreshold)
    {
    }
    public ConsoleAppender(IFormatter<LogMessage> formatter, ReportLevel reportThreshold, string? color) : base(formatter, reportThreshold)
    {
        if (color is not null)
            this._foregroundColor = Enum.Parse<ConsoleColor>(color, ignoreCase: true);
    }

    protected override void Append(string logMessage)
    {
        ConsoleColor prevColor = Console.ForegroundColor;
        Console.ForegroundColor = this._foregroundColor;

        Console.WriteLine(logMessage);

        Console.ForegroundColor = prevColor;
    }

}