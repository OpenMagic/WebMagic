namespace WebMagic.Markdown
{
    public interface IMarkdownParser
    {
        string ToHtml(string markdown);
    }
}