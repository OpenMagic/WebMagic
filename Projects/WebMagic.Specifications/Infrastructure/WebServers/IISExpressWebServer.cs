using System;
using System.Diagnostics;
using System.IO;

namespace WebMagic.Specifications.Infrastructure.WebServers
{
    public class IISExpressWebServer : IWebServer, IDisposable
    {
        private bool IsDisposed;
        private Process Process;

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(disposing).
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void StartWebsite(DirectoryInfo projectDirectory, int port)
        {
            Process = Process.Start(new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Normal,
                    ErrorDialog = true,
                    LoadUserProfile = true,
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    Arguments = String.Format("/path:\"{0}\" /port:{1}", projectDirectory.FullName, port),
                    FileName = GetIISExpressFile().FullName
                }
            );
        }

        public void StopWebsite()
        {
            if (Process == null)
            {
                return;
            }

            if (!Process.HasExited)
            {
                Process.Kill();
            }

            Process.Dispose();
            Process = null;
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
                    StopWebsite();
                }
            }

            IsDisposed = true;
        }

        private static FileInfo GetIISExpressFile()
        {
            var key = Environment.Is64BitOperatingSystem ? "programfiles(x86)" : "programfiles";
            var programfiles = Environment.GetEnvironmentVariable(key);

            return new FileInfo(string.Format(@"{0}\IIS Express\iisexpress.exe", programfiles));
        }
    }
}