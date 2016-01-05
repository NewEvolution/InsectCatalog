using System;
using InsectCatalog.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsectCatalog.Tests.Models
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void PersonEnsureInstanceCreation()
        {
            Person person = new Person();
            Assert.IsNotNull(person);
        }

        [TestMethod]
        public void PersonHasItsProperties()
        {
            Person person = new Person
            {
                FirstName = "Ryan",
                MiddleName = "J.",
                LastName = "Tanay",
                URL = "http://portfolio.ryantanay.com",
                Email = "rtanay@gmail.com"
            };
            Assert.AreEqual("Ryan", person.FirstName);
            Assert.AreEqual("J.", person.MiddleName);
            Assert.AreEqual("Tanay", person.LastName);
            Assert.AreEqual("http://portfolio.ryantanay.com", person.URL);
            Assert.AreEqual("rtanay@gmail.com", person.Email);
        }
    }
}
