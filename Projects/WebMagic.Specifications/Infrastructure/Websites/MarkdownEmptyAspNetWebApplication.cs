namespace WebMagic.Specifications.Infrastructure.Websites
{
    public class MarkdownEmptyAspNetWebApplication : WebsiteBase
    {
        public MarkdownEmptyAspNetWebApplication()
            : base(Machine.GetProjectDirectory("Markdown.EmptyAspNetWebApplication"), 1700)
        {
        }
    }
}