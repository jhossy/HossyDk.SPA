using HossyDk.Library.Interfaces;
using System;
using System.Web;
using System.IO;

namespace HossyDk.Library.Repositories
{
    public class ImageRepository : ImageRootPath, IImageRepository
    {
        private readonly string _rootPath;

        public ImageRepository(string rootPath) : base(rootPath)
        {
            _rootPath = rootPath;
        }

        public string AddImage(string imagePath, string metaData)
        {
            throw new NotImplementedException();
        }

        public string GetImage(string imageName, string gallery)
        {
            throw new NotImplementedException();
        }

        public IImageDirectoryInfo[] GetImageDirectories(bool includeImageCount)
        {
            HttpContext currentContext = HttpContext.Current;
            if (string.IsNullOrEmpty(_rootPath) || currentContext == null)
            {
                return new ImageDirectoryInfo[0];
            }

            string rootDir = currentContext.Server.MapPath(_rootPath);
            if(string.IsNullOrEmpty(rootDir))
            {
                return new ImageDirectoryInfo[0];
            }

            if (!Directory.Exists(rootDir))
            {
                Directory.CreateDirectory(rootDir);
            }

            string[] fullPathDirs = Directory.GetDirectories(rootDir, "*", System.IO.SearchOption.AllDirectories);
            ImageDirectoryInfo[] result = new ImageDirectoryInfo[fullPathDirs.Length];

            for(int i = 0; i < result.Length; i++)
            {
                result[i] = new ImageDirectoryInfo()
                {
                    name = Path.GetFileName(fullPathDirs[i]), //todo : add support for multiple levels of directories
                    noOfImages = Directory.GetFiles(fullPathDirs[i]).Length
                };
            }
            return result;
        }
    }
}
