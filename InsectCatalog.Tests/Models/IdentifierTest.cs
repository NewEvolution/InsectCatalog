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
                FirstName = "Ryan",
                MiddleName = "J.",
                LastName = "Tanay",
                URL = "http://portfolio.ryantanay.com",
                Email = "rtanay@gmail.com"
            };
            Assert.AreEqual("Ryan", identifier.FirstName);
            Assert.AreEqual("J.", identifier.MiddleName);
            Assert.AreEqual("Tanay", identifier.LastName);
            Assert.AreEqual("http://portfolio.ryantanay.com", identifier.URL);
            Assert.AreEqual("rtanay@gmail.com", identifier.Email);
        }
    }
}
