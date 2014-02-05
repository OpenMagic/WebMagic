using System.Web.Hosting;

namespace WebMagic.Repository
{
    public class RepositoryProvider
    {
        public static void Start(IRepository repository)
        {
            Start(new RepositoryPathProvider(repository));
        }

        public static void Start(VirtualPathProvider virtualPathProvider)
        {
            HostingEnvironment.RegisterVirtualPathProvider(virtualPathProvider);
        }
    }
}