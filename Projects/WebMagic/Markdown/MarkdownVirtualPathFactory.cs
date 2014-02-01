using System;
using System.Linq;
using System.Web.Hosting;
using System.Web.WebPages;

namespace WebMagic.Markdown
{
    /// <summary>
    ///     Virtual path factory for markdown files.
    /// </summary>
    public class MarkdownVirtualPathFactory : IVirtualPathFactory
    {
        private readonly string[] MarkdownExtensions;
        private readonly IMarkdownParser MarkdownParser;

        public MarkdownVirtualPathFactory(MarkdownPagesOptions options, MarkdownParser markdownParser)
        {
            MarkdownExtensions = options.MarkdownExtensions.Select(ext => ext.AddLeadingDot()).ToArray();
            MarkdownParser = markdownParser;
        }

        /// <summary>
        ///     Creates a handler factory for the specified virtual path.
        /// </summary>
        /// <param name="virtualPath">
        ///     The virtual path.
        /// </param>
        /// <returns>
        ///     A handler factory for the specified virtual path.
        /// </returns>
        public object CreateInstance(string virtualPath)
        {
            return new MarkdownWebPage(MarkdownParser);
        }

        /// <summary>
        ///     Determines whether the specified virtual path is associated with a handler factory.
        /// </summary>
        /// <param name="virtualPath">
        ///     The virtual path.
        /// </param>
        /// <returns>
        ///     true if a handler factory exists for the specified virtual path; otherwise, false.
        /// </returns>
        public bool Exists(string virtualPath)
        {
            return HasMarkdownExtension(virtualPath) && HostingEnvironment.VirtualPathProvider.FileExists(virtualPath);
        }

        private bool HasMarkdownExtension(string virtualPath)
        {
            return MarkdownExtensions.Any(e => virtualPath.EndsWith(e, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}