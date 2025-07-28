namespace Logging.Abstraction;

public interface IFormatter<T>
{
    string Format(T logMessage);
}