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
            var result = IsVirtualPath(virtualDirectory) ? Repository.DirectoryExists(VirtualPathToPath(virtualDirectory)) : Previous.DirectoryExists(virtualDirectory);

            LogTo.Trace("DirectoryExists({0}) => {1}", virtualDirectory, result);

            return result;
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
            return IsVirtualPath(virtualDirectory) ? Repository.GetDirectory(VirtualPathToPath(virtualDirectory)) : Previous.GetDirectory(virtualDirectory);
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
            return IsVirtualPath(virtualPath) ? Repository.GetFile(VirtualPathToPath(virtualPath)) : Previous.GetFile(virtualPath);
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
            var result = IsVirtualPath(virtualPath) ? Repository.FileExists(VirtualPathToPath(virtualPath)) : Previous.FileExists(virtualPath);

            LogTo.Trace("FileExists({0}) => {1}", virtualPath, result);

            return result;
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
            var result =  virtualPath.StartsWith("~/");

            LogTo.Trace("IsVirtualPath({0}) => {1}", virtualPath, result);

            return result;
        }

        protected virtual string VirtualPathToPath(string virtualPath)
        {
            var result = virtualPath.Substring(2).Replace('/', '\\');

            LogTo.Trace("VirtualPathToPath({0}) => {1}", virtualPath, result);

            return result;
        }
    }
}