using System.Linq;
using System.Web.WebPages;
using WebMagic.WebPages;

namespace WebMagic.Markdown
{
    public class MarkdownPages
    {
        public static void Start()
        {
            Start(new MarkdownPagesOptions());
        }

        public static void Start(MarkdownPagesOptions options)
        {
            Start(options, new MarkdownVirtualPathFactory(options, new MarkdownParser(options)));
        }

        public static void Start(MarkdownPagesOptions options, IVirtualPathFactory virtualPathFactory)
        {
            WebPageHttpHandlerExtensions.RegisterExtensions(options.MarkdownExtensions.Select(ext => ext.RemoveLeadingDot()));
            VirtualPathFactoryManager.RegisterVirtualPathFactory(virtualPathFactory);
        }
    }
}