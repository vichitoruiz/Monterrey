using System;
using System.IO;
using System.Text;

namespace SSEL.MONTERREY.Infrastructure.Logging;

public static class FileLogger
{
    private static readonly string LogDir = Path.Combine(AppContext.BaseDirectory, "logs");
    private static readonly object Sync = new();

    public static void Info(string message) => Write("INFO", message);
    public static void Error(string message) => Write("ERROR", message);
    public static void Warn(string message) => Write("WARN", message);

    private static void Write(string level, string message)
    {
        try
        {
            lock (Sync)
            {
                Directory.CreateDirectory(LogDir);
                var file = Path.Combine(LogDir, $"ssel_{DateTime.UtcNow:yyyyMMdd}.log");
                File.AppendAllText(file, $"[{DateTime.UtcNow:O}] [{level}] {message}{Environment.NewLine}", Encoding.UTF8);
            }
        }
        catch { /* Evitar throw en logger */ }
    }
}
