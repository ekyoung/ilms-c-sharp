using System;
using System.Drawing;
using System.IO;
using EthanYoung.PersonalWebsite.ImageIndexGenerator;
using EthanYoung.PersonalWebsite.ImageManipulation;
using NUnit.Framework;
using Rhino.Mocks;

namespace EthanYoung.PersonalWebsite.Tests.UnitTests
{
    [TestFixture]
    public class Form1PresenterTests
    {
        private Form1Presenter.IView _mockView;
        private IImageResizer _mockImageResizer;
        private IImagePropertyFacade _mockImagePropertyFacade;
        private IFileIO _mockFileIo;

        private Form1Presenter _presenter;

        private const string RootFolderPath = @"C:\Images";
        private static string FullSizeFolderPath = Path.Combine(RootFolderPath, "FullSize");
        private static string WebSizeFolderPath = Path.Combine(RootFolderPath, "WebSize");
        private static string ThumbnailFolderPath = Path.Combine(RootFolderPath, "Thumbnails");

        private const string Image1FileName = "Image1.jpg";
        private readonly string FullSizeImage1FullPath = Path.Combine(FullSizeFolderPath, Image1FileName);
        private readonly string WebSizeImage1FullPath = Path.Combine(WebSizeFolderPath, Image1FileName);
        private readonly string ThumbnailImage1FullPath = Path.Combine(ThumbnailFolderPath, Image1FileName);
        private Image _image1;
        private readonly DateTime _image1DateTaken = DateTime.Now.AddDays(-1);

        private const string Image2FileName = "Image2.jpg";
        private readonly string FullSizeImage2FullPath = Path.Combine(FullSizeFolderPath, Image2FileName);
        private readonly string WebSizeImage2FullPath = Path.Combine(WebSizeFolderPath, Image2FileName);
        private readonly string ThumbnailImage2FullPath = Path.Combine(ThumbnailFolderPath, Image2FileName);
        private Image _image2;
        private readonly DateTime _image2DateTaken = DateTime.Now.AddDays(-5);

        [SetUp]
        public void SetUp()
        {
            _mockView = MockRepository.GenerateMock<Form1Presenter.IView>();
            _mockImageResizer = MockRepository.GenerateMock<IImageResizer>();
            _mockImagePropertyFacade = MockRepository.GenerateMock<IImagePropertyFacade>();
            _mockFileIo = MockRepository.GenerateMock<IFileIO>();

            _presenter = new Form1Presenter(_mockView, _mockImageResizer, _mockImagePropertyFacade, _mockFileIo);

            _image1 = new Bitmap(800, 600);
            _mockFileIo.Stub(x => x.ImageFromFile(FullSizeImage1FullPath)).Return(_image1);
            _mockImagePropertyFacade.Stub(x => x.GetDateTaken(_image1)).Return(_image1DateTaken);
            
            _image2 = new Bitmap(1024, 768);
            _mockFileIo.Stub(x => x.ImageFromFile(FullSizeImage2FullPath)).Return(_image2);
            _mockImagePropertyFacade.Stub(x => x.GetDateTaken(_image2)).Return(_image2DateTaken);

            _mockFileIo.Stub(x => x.GetFiles(FullSizeFolderPath, "*.JPG")).Return(new[] { FullSizeImage1FullPath, FullSizeImage2FullPath });
        }

        [Test]
        public void InAllCases_LoadNewImagesFromFolder_SetsThumbnailPathOnTheView()
        {
            _presenter.LoadNewImagesFromFolder(RootFolderPath, false);

            _mockView.AssertWasCalled(x => x.ThumbnailFolderPath = ThumbnailFolderPath);
        }

        [Test]
        public void GivenFullSizeImageFileNames_LoadNewImagesFromFolder_SetsADataSetContainingImagesOnTheView()
        {
            //TODO: Make .Repeat.Any() ReplacePreviousReturn()
            _mockFileIo.Stub(x => x.GetFiles(FullSizeFolderPath, "*.JPG")).Return(new[] { FullSizeImage1FullPath, FullSizeImage2FullPath }).Repeat.Any();

            _presenter.LoadNewImagesFromFolder(RootFolderPath, false);

            _mockView.AssertWasCalled(x => x.Images = Arg<ImagesDataSet>.Matches(y => y.Images.Count == 2 &&
                y.Images[0].FileName == Image1FileName &&
                y.Images[0].DateTaken == _image1DateTaken &&
                y.Images[1].FileName == Image2FileName &&
                y.Images[1].DateTaken == _image2DateTaken));
        }

        [Test]
        public void GivenResizeImagesIsTrue_LoadNewImagesFromFolder_SavesScaledImages()
        {
            _mockFileIo.Stub(x => x.GetFiles(FullSizeFolderPath, "*.JPG")).Return(new[] { FullSizeImage1FullPath, FullSizeImage2FullPath });

            _presenter.LoadNewImagesFromFolder(RootFolderPath, true);

            _mockImageResizer.AssertWasCalled(x => x.SaveScaledImage(_image1, 1, WebSizeImage1FullPath));
            _mockImageResizer.AssertWasCalled(x => x.SaveScaledImage(_image1, 160f/800, ThumbnailImage1FullPath));
            _mockImageResizer.AssertWasCalled(x => x.SaveScaledImage(_image2, 800f/1024, WebSizeImage2FullPath));
            _mockImageResizer.AssertWasCalled(x => x.SaveScaledImage(_image2, 160f/1024, ThumbnailImage2FullPath));
        }

        [Test]
        public void GivenAnImageWithWidthGreaterThanHeight_GetReductionFactor_ReturnsReductionFactorBasedOnWidth()
        {
            var bitmap = new Bitmap(1024, 768);
            const long maxDimension = 800;

            float reductionFactor = _presenter.GetReductionFactor(bitmap, maxDimension);

            Assert.AreEqual(800/1024f, reductionFactor);
        }

        [Test]
        public void GivenAnImageWithHeightGreaterThanWidth_GetReductionFactor_ReturnsReductionFactorBasedOnHeight()
        {
            var bitmap = new Bitmap(768, 1024);
            const long maxDimension = 800;

            float reductionFactor = _presenter.GetReductionFactor(bitmap, maxDimension);

            Assert.AreEqual(800 / 1024f, reductionFactor);
        }
    }
}