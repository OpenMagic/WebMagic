using System.Web.Hosting;
using Anotar.CommonLogging;
using Common.Logging;

namespace WebMagic.Repository
{
    /// <summary>
    ///     Provides a set of methods that enable a Web application to retrieve resources from a
    ///     <see cref="IRepository">repository</see>.
    /// </summary>
    /// <remarks>
    ///     Reference: http://msdn.microsoft.com/en-us/library/system.web.hosting.virtualpathprovider(v=vs.110).aspx
    /// </remarks>
    public class RepositoryPathProvider : VirtualPathProvider
    {
        private readonly IRepository Repository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RepositoryPathProvider" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public RepositoryPathProvider(IRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        ///     Gets a value that indicates whether a directory exists in the virtual file system.
        /// </summary>
        /// <param name="virtualDirectory">The path to the virtual directory.</param>
        /// <returns>
        ///     true if the directory exists in the virtual file system; otherwise, false.
        /// </returns>
        public override bool DirectoryExists(string virtualDirectory)
        {
            // Note: Previous.DirectoryExists must called, not base.DirectoryExists.
            return IsVirtualPath(virtualDirectory) ? Repository.DirectoryExists(VirtualPathToPath(virtualDirectory)) : Previous.DirectoryExists(virtualDirectory);
        }

        /// <summary>
        ///     Gets a virtual directory from the virtual file system.
        /// </summary>
        /// <param name="virtualDirectory">The path to the virtual directory.</param>
        /// <returns>
        ///     A descendant of the <see cref="T:System.Web.Hosting.VirtualDirectory" /> class that represents a directory in the
        ///     virtual file system.
        /// </returns>
        public override VirtualDirectory GetDirectory(string virtualDirectory)
        {
            // Note: Previous.GetDirectory must called, not base.GetDirectory.
            // Note: Previous.GetFile must called, not base.GetFile.
            LogTo.Trace("GetDirectory(virtualDirectory: {0})", virtualDirectory);

            if (IsVirtualPath(virtualDirectory))
            {
                var path = VirtualPathToPath(virtualDirectory);

                LogTo.Trace("Calling Repository.GetDirectory({0}) because {1} is a virtual path.", path, virtualDirectory);
                return Repository.GetDirectory(path);
            }

            LogTo.Trace("Calling Previous.GetDirectory({0}) because virtualDirectory is not a virtual path.", virtualDirectory);
            return Previous.GetDirectory(virtualDirectory);
        }

        /// <summary>
        ///     Gets a virtual file from the virtual file system.
        /// </summary>
        /// <param name="virtualPath">The path to the virtual file.</param>
        /// <returns>
        ///     A descendant of the <see cref="T:System.Web.Hosting.VirtualFile" /> class that represents a file in the virtual
        ///     file system.
        /// </returns>
        public override VirtualFile GetFile(string virtualPath)
        {
            // Note: Previous.GetFile must called, not base.GetFile.
            LogTo.Trace("GetFile(virtualPath: {0})", virtualPath);

            if (IsVirtualPath(virtualPath))
            {
                var path = VirtualPathToPath(virtualPath);

                LogTo.Trace("Calling Repository.GetFile({0}) because {1} is a virtual path.", path, virtualPath);
                return Repository.GetFile(path);
            }

            LogTo.Trace("Calling Previous.GetFile({0}) because virtualPath is not a virtual path.", virtualPath);
            return Previous.GetFile(virtualPath);
        }

        /// <summary>
        ///     Gets a value that indicates whether a file exists in the virtual file system.
        /// </summary>
        /// <param name="virtualPath">The path to the virtual file.</param>
        /// <returns>
        ///     true if the file exists in the virtual file system; otherwise, false.
        /// </returns>
        public override bool FileExists(string virtualPath)
        {
            // Note: Previous.FileExists must called, not base.FileExists.
            return IsVirtualPath(virtualPath) ? Repository.FileExists(VirtualPathToPath(virtualPath)) : Previous.FileExists(virtualPath);
        }

        /// <summary> 
        ///     Determines whether a specified virtual path is within virtual file system. 
        /// </summary> 
        /// <param name="virtualPath">
        ///     An absolute virtual path.
        /// </param>
        /// <returns> 
        ///     true if the virtual path is within the virtual file system; otherwise, false. 
        /// </returns> 
        protected virtual bool IsVirtualPath(string virtualPath)
        {
            return virtualPath.StartsWith("~/");
        }

        protected virtual string VirtualPathToPath(string virtualPath)
        { 
            return virtualPath.Substring(2).Replace('/', '\\');
        }
    }
}