using System;
using InsectCatalog.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsectCatalog.Tests.Models
{
    [TestClass]
    public class HostTest
    {
        [TestMethod]
        public void HostEnsureInstanceCreation()
        {
            Host host = new Host();
            Assert.IsNotNull(host);
        }

        [TestMethod]
        public void HostHasItsProperties()
        {
            Host host = new Host
            {
                HostId = "3248kjf",
                Name = "Cercis canadensis",
                CommonName = "Redbud",
                URL = "https://en.wikipedia.org/wiki/Cercis_canadensis"
            };
            Assert.AreEqual("3248kjf", host.HostId);
            Assert.AreEqual("Cercis canadensis", host.Name);
            Assert.AreEqual("https://en.wikipedia.org/wiki/Cercis_canadensis", host.URL);
        }
    }
}
