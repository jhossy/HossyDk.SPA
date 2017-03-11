using HossyDk.Library.Interfaces;
using System;
using System.Web;
using System.IO;
using System.Collections.Generic;

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

            DirectoryInfo rootDirectory = new DirectoryInfo(rootDir);
            
            DirectoryInfo[] dirs = rootDirectory.GetDirectories("*", SearchOption.TopDirectoryOnly);
            List<ImageDirectoryInfo> result = new List<ImageDirectoryInfo>();
            
            foreach(DirectoryInfo dir in dirs)
            {
                result.Add(new ImageDirectoryInfo(dir));
            }

            return result.ToArray();
        }        
    }
}
