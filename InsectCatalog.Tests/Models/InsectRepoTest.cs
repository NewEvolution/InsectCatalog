using Moq;
using System;
using System.Linq;
using System.Data.Entity;
using InsectCatalog.Models;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsectCatalog.Tests.Models
{
    [TestClass]
    public class InsectRepoTest
    {
        private Mock<InsectContext> mock_context;
        private Mock<DbSet<Insect>> mock_insect_set;
        private Mock<DbSet<Author>> mock_author_set;
        private Mock<DbSet<Collector>> mock_collector_set;
        private Mock<DbSet<Host>> mock_host_set;
        private Mock<DbSet<Identifier>> mock_identifier_set;
        private Mock<DbSet<Location>> mock_location_set;
        private Mock<DbSet<Method>> mock_method_set;

        [TestMethod]
        public void Repo()
        {
        }
    }
}
