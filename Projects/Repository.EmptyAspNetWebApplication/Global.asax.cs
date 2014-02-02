using System.Web;
using WebMagic.Markdown;
using WebMagic.Repository;

namespace Repository.EmptyAspNetWebApplication
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            const string pagesDirectory = "~/Pages";

            MarkdownPages.Start(new MarkdownPagesOptions { MarkdownExtensions = new[] { ".md" } });
            RepositoryProvider.Start(new WebDirectoryRepository("~/", Server.MapPath(pagesDirectory)));
        }
    }
}