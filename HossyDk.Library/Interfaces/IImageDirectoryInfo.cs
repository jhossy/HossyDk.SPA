using System.IO;

namespace HossyDk.Library.Interfaces
{
    public interface IImageDirectoryInfo
    {
        DirectoryInfo directory { get; }

        string name { get; }

        int noOfImages { get; }

        IImageDirectoryInfo[] subDirectories { get; }
    }
}
