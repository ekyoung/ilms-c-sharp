using System.Drawing;
using System.IO;

namespace EthanYoung.PersonalWebsite.ImageManipulation
{
    public class FileIO : IFileIO
    {
        public string[] GetFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern);
        }

        public Image ImageFromFile(string filename)
        {
            return Image.FromFile(filename);
        }
    }
}