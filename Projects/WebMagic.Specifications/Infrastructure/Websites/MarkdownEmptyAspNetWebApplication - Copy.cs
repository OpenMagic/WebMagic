namespace WebMagic.Specifications.Infrastructure.Websites
{
    public class RepositoryEmptyAspNetWebApplication : WebsiteBase
    {
        public RepositoryEmptyAspNetWebApplication()
            : base(Machine.GetProjectDirectory("Repository.EmptyAspNetWebApplication"), 1701)
        {
        }
    }
}