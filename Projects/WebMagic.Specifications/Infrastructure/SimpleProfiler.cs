using System;
using System.Diagnostics;
using Common.Logging;
using OpenQA.Selenium.Support.UI;

namespace WebMagic.Specifications.Infrastructure
{
    public class SimpleProfiler : IDisposable
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        
        private bool IsDisposed;
        private readonly LogLevel LogLevel;
        private readonly string Message;
        private readonly Stopwatch Stopwatch;

        public SimpleProfiler(LogLevel logLevel, string message)
        {
            LogLevel = logLevel;
            Message = message;
            Stopwatch = Stopwatch.StartNew();
        }

        public static SimpleProfiler Trace(string message)
        {
            return new SimpleProfiler(LogLevel.Trace, message);
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code.
            // Put cleanup code in Dispose(bool disposing).
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Releases unmanaged and optionally managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    Log.Log(LogLevel, string.Format("{0} took {1:N}ms.", Message, Stopwatch.ElapsedMilliseconds));
                }
            }
            IsDisposed = true;
        }
    }
}