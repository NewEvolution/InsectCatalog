﻿using System;
using InsectCatalog.Models;
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
            Insect insect = new Insect
            {
                Family = "Cerambycidae",
                Tribe = "Aseminae",
                Genus = "Atimia",
                Species = "confusa",
                Subspecies = "confusa",
                County = "Warren",
                CollectionDate = today,
                IdentifiedBy = IdBy,
                CollectedBy = CollBy,
                NameAuthor = author,
                HostPlant = host,
                Description = "Some informational text on the specimen and/or species",
                CollectionMethod = method,
                CollectionLocation = location
            };
            Assert.AreEqual("Cerambycidae", insect.Family);
            Assert.AreEqual("Aseminae", insect.Tribe);
            Assert.AreEqual("Atimia", insect.Genus);
            Assert.AreEqual("confusa", insect.Species);
            Assert.AreEqual("confusa", insect.Subspecies);
            Assert.AreEqual("Warren", insect.County);
            Assert.AreEqual(today, insect.CollectionDate);
            Assert.AreEqual(IdBy, insect.IdentifiedBy);
            Assert.AreEqual(author, insect.NameAuthor);
            Assert.AreEqual(host, insect.HostPlant);
            Assert.AreEqual(method, insect.CollectionMethod);
        }
    }
}
