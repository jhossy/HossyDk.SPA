using HossyDk.Library.Interfaces;
using System.IO;
using System;
using System.Linq;

namespace HossyDk.Library
{
    public class ImageDirectoryInfo : IImageDirectoryInfo
    {
        public string name
        {
            get; private set;
        }

        public int noOfImages
        {
            get; private set;
        }

        public DirectoryInfo directory { get; private set; }

        public IImageDirectoryInfo[] subDirectories { get; private set; }
        
        public ImageDirectoryInfo(DirectoryInfo dir)
        {            
            if(dir == null)
            {
                throw new ArgumentNullException("dir");
            }

            name = dir.Name;
            noOfImages = dir.GetFiles("*.png").Length;
            directory = dir;
            subDirectories = dir
                .GetDirectories()
                .Select(x => new ImageDirectoryInfo(x))
                .ToArray();
        }
    }
}
