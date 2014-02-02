using System;
using Common.Logging;

namespace WebMagic.Specifications.Infrastructure
{
    // ReSharper disable once InconsistentNaming
    public static class ILogExtensions
    {
        public static void Log(this ILog log, LogLevel logLevel, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    log.Debug(message);
                    break;

                case LogLevel.Error:
                    log.Error(message);
                    break;

                case LogLevel.Fatal:
                    log.Fatal(message);
                    break;

                case LogLevel.Info:
                    log.Info(message);
                    break;

                case LogLevel.Trace:
                    log.Trace(message);
                    break;

                case LogLevel.Warn:
                    log.Warn(message);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("logLevel", logLevel, "Value is not supported.");
            }
        }
    }
}
