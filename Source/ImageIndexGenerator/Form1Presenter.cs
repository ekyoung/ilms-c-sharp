using System;
using System.Drawing;
using System.IO;
using EthanYoung.PersonalWebsite.ImageManipulation;

namespace EthanYoung.PersonalWebsite.ImageIndexGenerator
{
    public class Form1Presenter
    {
        private const int ThumbnailMaxDimension = 160;
        private const int WebSizeMaxDimension = 800;

        private readonly IView _view;
        private readonly IImageResizer _imageResizer;
        private readonly IImagePropertyFacade _imagePropertyFacade;
        private readonly IFileIO _fileIo;

        public Form1Presenter(IView view, IImageResizer imageResizer, IImagePropertyFacade imagePropertyFacade, IFileIO fileIo)
        {
            _view = view;
            _imageResizer = imageResizer;
            _imagePropertyFacade = imagePropertyFacade;
            _fileIo = fileIo;
        }

        public void LoadNewImagesFromFolder(string rootFolderPath, bool resizeImages)
        {
            string webSizeFolderPath = Path.Combine(rootFolderPath, "WebSize");
            string fullSizeFolderPath = Path.Combine(rootFolderPath, "FullSize");
            string thumbnailFolderPath = Path.Combine(rootFolderPath, "Thumbnails");

            _view.ThumbnailFolderPath = thumbnailFolderPath;

            string[] fullSizeImageFullPaths = _fileIo.GetFiles(fullSizeFolderPath, "*.JPG");

            var images = new ImagesDataSet();
            foreach (string fullSizeImageFullPath in fullSizeImageFullPaths)
            {
                string fileName = Path.GetFileName(fullSizeImageFullPath);

                Image fullSizeImage = _fileIo.ImageFromFile(fullSizeImageFullPath);

                if (resizeImages)
                {
                    string webSizeImageFullPath = Path.Combine(webSizeFolderPath, fileName);
                    string thumbnailImageFullPath = Path.Combine(thumbnailFolderPath, fileName);

                    _imageResizer.SaveScaledImage(fullSizeImage, GetReductionFactor(fullSizeImage, ThumbnailMaxDimension), thumbnailImageFullPath);
                    _imageResizer.SaveScaledImage(fullSizeImage, GetReductionFactor(fullSizeImage, WebSizeMaxDimension), webSizeImageFullPath);
                }

                //Need to figure out if there's any value to having these flags and remove them from the data set if there isn't
                bool hasFullSize = true; //We always start with a full size. Maybe the thought is that we don't publish it?
                bool hasThumbnail = true; //I don't know why I wouldn't have a thumbnail

                DateTime dateTaken = _imagePropertyFacade.GetDateTaken(fullSizeImage).Value;
                images.Images.AddImagesRow(Guid.NewGuid(), fileName,
                                           Path.GetFileNameWithoutExtension(fullSizeImageFullPath), dateTaken, hasThumbnail,
                                           hasFullSize, null);

                fullSizeImage.Dispose();
            }

            _view.Images = images;
        }

        public void LoadImagesFromIndexFile()
        {
            var ds = new ImagesDataSet();
            ds.ReadXml(_view.IndexFileName);
            _view.Images = ds;
        }

        public void Save()
        {
            if (_view.IndexFileName == null)
            {
                throw new InvalidOperationException("Cannot save while index file name is null.");
            }

            _view.Images.WriteXml(_view.IndexFileName);
        }

        public float GetReductionFactor(Image image, long maxDimension)
        {
            if (image.Width > image.Height)
            {
                return (float) maxDimension/image.Width;
            }

            return (float) maxDimension/image.Height;
        }

        public interface IView
        {
            ImagesDataSet Images { get; set; }
            string IndexFileName { get; set; }
            string ThumbnailFolderPath { get; set; }
        }
    }
}