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
            Identifier IdBy = new Identifier
            {
                FirstName = "Ryan",
                MiddleName = "J.",
                LastName = "Tanay",
                URL = "http://portfolio.ryantanay.com",
                Email = "rtanay@gmail.com"
            };
            Collector CollBy = new Collector
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
                Caption = "This is a test image caption for image 1"
            };
            Image image2 = new Image
            {
                S3Id = "TestImage2id",
                Caption = "This is a test image caption for image 2"
            };
            Image image3 = new Image
            {
                S3Id = "TestImage3id",
                Caption = "This is a test image caption for image 3"
            };
            List<string> imageIdList = new List<string>() { image1.ImageId, image2.ImageId, image3.ImageId };
            Insect insect = new Insect
            {
                Family = "Cerambycidae",
                Tribe = "Aseminae",
                Genus = "Atimia",
                Species = "confusa",
                Subspecies = "confusa",
                County = "Warren",
                CollectionDate = today,
                IdentifierId = IdBy.IdentifierId,
                CollectorId = CollBy.CollectorId,
                AuthorId = author.AuthorId,
                HostId = host.HostId,
                Description = "Some informational text on the specimen and/or species",
                MethodId = method.MethodId,
                LocationId = location.LocationId,
                ImageIds = imageIdList
            };
            Assert.AreEqual("Cerambycidae", insect.Family);
            Assert.AreEqual("Aseminae", insect.Tribe);
            Assert.AreEqual("Atimia", insect.Genus);
            Assert.AreEqual("confusa", insect.Species);
            Assert.AreEqual("confusa", insect.Subspecies);
            Assert.AreEqual("Warren", insect.County);
            Assert.AreEqual(today, insect.CollectionDate);
            Assert.AreEqual(IdBy.IdentifierId, insect.IdentifierId);
            Assert.AreEqual(author.AuthorId, insect.AuthorId);
            Assert.AreEqual(host.HostId, insect.HostId);
            Assert.AreEqual(method.MethodId, insect.MethodId);
            Assert.AreEqual(location.LocationId, insect.LocationId);
            CollectionAssert.AreEqual(imageIdList, insect.ImageIds);
        }
    }
}
