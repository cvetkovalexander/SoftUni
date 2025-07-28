using Logging.Models;

namespace Logging.Abstraction;

public interface IAppender : IInitializable
{
    void Append(LogMessage logMessage);
}