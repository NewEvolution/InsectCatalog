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
                Name = "Cercis canadensis",
                CommonName = "Redbud",
                URL = "https://en.wikipedia.org/wiki/Cercis_canadensis"
            };
            Assert.AreEqual("Cercis canadensis", host.Name);
            Assert.AreEqual("https://en.wikipedia.org/wiki/Cercis_canadensis", host.URL);
        }
    }
}
