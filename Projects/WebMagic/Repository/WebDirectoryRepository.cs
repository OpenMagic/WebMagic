using System.IO;
using System.Web.Hosting;
using Anotar.CommonLogging;
using NullGuard;

namespace WebMagic.Repository
{
    public class WebDirectoryRepository : IRepository
    {
        private readonly string RootDirectory;

        public WebDirectoryRepository(string rootDirectory)
        {
            RootDirectory = rootDirectory;
        }

        /// <summary>
        ///     Gets a value that indicates whether a directory exists in the virtual file system.
        /// </summary>
        /// <param name="directory">The path to the virtual directory.</param>
        /// <returns>
        ///     true if the directory exists in the virtual file system; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual bool DirectoryExists(string directory)
        {
            LogTo.Warn("DirectoryExists(directory: {0}) is not supported.", directory);
            return false;
        }

        /// <summary>
        ///     Gets a virtual directory from the virtual file system.
        /// </summary>
        /// <param name="directory">The path to the virtual directory.</param>
        /// <returns>
        ///     A descendant of the <see cref="T:System.Web.Hosting.VirtualDirectory" /> class that represents a directory in the
        ///     virtual file system.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [return: AllowNull]
        public virtual VirtualDirectory GetDirectory(string directory)
        {
            LogTo.Warn("GetDirectory(directory: {0}) is not supported. todo: Why is this being called if DirectoryExists() returns false?", directory);
            return null;
        }

        /// <summary>
        ///     Gets a virtual file from the virtual file system.
        /// </summary>
        /// <param name="path">The path to the virtual file.</param>
        /// <returns>
        ///     A descendant of the <see cref="T:System.Web.Hosting.VirtualFile" /> class that represents a file in the virtual
        ///     file system.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual VirtualFile GetFile(string path)
        {
            return new RepositoryVirtualFile(path, this);
        }

        /// <summary>
        ///     Gets a value that indicates whether a file exists in the virtual file system.
        /// </summary>
        /// <param name="path">The path to the virtual file.</param>
        /// <returns>
        ///     true if the file exists in the virtual file system; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual bool FileExists(string path)
        {
            var fileName = GetFullPath(path);
            var exists = File.Exists(fileName);

            LogTo.Trace("FileExists(path: {0}) => {1}", path, exists);

            return exists;
        }

        public virtual Stream OpenStream(string path)
        {
            var fileName = GetFullPath(path);

            return File.OpenRead(fileName);
        }

        protected virtual string GetFullPath(string path)
        {
            return Path.Combine(RootDirectory, path);
        }

    }
}