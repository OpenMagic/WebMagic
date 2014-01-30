using System.Linq;
using System.Web.WebPages;
using WebMagic.WebPages;

namespace WebMagic.Markdown
{
    public class MarkdownPages
    {
        public static void Start()
        {
            Start(new MarkdownConfiguration());
        }

        public static void Start(MarkdownConfiguration configuration)
        {
            Start(configuration, new MarkdownVirtualPathFactory(configuration, new MarkdownParser(configuration)));
        }

        public static void Start(MarkdownConfiguration configuration, IVirtualPathFactory virtualPathFactory)
        {
            WebPageHttpHandlerExtensions.RegisterExtensions(configuration.MarkdownExtensions.Select(ext => ext.RemoveLeadingDot()));
            VirtualPathFactoryManager.RegisterVirtualPathFactory(virtualPathFactory);
        }
    }
}