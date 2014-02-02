using System;
using System.IO;
using System.Web.Hosting;

namespace WebMagic.Repository
{
    public class RepositoryVirtualFile : VirtualFile
    {
        private readonly IRepository Repository;

        public RepositoryVirtualFile(string virtualPath, IRepository repository) : base(virtualPath)
        {
            Repository = repository;
        }

        /// <summary>
        /// When overridden in a derived class, returns a read-only stream to the virtual resource.
        /// </summary>
        /// <returns>
        /// A read-only stream to the virtual file.
        /// </returns>
        public override Stream Open()
        {
            return Repository.OpenStream(VirtualPath);
        }
    }
}