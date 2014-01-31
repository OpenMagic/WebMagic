using System;
using OpenQA.Selenium;
using WebMagic.Specifications.Infrastructure.Websites;

namespace WebMagic.Specifications.Infrastructure
{
    public abstract class StepsBase : IDisposable
    {
        private bool IsDisposed;
        protected WebsiteBase Website;

        public IWebDriver WebDriver
        {
            get { return Website.WebDriver; }
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

        protected void OpenWebsite(string websiteName)
        {
            Website = (WebsiteBase)Activator.CreateInstance(this.GetType().Assembly.FullName, "WebMagic.Specifications.Infrastructure.Websites." + websiteName).Unwrap(); ;
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
                    if (Website != null)
                    {
                        Website.Dispose();
                    }
                }

                Website = null;
            }

            IsDisposed = true;
        }
    }
}