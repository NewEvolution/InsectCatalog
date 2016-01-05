using System;
using InsectCatalog.Models;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsectCatalog.Tests.Models
{
    [TestClass]
    public class InsectTest
    {
        [TestMethod]
        public void InsectEnsureInstanceCreation()
        {
            Insect insect = new Insect();
            Assert.IsNotNull(insect);
        }

        [TestMethod]
        public void InsectHasItsProperties()
        {
            DateTime today = DateTime.Today;
            Person IdBy = new Person
            {
                FirstName = "Ryan",
                MiddleName = "J.",
                LastName = "Tanay",
                URL = "http://portfolio.ryantanay.com",
                Email = "rtanay@gmail.com"
            };
            Person CollBy = new Person
            {
                FirstName = "Ryan",
                MiddleName = "J.",
                LastName = "Tanay",
                URL = "http://portfolio.ryantanay.com",
                Email = "rtanay@gmail.com"
            };
            Author author = new Author
            {
                Name = "Linnaeus",
                URL = "http://en.wikipedia.org/wiki/Linnaeus"
            };
            Host host = new Host
            {
                Name = "Cercis canadensis",
                CommonName = "Redbud",
                URL = "https://en.wikipedia.org/wiki/Cercis_canadensis"
            };
            Method method = new Method
            {
                Name = "Malaise Trap",
                URL = "http://en.wikipedia.org/wiki/Malaise_Trap"
            };
            Location location = new Location
            {
                Name = "NRC McMinnville",
                Latitude = 35.707926,
                Longitude = -85.744456
            };
            Image image1 = new Image
            {
                S3Id = "TestImage1id",
                Caption = "This is a test image caption for image 1",
                Display = true,
                Photographer = new Person
                {
                    FirstName = "Ryan",
                    MiddleName = "J.",
                    LastName = "Tanay",
                    URL = "http://portfolio.ryantanay.com",
                    Email = "rtanay@gmail.com"
                }
            };
            Image image2 = new Image
            {
                S3Id = "TestImage2id",
                Caption = "This is a test image caption for image 2",
                Display = false,
                Photographer = new Person
                {
                    FirstName = "Ryan",
                    MiddleName = "J.",
                    LastName = "Tanay",
                    URL = "http://portfolio.ryantanay.com",
                    Email = "rtanay@gmail.com"
                }
            };
            Image image3 = new Image
            {
                S3Id = "TestImage3id",
                Caption = "This is a test image caption for image 3",
                Display = false,
                Photographer = new Person
                {
                    FirstName = "Ryan",
                    MiddleName = "J.",
                    LastName = "Tanay",
                    URL = "http://portfolio.ryantanay.com",
                    Email = "rtanay@gmail.com"
                }
            };
            List<Image> images = new List<Image>() { image1, image2, image3 };
            Insect insect = new Insect
            {
                Family = "Cerambycidae",
                Tribe = "Aseminae",
                Genus = "Atimia",
                Species = "confusa",
                Subspecies = "confusa",
                County = "Warren",
                CollectionDate = today,
                Identifier = IdBy,
                Collector = CollBy,
                Author = author,
                Host = host,
                Description = "Some informational text on the specimen and/or species",
                Method = method,
                Location = location,
                Images = images
            };
            Assert.AreEqual("Cerambycidae", insect.Family);
            Assert.AreEqual("Aseminae", insect.Tribe);
            Assert.AreEqual("Atimia", insect.Genus);
            Assert.AreEqual("confusa", insect.Species);
            Assert.AreEqual("confusa", insect.Subspecies);
            Assert.AreEqual("Warren", insect.County);
            Assert.AreEqual(today, insect.CollectionDate);
            Assert.AreEqual(IdBy, insect.Identifier);
            Assert.AreEqual(author, insect.Author);
            Assert.AreEqual(host, insect.Host);
            Assert.AreEqual(method, insect.Method);
            Assert.AreEqual(location, insect.Location);
            CollectionAssert.AreEqual(images, insect.Images);
        }
    }
}
