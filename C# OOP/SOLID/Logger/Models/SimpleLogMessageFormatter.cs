using Logging.Abstraction;

namespace Logging.Models;

public class SimpleLogMessageFormatter : IFormatter<LogMessage>
{
    public string Format(LogMessage logMessage)
        => $"{logMessage.Time} - {logMessage.ReportLevel.ToString().ToUpper()} - {logMessage.Message}";
}