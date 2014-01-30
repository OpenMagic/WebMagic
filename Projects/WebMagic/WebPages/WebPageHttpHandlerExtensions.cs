using System.Collections.Generic;
using System.Web.WebPages;

namespace WebMagic.WebPages
{
    public static class WebPageHttpHandlerExtensions
    {
        /// <summary>
        ///     Adds a file name extensions to the list of extensions that are processed by the current WebPageHttpHandler
        ///     instance.
        /// </summary>
        /// <param name="extensions">The extensions to add, without a leading period.</param>
        public static void RegisterExtensions(IEnumerable<string> extensions)
        {
            foreach (var extension in extensions)
            {
                WebPageHttpHandler.RegisterExtension(extension);
            }
        }
    }
}