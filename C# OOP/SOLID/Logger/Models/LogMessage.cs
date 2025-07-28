using Logging.Enums;

namespace Logging.Models;

public class LogMessage
{
    public LogMessage(ReportLevel reportLevel, string time, string message)
    {
        this.ReportLevel = reportLevel;
        this.Time = time;
        this.Message = message;
    }

    public string Message { get; }

    public ReportLevel ReportLevel { get; }

    public string Time { get; }
}