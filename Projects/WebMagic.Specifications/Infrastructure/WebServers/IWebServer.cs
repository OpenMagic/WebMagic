using System.IO;

namespace WebMagic.Specifications.Infrastructure.WebServers
{
    public interface IWebServer
    {
        void StartWebsite(DirectoryInfo projectDirectory, int port);
        void StopWebsite();
    }
}
