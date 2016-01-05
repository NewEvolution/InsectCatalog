using System;
using InsectCatalog.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsectCatalog.Tests.Models
{
    [TestClass]
    public class ImageTest
    {
        [TestMethod]
        public void ImageEnsureInstanceCreation()
        {
            Image image = new Image();
            Assert.IsNotNull(image);
        }

        [TestMethod]
        public void ImageHasItsProperties()
        {
            Person photographer = new Person
            {
                FirstName = "Ryan",
                MiddleName = "J.",
                LastName = "Tanay",
                URL = "http://portfolio.ryantanay.com",
                Email = "rtanay@gmail.com"
            };
            Image image = new Image
            {
                S3Id = "TestImageS3id",
                Caption = "This is the caption for this image",
                Display = true,
                Photographer = photographer
            };
            Assert.IsTrue(image.Display);
            Assert.AreEqual("TestImageS3id", image.S3Id);
            Assert.AreEqual(photographer, image.Photographer);
            Assert.AreEqual("This is the caption for this image", image.Caption);
        }
    }
}
