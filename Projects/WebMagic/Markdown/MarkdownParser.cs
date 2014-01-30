namespace WebMagic.Markdown
{
    public class MarkdownParser : IMarkdownParser
    {
        private readonly MarkdownSharp.Markdown Parser;

        public MarkdownParser(MarkdownConfiguration configuration)
        {
            Parser = new MarkdownSharp.Markdown(configuration.MarkdownSharpOptions);
        }

        public string ToHtml(string markdown)
        {
            return Parser.Transform(markdown);
        }
    }
}