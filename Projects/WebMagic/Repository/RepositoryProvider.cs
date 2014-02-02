using System.Web.Hosting;

namespace WebMagic.Repository
{
    public class RepositoryProvider
    {
        public static void Start(IRepository repository)
        {
            HostingEnvironment.RegisterVirtualPathProvider(new RepositoryPathProvider(repository));
        }
    }
}