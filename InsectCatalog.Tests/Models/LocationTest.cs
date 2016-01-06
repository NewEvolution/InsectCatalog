using System;
using InsectCatalog.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsectCatalog.Tests.Models
{
    [TestClass]
    public class LocationTest
    {
        [TestMethod]
        public void LocationEnsureInstanceCreation()
        {
            Location location = new Location();
            Assert.IsNotNull(location);
        }

        [TestMethod]
        public void LocationHasItsProperties()
        {
            Location location = new Location
            {
                LocationId = "7cu",
                Name = "NRC, McMinnville",
                Latitude = 35.707926,
                Longitude = -85.744456
            };
            Assert.AreEqual("7cu", location.LocationId);
            Assert.AreEqual("NRC, McMinnville", location.Name);
            Assert.AreEqual(35.707926, location.Latitude);
            Assert.AreEqual(-85.744456, location.Longitude);
        }
    }
}
