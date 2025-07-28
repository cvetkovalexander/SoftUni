using System.Collections.Immutable;
using System.Text;
using Logging.Abstraction;
using Logging.Enums;

namespace Logging.Models;

public class Logger : ILogger
{
    private readonly IImmutableList<IAppender> _appenders;

    public Logger(IImmutableList<IAppender> appenders)
    {
        this._appenders = appenders ?? throw new ArgumentNullException(nameof(appenders));
    }
    public void Initialize()
    {
        foreach (IAppender appender in this._appenders)
            appender.Initialize();
    }
    public void Log(ReportLevel reportLevel, string time, string message)
    {
        foreach (IAppender appender in this._appenders)
        {
            LogMessage logMessage = new(reportLevel, time, message);
            appender.Append(logMessage);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append("Logger info");
        foreach (IAppender appender in this._appenders)
        {
            sb.AppendLine();
            sb.Append(appender.ToString());
        }

        return sb.ToString();
    }

}