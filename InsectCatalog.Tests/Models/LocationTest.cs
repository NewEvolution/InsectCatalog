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
        }

        [TestMethod]
        public void LocationHasItsProperties()
        {
            Location location = new Location
            {
                Name = "NRC McMinnville",
                Latitude = 35.707926,
                Longitude = -85.744456
            };
        }
    }
}
