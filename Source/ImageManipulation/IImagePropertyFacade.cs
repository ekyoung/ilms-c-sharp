using System;
using System.Drawing;

namespace EthanYoung.PersonalWebsite.ImageManipulation
{
    public interface IImagePropertyFacade
    {
        DateTime? GetDateTaken(Image img);
    }
}