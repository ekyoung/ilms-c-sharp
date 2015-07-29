using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace EthanYoung.PersonalWebsite.ImageManipulation
{
    public class ImagePropertyFacade : IImagePropertyFacade
    {
        public DateTime? GetDateTaken(Image img)
        {
            byte[] exifDTOrigPropertyValue = GetPropertyValue(img, ImagePropertyID.ExifDTOrig);

            if (exifDTOrigPropertyValue.Length == 0)
            {
                return null;
            }

            string dateTimeString = Encoding.UTF8.GetString(exifDTOrigPropertyValue);

            dateTimeString = dateTimeString.Substring(0, 19); //The dateTimeString looks like "2005:10:29 10:48:29" after this line. Before the substring, it has extra stuff on the end.

            DateTime dateTaken;

            if(DateTime.TryParseExact(dateTimeString, "yyyy:MM:dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dateTaken))
            {
                return dateTaken;
            }

            return null;
        }

        public byte[] GetPropertyValue(Image img, ImagePropertyID propertyId)
        {
            PropertyItem prop = img.PropertyItems.FirstOrDefault(x => x.Id == (int) propertyId);

            if (prop == null)
            {
                return new byte[] {};
            }

            return prop.Value;
        }
    }
}
