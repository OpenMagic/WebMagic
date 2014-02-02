﻿using System;
using System.IO;
using Anotar.CommonLogging;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebMagic.Specifications.Infrastructure.WebServers;

namespace WebMagic.Specifications.Infrastructure.Websites
{
    public abstract class WebsiteBase : IDisposable
    {
        private readonly Uri Uri;
        private readonly IWebServer WebServer;

        private bool IsDisposed;

        protected WebsiteBase(DirectoryInfo projectDirectory, int port)
            : this(new IISExpressWebServer(), projectDirectory, port)
        {
        }

        protected WebsiteBase(IWebServer webServer, DirectoryInfo projectDirectory, int port)
        {
            LogTo.Trace("WebsiteBase(webServer, projectDirectory: {0}, port: {1})", projectDirectory, port);

            WebServer = webServer;
            Uri = new Uri(string.Format("http://localhost:{0}", port));

            WebServer.StartWebsite(projectDirectory, port);
            WebDriver = new FirefoxDriver();
        }

        public IWebDriver WebDriver { get; private set; }

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
            if (!IsDisposed)
            {
                if (disposing)
                {
                    WebServer.StopWebsite();
                    WebDriver.Dispose();
                }

                WebDriver = null;
            }

            IsDisposed = true;
        }
    }
}