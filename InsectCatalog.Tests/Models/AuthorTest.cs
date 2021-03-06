﻿using System;
using InsectCatalog.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsectCatalog.Tests.Models
{
    [TestClass]
    public class AuthorTest
    {
        [TestMethod]
        public void AuthorEnsureInstanceCreation()
        {
            Author author = new Author();
            Assert.IsNotNull(author);
        }

        [TestMethod]
        public void AuthorHasItsProperties()
        {
            Author author = new Author
            {
                Name = "Linnaeus",
                URL = "http://en.wikipedia.org/wiki/Linnaeus"
            };
            Assert.AreEqual("Linnaeus", author.Name);
            Assert.AreEqual("http://en.wikipedia.org/wiki/Linnaeus", author.URL);
        }
    }
}
