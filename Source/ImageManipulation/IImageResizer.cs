using System.Drawing;

namespace EthanYoung.PersonalWebsite.ImageManipulation
{
    public interface IImageResizer
    {
        void SaveScaledImage(Image image, float scaleFactor, string fileName);
    }
}