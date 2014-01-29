using System.IO;

namespace WebMagic.Specifications.Infrastructure
{
    public static class DirectoryInfoExtensions
    {
        public static DirectoryInfo MustExist(this DirectoryInfo directory)
        {
            if (directory.Exists)
            {
                return directory;
            }

            throw new DirectoryNotFoundException(string.Format("Cannot find '{0}'.", directory.FullName));
        }
    }
}