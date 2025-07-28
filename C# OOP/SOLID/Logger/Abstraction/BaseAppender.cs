using Logging.Enums;
using Logging.Models;

namespace Logging.Abstraction;

public abstract class BaseAppender : IAppender
{
    private readonly IFormatter<LogMessage> _formatter;
    private readonly ReportLevel _reportThreshold;

    private int _appendedMessages, _appendedCharacters;

    protected BaseAppender(IFormatter<LogMessage> formatter, ReportLevel reportThreshold)
    {
        this._formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        this._reportThreshold = reportThreshold;
    }
    public virtual void Initialize()
    {
    }

    public void Append(LogMessage logMessage)
    {
        if (logMessage.ReportLevel < this._reportThreshold) return;

        string textToAppend = this._formatter.Format(logMessage);
        this.Append(textToAppend);

        this._appendedMessages++;
        this._appendedCharacters += textToAppend.Length;

    }

    protected abstract void Append(string logMessage);

    public override string ToString()
    {
        return $"Appender type: {this.GetType().Name}, Formatter: {this._formatter.GetType().Name}, Report threshold: {this._reportThreshold.ToString().ToUpper()}, Messages appended: {this._appendedMessages}, Characters appended: {this._appendedCharacters}";
    }

}