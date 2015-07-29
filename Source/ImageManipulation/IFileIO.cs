using System.Drawing;

namespace EthanYoung.PersonalWebsite.ImageManipulation
{
    public interface IFileIO
    {
        string[] GetFiles(string path, string searchPattern);
        Image ImageFromFile(string filename);
    }
}