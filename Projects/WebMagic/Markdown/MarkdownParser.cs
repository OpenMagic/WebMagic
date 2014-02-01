namespace WebMagic.Markdown
{
    public class MarkdownParser : IMarkdownParser
    {
        private readonly MarkdownSharp.Markdown Parser;

        public MarkdownParser(MarkdownPagesOptions options)
        {
            Parser = new MarkdownSharp.Markdown(options.MarkdownSharpOptions);
        }

        public string ToHtml(string markdown)
        {
            return Parser.Transform(markdown);
        }
    }
}