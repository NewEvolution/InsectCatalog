using System;
using InsectCatalog.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsectCatalog.Tests.Models
{
    [TestClass]
    public class IdentifierTest
    {
        [TestMethod]
        public void IdentifierEnsureInstanceCreation()
        {
            Identifier identifier = new Identifier();
            Assert.IsNotNull(identifier);
        }

        [TestMethod]
        public void IdentifierHasItsProperties()
        {
            Identifier identifier = new Identifier
            {
                Name = "Ryan J. Tanay",
                URL = "http://portfolio.ryantanay.com",
                Email = "rtanay@gmail.com"
            };
            Assert.AreEqual("Ryan J. Tanay", identifier.Name);
            Assert.AreEqual("http://portfolio.ryantanay.com", identifier.URL);
            Assert.AreEqual("rtanay@gmail.com", identifier.Email);
        }
    }
}
