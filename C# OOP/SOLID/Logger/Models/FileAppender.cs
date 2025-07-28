using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logging.Abstraction;
using Logging.Enums;

namespace Logging.Models;

public class FileAppender : BaseAppender
{
    private readonly string _path;
    
    public FileAppender(string path, IFormatter<LogMessage> formatter, ReportLevel reportThreshold) : base(formatter, reportThreshold)
    {
        this._path = ValidatePath(path);
    }

    public override void Initialize()
    {
        if (File.Exists(this._path))
            File.Delete(this._path);
    }

    protected override void Append(string logMessage)
    {
        using StreamWriter writer = File.AppendText(this._path);
        writer.WriteLine(logMessage);

    }

    private static string ValidatePath(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("Path cannot be empty", nameof(path));

        // NOTE: We can validate that the provided 'path' is valid.

        return path;
    }
}