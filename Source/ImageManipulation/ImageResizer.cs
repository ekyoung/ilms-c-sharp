using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace EthanYoung.PersonalWebsite.ImageManipulation
{
    public class ImageResizer : IImageResizer
    {
        public Bitmap ResizeJpeg(Image sourcePhoto, int width, int height)
        {
            if (sourcePhoto == null)
            {
                throw new ArgumentNullException("sourcePhoto");
            }

            if (width <= 0)
            {
                throw new ArgumentException("Width must be greater than 0.");
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height must be greater than 0.");
            }

            int sourceWidth = sourcePhoto.Width;
            int sourceHeight = sourcePhoto.Height;

            var destPhoto = new Bitmap(sourcePhoto, width, height);
            destPhoto.SetResolution(sourcePhoto.HorizontalResolution, sourcePhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(destPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(sourcePhoto, new Rectangle(0, 0, width, height), new Rectangle(0, 0, sourceWidth, sourceHeight), GraphicsUnit.Pixel);
            grPhoto.Dispose();

            foreach (PropertyItem propertyItem in sourcePhoto.PropertyItems)
            {
                destPhoto.SetPropertyItem(propertyItem);
            }

            return destPhoto;
        }

        public Bitmap Scale(Image image, float scaleFactor)
        {
            return ResizeJpeg(image, (int)(image.Width*scaleFactor), (int)(image.Height*scaleFactor));
        }

        public void SaveScaledImage(Image image, float scaleFactor, string fileName)
        {
            Image smallerImage = Scale(image, scaleFactor);

            var enc = Encoder.Quality;
            var encParms = new EncoderParameters(1);
            var encParm = new EncoderParameter(enc, 100L);
            encParms.Param[0] = encParm;

            var codecInfo = ImageCodecInfo.GetImageEncoders();
            var codecInfoJpeg = codecInfo[1];

            smallerImage.Save(fileName, codecInfoJpeg, encParms);
            smallerImage.Dispose();
        }

    }
}
