using Logging.Enums;

namespace Logging.Abstraction;

public interface ILogger : IInitializable
{
    void Log(ReportLevel reportLevel, string time, string message);
}