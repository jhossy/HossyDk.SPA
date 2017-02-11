namespace HossyDk.Library.Interfaces
{
    public interface IImageRepository
    {
        IImageDirectoryInfo[] GetImageDirectories(bool includeImageCount);

        string GetImage(string imageName, string gallery);

        string AddImage(string imagePath, string metaData);
    }
}
