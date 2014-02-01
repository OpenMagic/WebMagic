using System.Web;
using WebMagic.Markdown;

namespace Repository.EmptyAspNetWebApplication
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            MarkdownPages.Start();
        }
   }
}