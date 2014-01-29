using System;
using System.IO;
using System.Linq;

namespace WebMagic.Specifications.Infrastructure
{
    /// <summary>
    ///     Collection of methods to get settings, folders & files for the current machine.
    /// </summary>
    internal class Machine
    {
        internal static DirectoryInfo GetProjectDirectory(string projectName)
        {
            return new DirectoryInfo(Path.Combine(GetSolutionDirectory().FullName, "Projects", projectName)).MustExist();
        }

        internal static DirectoryInfo GetSolutionDirectory()
        {
            var directory = new DirectoryInfo(Environment.CurrentDirectory);

            while (!directory.EnumerateFiles("WebMagic.sln").Any())
            {
                directory = directory.Parent;

                if (directory == null)
                {
                    throw new DirectoryNotFoundException("Cannot find solution directory.");
                }
            }

            return directory;
        }
    }
}