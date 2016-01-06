using System;
using InsectCatalog.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsectCatalog.Tests.Models
{
    [TestClass]
    public class MethodTest
    {
        [TestMethod]
        public void MethodEnsureInstanceCreation()
        {
            Method method = new Method();
            Assert.IsNotNull(method);
        }

        [TestMethod]
        public void MethodHasItsProperties()
        {
            Method method = new Method
            {
                MethodId = "4hej",
                Name = "Malaise Trap",
                URL = "http://en.wikipedia.org/wiki/Malaise_Trap"
            };
            Assert.AreEqual("4hej", method.MethodId);
            Assert.AreEqual("Malaise Trap", method.Name);
            Assert.AreEqual("http://en.wikipedia.org/wiki/Malaise_Trap", method.URL);
        }
    }
}
