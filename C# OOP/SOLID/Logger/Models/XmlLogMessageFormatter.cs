using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logging.Abstraction;

namespace Logging.Models;

public class XmlLogMessageFormatter : IFormatter<LogMessage>
{
    public string Format(LogMessage logMessage)
    {
        StringBuilder sb = new();
        sb.AppendLine("<log>");
        sb.AppendLine($"   <time>{logMessage.Time}</time>");
        sb.AppendLine($"   <level>{logMessage.ReportLevel}</level");
        sb.AppendLine($"   <message>{logMessage.Message}</message>");
        sb.Append("</log>");

        return sb.ToString();
    }
}