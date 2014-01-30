using System.IO;
using System.Web.Hosting;
using System.Web.WebPages;

namespace WebMagic.Markdown
{
    public class MarkdownWebPage : WebPage
    {
        private readonly IMarkdownParser MarkdownParser;

        public MarkdownWebPage(IMarkdownParser markdownParser)
        {
            MarkdownParser = markdownParser;
        }

        public override void Execute()
        {
            var markdown = ReadMarkdown();
            var html = MarkdownParser.ToHtml(markdown);

            WriteLiteral(html);
        }

        private string ReadMarkdown()
        {
            var virtualFile = HostingEnvironment.VirtualPathProvider.GetFile(VirtualPath);

            using (var stream = virtualFile.Open())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}