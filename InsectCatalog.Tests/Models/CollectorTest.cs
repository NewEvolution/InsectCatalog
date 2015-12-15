using System;
using InsectCatalog.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsectCatalog.Tests.Models
{
    [TestClass]
    public class CollectorTest
    {
        [TestMethod]
        public void CollectorEnsureInstanceCreation()
        {
            Collector collector = new Collector();
            Assert.IsNotNull(collector);
        }

        [TestMethod]
        public void CollectorHasItsProperties()
        {
            Collector collector = new Collector
            {
                FirstName = "Ryan",
                MiddleName = "J.",
                LastName = "Tanay",
                URL = "http://portfolio.ryantanay.com",
                Email = "rtanay@gmail.com"
            };
            Assert.AreEqual("Ryan", collector.FirstName);
            Assert.AreEqual("J.", collector.MiddleName);
            Assert.AreEqual("Tanay", collector.LastName);
            Assert.AreEqual("http://portfolio.ryantanay.com", collector.URL);
            Assert.AreEqual("rtanay@gmail.com", collector.Email);
        }
    }
}
