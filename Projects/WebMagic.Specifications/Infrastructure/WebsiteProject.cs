using System;
using System.IO;
using Anotar.CommonLogging;
using OpenQA.Selenium;
using WebMagic.Specifications.Infrastructure.WebServers;

namespace WebMagic.Specifications.Infrastructure
{
    public class WebsiteProject : IDisposable
    {
        public readonly Uri Uri;

        private readonly IWebServer WebServer;
        private readonly IWebDriver WebDriver;

        private bool IsDisposed;

        public WebsiteProject(IWebDriver webDriver, DirectoryInfo projectDirectory, int port)
            : this(new IISExpressWebServer(), webDriver, projectDirectory, port)
        {
        }

        public WebsiteProject(IWebServer webServer, IWebDriver webDriver, DirectoryInfo projectDirectory, int port)
        {
            LogTo.Trace("WebsiteProject(webServer, projectDirectory: {0}, port: {1})", projectDirectory, port);

            WebServer = webServer;
            WebDriver = webDriver;
            Uri = new Uri(string.Format("http://localhost:{0}", port));

            WebServer.StartWebsite(projectDirectory, port);
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(disposing).
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void GoTo(string url)
        {
            var uri = Uri.Combine(url);

            LogTo.Trace("GoTo(url: {0}) - uri: {1}", url, uri);

            WebDriver.Navigate().GoToUrl(uri);
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
            LogTo.Trace("Dispose(disposing: {0})", disposing);

            if (!IsDisposed)
            {
                if (disposing)
                {
                    WebServer.StopWebsite();
                }
            }

            IsDisposed = true;
        }
    }
}