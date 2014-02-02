using System;
using System.Web;
using System.Web.Hosting;
using Anotar.CommonLogging;

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
            return IsPathVirtual(virtualDirectory) ? Repository.DirectoryExists(virtualDirectory) : Previous.DirectoryExists(virtualDirectory);
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
            return IsPathVirtual(virtualDirectory) ? Repository.GetDirectory(virtualDirectory) : Previous.GetDirectory(virtualDirectory);
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
            return IsPathVirtual(virtualPath) ? Repository.GetFile(virtualPath) : Previous.GetFile(virtualPath);
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
            return IsPathVirtual(virtualPath) ? Repository.FileExists(virtualPath) : Previous.FileExists(virtualPath);
        }

        /// <summary> 
        ///     Determines whether a specified virtual path is within virtual file system. 
        /// </summary> 
        /// <param name="virtualPath">An absolute virtual path.</param>
        /// <returns> 
        ///   true if the virtual path is within the virtual file system; otherwise, false. 
        /// </returns> 
        private bool IsPathVirtual(string virtualPath)
        {
            if (!virtualPath.StartsWith("~/"))
            {
                return false;
            }

            var checkPath = VirtualPathUtility.ToAppRelative(virtualPath);
            var result = checkPath.StartsWith(Repository.VirtualDirectory, StringComparison.InvariantCultureIgnoreCase);

            LogTo.Trace("IsPathVirtual(virtualPath: {0}) - checkPath: {1} => {2}", virtualPath, checkPath, result);

            return result;
        }
    }
}