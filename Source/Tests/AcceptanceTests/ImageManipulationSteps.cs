using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using EthanYoung.PersonalWebsite.ImageManipulation;
using EthanYoung.PersonalWebsite.Tests.Properties;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace EthanYoung.PersonalWebsite.Tests.AcceptanceTests
{
    [Binding]
    public class ImageManipulationSteps
    {
        private Image _sampleImage;
        private Image _outputImage;

        private readonly ImagePropertyFacade _imagePropertyFacade = new ImagePropertyFacade();
        private readonly ImageResizer _imageResizer = new ImageResizer();

        private readonly string _sampleImagesFolderPath;
        private readonly string _outputFilesFolderPath;

        public ImageManipulationSteps()
        {
            string localDevSettingsPrefix = string.Format("LocalDev-{0}-{1}", Environment.MachineName, Environment.UserName);
            var settings = (ClientSettingsSection)ConfigurationManager.GetSection("applicationSettings/EthanYoung.PersonalWebsite.Tests.Properties.Settings");
            
            string sampleImagesFolderPathPropertyName = localDevSettingsPrefix + "_" + "SampleImagesFolderPath";
            _sampleImagesFolderPath = settings.Settings.Get(sampleImagesFolderPathPropertyName) != null
                                          ? settings.Settings.Get(sampleImagesFolderPathPropertyName).Value.ValueXml.InnerText
                                          : Settings.Default.SampleImagesFolderPath;

            string outputFilesFolderPathPropertyName = localDevSettingsPrefix + "_" + "OutputFilesFolderPath";
            _outputFilesFolderPath = settings.Settings.Get(outputFilesFolderPathPropertyName) != null
                ? settings.Settings.Get(outputFilesFolderPathPropertyName).Value.ValueXml.InnerText
                : Settings.Default.OutputFilesFolderPath;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _sampleImage = null;
            _outputImage = null;

            if (!Directory.Exists(_outputFilesFolderPath))
            {
                Directory.CreateDirectory(_outputFilesFolderPath);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_sampleImage != null)
            {
                _sampleImage.Dispose();
            }

            if (_outputImage != null)
            {
                _outputImage.Dispose();
            }

            foreach (string filePath in Directory.GetFiles(_outputFilesFolderPath))
            {
                File.Delete(filePath);
            }
        }

        [Given(@"a sample image named ""(.*)""")]
        public void GivenASampleImageNamed(string fileName)
        {
            string filePath = Path.Combine(_sampleImagesFolderPath, fileName);
            _sampleImage = Image.FromFile(filePath);
        }

        [When(@"I save the sample image with a scale factor of (.*) and file name ""(.*)""")]
        public void WhenISaveTheSampleImageWithAScaleFactorAndFileName(float scaleFactor, string fileName)
        {
            string filePath = Path.Combine(_outputFilesFolderPath, fileName);
            _imageResizer.SaveScaledImage(_sampleImage, scaleFactor, filePath);
            _outputImage = Image.FromFile(filePath);
        }

        [Then(@"the output image should have dimensions of (.*)x(.*)")]
        public void ThenTheOutputImageShouldHaveDimensionsOf(int width, int height)
        {
            Assert.AreEqual(width, _outputImage.Width);
            Assert.AreEqual(height, _outputImage.Height);
        }

        [Then(@"the date taken of the sample image is (.*)")]
        public void ThenTheDateTakenOfTheSampleImageIs(DateTime dateTaken)
        {
            Assert.AreEqual(dateTaken, _imagePropertyFacade.GetDateTaken(_sampleImage));
        }

        [Then(@"the date taken of the sample image is null")]
        public void ThenTheDateTakenOfTheSampleImageIsNull()
        {
            Assert.IsNull(_imagePropertyFacade.GetDateTaken(_sampleImage));
        }

        [Then(@"the date taken of the output image should be the same as the date taken of the sample image")]
        public void ThenTheDateTakenOfTheOutputImageShouldBeTheSameAsTheDateTakenOfTheSampleImage()
        {
            Assert.AreEqual(_imagePropertyFacade.GetDateTaken(_sampleImage), _imagePropertyFacade.GetDateTaken(_outputImage));
        }

    }
}
