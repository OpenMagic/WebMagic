using System;
using System.IO;
using System.Web.Hosting;
using Anotar.CommonLogging;
using NullGuard;

namespace WebMagic.Repository
{
    public class WebDirectoryRepository : IRepository
    {
        private readonly string RootDirectory;

        public WebDirectoryRepository(string virtualDirectory, string rootDirectory)
        {
            VirtualDirectory = virtualDirectory;
            RootDirectory = rootDirectory;
        }

        /// <summary>
        ///     Gets a value that indicates whether a directory exists in the virtual file system.
        /// </summary>
        /// <param name="virtualDirectory">The path to the virtual directory.</param>
        /// <returns>
        ///     true if the directory exists in the virtual file system; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool DirectoryExists(string virtualDirectory)
        {
            LogTo.Warn("DirectoryExists(virtualDirectory: {0}) is not supported.", virtualDirectory);
            return false;
        }

        /// <summary>
        ///     Gets a virtual directory from the virtual file system.
        /// </summary>
        /// <param name="virtualDirectory">The path to the virtual directory.</param>
        /// <returns>
        ///     A descendant of the <see cref="T:System.Web.Hosting.VirtualDirectory" /> class that represents a directory in the
        ///     virtual file system.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [return: AllowNull]
        public VirtualDirectory GetDirectory(string virtualDirectory)
        {
            LogTo.Warn("GetDirectory(virtualDirectory: {0}) is not supported. todo: Why is this being called if DirectoryExists() returns false?", virtualDirectory);
            return null;
        }

        /// <summary>
        ///     Gets a virtual file from the virtual file system.
        /// </summary>
        /// <param name="virtualPath">The path to the virtual file.</param>
        /// <returns>
        ///     A descendant of the <see cref="T:System.Web.Hosting.VirtualFile" /> class that represents a file in the virtual
        ///     file system.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [return: AllowNull]
        public VirtualFile GetFile(string virtualPath)
        {
            // todo: delete
            //if (!FileExists(virtualPath))
            //{
            //    LogTo.Warn("GetFile(virtualPath: {0}). todo: Why is this being called if GetFile() has not already been called?", virtualPath);
            //    return null;
            //}
            return new RepositoryVirtualFile(virtualPath, this);
        }

        /// <summary>
        ///     Gets a value that indicates whether a file exists in the virtual file system.
        /// </summary>
        /// <param name="virtualPath">The path to the virtual file.</param>
        /// <returns>
        ///     true if the file exists in the virtual file system; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool FileExists(string virtualPath)
        {
            var fileName = GetFileName(virtualPath);
            var exists = File.Exists(fileName);

            LogTo.Trace("FileExists(virtualPath: {0}) - fileName: {1} => {2}", virtualPath, fileName, exists);

            return exists;
        }

        public Stream OpenStream(string virtualPath)
        {
            var fileName = GetFileName(virtualPath);

            return File.OpenRead(fileName);
        }

        public string VirtualDirectory { get; private set; }

        private string GetFileName(string virtualPath)
        {
            return Path.Combine(RootDirectory, VirtualPathToFileName(virtualPath));
        }

        private static string VirtualPathToFileName(string virtualPath)
        {
            var substringIndex = 0;

            if (virtualPath.StartsWith("~/"))
            {
                substringIndex = 2;
            }
            else if (virtualPath.StartsWith("/"))
            {
                substringIndex = 1;
            }
            else
            {
                throw new ArgumentException(string.Format("Expected virtualPath, {0}, to start with '/' or '~/'.", virtualPath), "virtualPath");
            }

            return virtualPath.Substring(substringIndex).Replace('/', '\\');
        }
    }
}