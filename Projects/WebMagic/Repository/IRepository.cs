using System.IO;
using System.Web.Hosting;

namespace WebMagic.Repository
{
    public interface IRepository
    {
        /// <summary>
        ///     Gets a value that indicates whether a directory exists in the virtual file system.
        /// </summary>
        /// <param name="virtualDirectory">The path to the virtual directory.</param>
        /// <returns>
        ///     true if the directory exists in the virtual file system; otherwise, false.
        /// </returns>
        bool DirectoryExists(string virtualDirectory);

        /// <summary>
        ///     Gets a virtual directory from the virtual file system.
        /// </summary>
        /// <param name="virtualDirectory">The path to the virtual directory.</param>
        /// <returns>
        ///     A descendant of the <see cref="T:System.Web.Hosting.VirtualDirectory" /> class that represents a directory in the
        ///     virtual file system.
        /// </returns>
        VirtualDirectory GetDirectory(string virtualDirectory);

        /// <summary>
        ///     Gets a virtual file from the virtual file system.
        /// </summary>
        /// <param name="virtualPath">The path to the virtual file.</param>
        /// <returns>
        ///     A descendant of the <see cref="T:System.Web.Hosting.VirtualFile" /> class that represents a file in the virtual
        ///     file system.
        /// </returns>
        VirtualFile GetFile(string virtualPath);

        /// <summary>
        ///     Gets a value that indicates whether a file exists in the virtual file system.
        /// </summary>
        /// <param name="virtualPath">The path to the virtual file.</param>
        /// <returns>
        ///     true if the file exists in the virtual file system; otherwise, false.
        /// </returns>
        bool FileExists(string virtualPath);

        /// <summary>
        /// Returns a read-only stream to the virtual resource.
        /// </summary>
        Stream OpenStream(string virtualPath);

        /// <summary>
        /// Gets the virtual directory for this repository.
        /// </summary>
        string VirtualDirectory { get; }
    }
}