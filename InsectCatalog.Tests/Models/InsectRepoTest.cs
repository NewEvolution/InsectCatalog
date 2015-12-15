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
        private InsectRepository repo;

        private void ConnectMocksToDataStore(IEnumerable<Insect> data_store)
        {
            var data_source = data_store.AsQueryable();
            mock_insect_set.As<IQueryable<Insect>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_insect_set.As<IQueryable<Insect>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_insect_set.As<IQueryable<Insect>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_insect_set.As<IQueryable<Insect>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.Insects).Returns(mock_insect_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Author> data_store)
        {
            var data_source = data_store.AsQueryable();
            mock_author_set.As<IQueryable<Author>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_author_set.As<IQueryable<Author>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_author_set.As<IQueryable<Author>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_author_set.As<IQueryable<Author>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.Authors).Returns(mock_author_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Collector> data_store)
        {
            var data_source = data_store.AsQueryable();
            mock_collector_set.As<IQueryable<Collector>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_collector_set.As<IQueryable<Collector>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_collector_set.As<IQueryable<Collector>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_collector_set.As<IQueryable<Collector>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.Collectors).Returns(mock_collector_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Host> data_store)
        {
            var data_source = data_store.AsQueryable();
            mock_host_set.As<IQueryable<Host>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_host_set.As<IQueryable<Host>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_host_set.As<IQueryable<Host>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_host_set.As<IQueryable<Host>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.Hosts).Returns(mock_host_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Identifier> data_store)
        {
            var data_source = data_store.AsQueryable();
            mock_identifier_set.As<IQueryable<Identifier>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_identifier_set.As<IQueryable<Identifier>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_identifier_set.As<IQueryable<Identifier>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_identifier_set.As<IQueryable<Identifier>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.Identifiers).Returns(mock_identifier_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Location> data_store)
        {
            var data_source = data_store.AsQueryable();
            mock_location_set.As<IQueryable<Location>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_location_set.As<IQueryable<Location>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_location_set.As<IQueryable<Location>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_location_set.As<IQueryable<Location>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.Locations).Returns(mock_location_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Method> data_store)
        {
            var data_source = data_store.AsQueryable();
            mock_method_set.As<IQueryable<Method>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_method_set.As<IQueryable<Method>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_method_set.As<IQueryable<Method>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_method_set.As<IQueryable<Method>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.Methods).Returns(mock_method_set.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<InsectContext>();
            mock_insect_set = new Mock<DbSet<Insect>>();
            mock_author_set = new Mock<DbSet<Author>>();
            mock_collector_set = new Mock<DbSet<Collector>>();
            mock_host_set = new Mock<DbSet<Host>>();
            mock_identifier_set = new Mock<DbSet<Identifier>>();
            mock_location_set = new Mock<DbSet<Location>>();
            mock_method_set = new Mock<DbSet<Method>>();
            repo = new InsectRepository(mock_context.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_insect_set = null;
            mock_author_set = null;
            mock_collector_set = null;
            mock_host_set = null;
            mock_identifier_set = null;
            mock_location_set = null;
            mock_method_set = null;
            repo = null;
        }

        [TestMethod]
        public void InsectContextEnsureInstanceCreation()
        {
            InsectContext context = mock_context.Object;
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void InsectRepositoryEnsureInstanceCreation()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void InsectRepositoryEnsureContext()
        {
            var actual = repo.Context;
            Assert.IsInstanceOfType(actual, typeof(InsectContext));
        }

        [TestMethod]
        public void InsectRepositoryFullTextSearch()
        {
            DateTime today = DateTime.Now;
            var allInsects = new List<Insect>();
            Insect insect1 = new Insect
            {
                Family = "Cerambycidae",
                Tribe = "Aseminae",
                Genus = "Atimia",
                Species = "confusa",
                Subspecies = "confusa",
                County = "Warren",
                Description = "Here is some text for the full search",
                CollectionDate = today.AddYears(-3)
            };
            Insect insect2 = new Insect
            {
                Family = "Cerambycidae",
                Tribe = "Aseminae",
                Genus = "Atimia",
                Species = "confusa",
                Subspecies = "confusa",
                County = "Warren",
                Description = "Optional text for information",
                CollectionDate = today.AddDays(-20)
            };
            Insect insect3 = new Insect
            {
                Family = "Cerambycidae",
                Tribe = "Aseminae",
                Genus = "Atimia",
                Species = "confusa",
                Subspecies = "confusa",
                County = "Warren",
                Description = "This item does not contain our search term",
                CollectionDate = today.AddHours(-14)
            };
            allInsects.Add(insect1);
            allInsects.Add(insect2);
            allInsects.Add(insect3);
            mock_insect_set.Object.AddRange(allInsects);
            ConnectMocksToDataStore(allInsects);
            List<Insect> expectedInsects = new List<Insect> { insect2, insect1 };
            string searchString = "text";
            List<Insect> actualInsects = repo.Search(searchString);
            CollectionAssert.AreEqual(expectedInsects, actualInsects);
        }
    }
}
