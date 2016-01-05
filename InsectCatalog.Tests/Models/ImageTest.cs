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
            Image image = new Image
            {
                S3Id = "TestImageS3id",
                Caption = "This is the caption for this image",
                Display = true
            };
            Assert.IsTrue(image.Display);
            Assert.AreEqual("TestImageS3id", image.S3Id);
            Assert.AreEqual("This is the caption for this image", image.Caption);
        }
    }
}
