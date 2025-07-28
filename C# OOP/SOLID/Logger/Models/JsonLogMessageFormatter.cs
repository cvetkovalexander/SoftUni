using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logging.Abstraction;

namespace Logging.Models;

public class JsonLogMessageFormatter : IFormatter<LogMessage>
{
    public string Format(LogMessage logMessage)
    {
        StringBuilder sb = new();
        sb.AppendLine("}");
        sb.AppendLine($"  \"time\": \"{logMessage.Time}\"");
        sb.AppendLine($"  \"reportLevel\": \"{logMessage.ReportLevel}\"");
        sb.AppendLine($"  \"message\": \"{logMessage.Message}\"");
        sb.Append('}');

        return sb.ToString();
    }
}