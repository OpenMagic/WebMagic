﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebMagic.Specifications.Infrastructure
{
    public abstract class StepsBase : IDisposable
    {
        private static readonly Lazy<IWebDriver> LazyWebDriver = new Lazy<IWebDriver>(() => new FirefoxDriver());

        private bool IsDisposed;
        protected WebsiteProject WebsiteProject;

        public IWebDriver WebDriver
        {
            get { return LazyWebDriver.Value; }
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

        protected void OpenWebsite(string websiteProject)
        {
            var projectDirectory = Machine.GetProjectDirectory(websiteProject);

            WebsiteProject = new WebsiteProject(WebDriver, projectDirectory, 1700);
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
                    if (WebsiteProject != null)
                    {
                        WebsiteProject.Dispose();
                    }
                }

                WebsiteProject = null;
            }

            IsDisposed = true;
        }
    }
}