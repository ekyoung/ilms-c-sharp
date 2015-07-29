using System.Drawing;
using EthanYoung.PersonalWebsite.ImageManipulation;
using NUnit.Framework;

namespace EthanYoung.PersonalWebsite.Tests.UnitTests
{
    [TestFixture]
    public class ImageResizerTests
    {
        private ImageResizer _imageResizer;

        [SetUp]
        public void SetUp()
        {
            _imageResizer = new ImageResizer();
        }

        [Test]
        public void InAllCases_Scale_ReturnsAnImageWithTheScaledDimensions()
        {
            var originalBitmap = new Bitmap(1024, 768);

            var scaledBitmap = _imageResizer.Scale(originalBitmap, .75f);

            Assert.AreEqual(1024*.75f, scaledBitmap.Width);
            Assert.AreEqual(768*.75f, scaledBitmap.Height);
        }
    }
}