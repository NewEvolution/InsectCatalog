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
        public void InsectRepositoryGetAllAuthors()
        {
            Author author1 = new Author { Name = "Linnaeus" };
            Author author2 = new Author { Name = "Haldeman" };
            Author author3 = new Author { Name = "Gyllenhal" };
            var allAuthors = new List<Author>() { author1, author2, author3 };
            mock_author_set.Object.AddRange(allAuthors);
            ConnectMocksToDataStore(allAuthors);
            List<Author> expectedAuthors = new List<Author>() { author3, author2, author1 };
            List<Author> actualAuthors = repo.GetAuthors();
            CollectionAssert.AreEqual(expectedAuthors, actualAuthors);
        }

        [TestMethod]
        public void InsectRepositoryGetAllCollectors()
        {
            Collector collector1 = new Collector { LastName = "Tanay" };
            Collector collector2 = new Collector { LastName = "Addesso" };
            Collector collector3 = new Collector { LastName = "Allen" };
            var allCollectors = new List<Collector>() { collector1, collector2, collector3 };
            mock_collector_set.Object.AddRange(allCollectors);
            ConnectMocksToDataStore(allCollectors);
            List<Collector> expectedCollectors = new List<Collector>() { collector2, collector3, collector1 };
            List<Collector> actualCollectors = repo.GetCollectors();
            CollectionAssert.AreEqual(expectedCollectors, actualCollectors);
        }

        [TestMethod]
        public void InsectRepositoryGetAllHosts()
        {
            Host host1 = new Host { Name = "Betula nigra" };
            Host host2 = new Host { Name = "Cercis canadensis" };
            Host host3 = new Host { Name = "Acer saccharinum" };
            var allHosts = new List<Host>() { host1, host2, host3 };
            mock_host_set.Object.AddRange(allHosts);
            ConnectMocksToDataStore(allHosts);
            List<Host> expectedHosts = new List<Host>() { host3, host1, host2 };
            List<Host> actualHosts = repo.GetHosts();
            CollectionAssert.AreEqual(expectedHosts, actualHosts);
        }

        [TestMethod]
        public void InsectRepositoryGetAllIdentifiers()
        {
            Identifier identifier1 = new Identifier { LastName = "Tanay" };
            Identifier identifier2 = new Identifier { LastName = "Addesso" };
            Identifier identifier3 = new Identifier { LastName = "Allen" };
            var allIdentifiers = new List<Identifier>() { identifier1, identifier2, identifier3 };
            mock_identifier_set.Object.AddRange(allIdentifiers);
            ConnectMocksToDataStore(allIdentifiers);
            List<Identifier> expectedIdentifiers = new List<Identifier>() { identifier2, identifier3, identifier1 };
            List<Identifier> actualIdentifiers = repo.GetIdentifiers();
            CollectionAssert.AreEqual(expectedIdentifiers, actualIdentifiers);
        }

        [TestMethod]
        public void InsectRepositoryGetAllLocations()
        {
            Location location1 = new Location { Name = "NRC McMinnville" };
            Location location2 = new Location { Name = "Centertown" };
            Location location3 = new Location { Name = "Tullahoma" };
            var allLocations = new List<Location>() { location1, location2, location3 };
            mock_location_set.Object.AddRange(allLocations);
            ConnectMocksToDataStore(allLocations);
            List<Location> expectedLocations = new List<Location>() { location2, location1, location3 };
            List<Location> actualLocations = repo.GetLocations();
            CollectionAssert.AreEqual(expectedLocations, actualLocations);
        }

        [TestMethod]
        public void InsectRepositoryGetAllMethods()
        {
            Method method1 = new Method { Name = "Sticky Trap" };
            Method method2 = new Method { Name = "Reared" };
            Method method3 = new Method { Name = "Vane Trap" };
            var allMethods = new List<Method>() { method1, method2, method3 };
            mock_method_set.Object.AddRange(allMethods);
            ConnectMocksToDataStore(allMethods);
            List<Method> expectedMethods = new List<Method>() { method2, method1, method3 };
            List<Method> actualMethods = repo.GetMethods();
            CollectionAssert.AreEqual(expectedMethods, actualMethods);
        }

        [TestMethod]
        public void InsectRepositoryInsectSearch()
        {
            DateTime today = DateTime.Now;
            Insect insect1 = new Insect
            {
                Family = "Cerambycidae",
                Tribe = "Aseminae",
                Genus = "Atimia",
                Species = "confusa",
                Subspecies = "confusa",
                CommonName = "",
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
                CommonName = "",
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
                CommonName = "",
                County = "Warren",
                Description = "This item does not contain our search term",
                CollectionDate = today.AddHours(-14)
            };
            var allInsects = new List<Insect>() { insect1, insect2, insect3 };
            mock_insect_set.Object.AddRange(allInsects);
            ConnectMocksToDataStore(allInsects);
            List<Insect> expectedInsects = new List<Insect> { insect2, insect1 };
            string searchString = "text";
            List<Insect> actualInsects = repo.Search(searchString);
            CollectionAssert.AreEqual(expectedInsects, actualInsects);
        }

        [TestMethod]
        public void InsectRepositoryGetAllInsects()
        {
            DateTime today = DateTime.Now;
            Insect insect1 = new Insect
            {
                Family = "Cerambycidae",
                Tribe = "Cerambycinae",
                Genus = "Curius",
                Species = "dentatus",
                CommonName = "",
                County = "Warren",
                Description = "Here is some text for information",
                CollectionDate = today.AddYears(-3)
            };
            Insect insect2 = new Insect
            {
                Family = "Cerambycidae",
                Tribe = "Aseminae",
                Genus = "Atimia",
                Species = "confusa",
                Subspecies = "confusa",
                CommonName = "",
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
                CommonName = "",
                County = "Warren",
                Description = "Information text",
                CollectionDate = today.AddHours(-14)
            };
            var allInsects = new List<Insect>() { insect1, insect2, insect3 };
            mock_insect_set.Object.AddRange(allInsects);
            ConnectMocksToDataStore(allInsects);
            List<Insect> expectedInsects = new List<Insect> { insect3, insect2, insect1 };
            List<Insect> actualInsects = repo.GetInsects();
            CollectionAssert.AreEqual(expectedInsects, actualInsects);
        }

        [TestMethod]
        public void InsectRepositoryCreateAuthor()
        {
            string name = "Linnaeus";
            string url = "";
            List<Author> allAuthors = new List<Author>();
            ConnectMocksToDataStore(allAuthors);
            mock_author_set.Setup(a => a.Add(It.IsAny<Author>()))
                .Callback((Author x) => allAuthors.Add(x))
                .Returns(mock_author_set.Object.Where(a => a.Name == name).Single); //this is probably wrong and bad
            bool authorCreated = repo.CreateAuthor(name, url);
            Assert.AreEqual(1, repo.GetAuthors().Count);
            Assert.IsTrue(authorCreated);
        }

        [TestMethod]
        public void InsectRepositoryCreateCollector()
        {
            string firstName = "Ryan";
            string middleName = "J";
            string lastName = "Tanay";
            string email = "rtanay@gmail.com";
            string url = "http://portfolio.ryantanay.com";
            List<Collector> allCollectors = new List<Collector>();
            ConnectMocksToDataStore(allCollectors);
            mock_collector_set.Setup(c => c.Add(It.IsAny<Collector>()))
                .Callback((Collector x) => allCollectors.Add(x))
                .Returns(mock_collector_set.Object.Where(c => c.LastName == lastName && c.FirstName == firstName).Single);
            bool collectorCreated = repo.CreateCollector(firstName, middleName, lastName, email, url);
            Assert.AreEqual(1, repo.GetCollectors().Count);
            Assert.IsTrue(collectorCreated);
        }

        [TestMethod]
        public void InsectRepositoryCreateHost()
        {
            string name = "Celtis occidentalis";
            string commonName = "Common hackberry";
            string url = "http://portfolio.ryantanay.com";
            List<Host> allHosts = new List<Host>();
            ConnectMocksToDataStore(allHosts);
            mock_host_set.Setup(h => h.Add(It.IsAny<Host>()))
                .Callback((Host x) => allHosts.Add(x))
                .Returns(mock_host_set.Object.Where(h => h.Name == name).Single);
            bool hostCreated = repo.CreateHost(name, commonName, url);
            Assert.AreEqual(1, repo.GetHosts().Count);
            Assert.IsTrue(hostCreated);
        }

        [TestMethod]
        public void InsectRepositoryCreateIdentifier()
        {
            string firstName = "Ryan";
            string middleName = "J";
            string lastName = "Tanay";
            string email = "rtanay@gmail.com";
            string url = "http://portfolio.ryantanay.com";
            List<Identifier> allIdentifiers = new List<Identifier>();
            ConnectMocksToDataStore(allIdentifiers);
            mock_identifier_set.Setup(i => i.Add(It.IsAny<Identifier>()))
                .Callback((Identifier x) => allIdentifiers.Add(x))
                .Returns(mock_identifier_set.Object.Where(i => i.LastName == lastName && i.FirstName == firstName).Single);
            bool identifierCreated = repo.CreateIdentifier(firstName, middleName, lastName, email, url);
            Assert.AreEqual(1, repo.GetIdentifiers().Count);
            Assert.IsTrue(identifierCreated);
        }

        [TestMethod]
        public void InsectRepositoryCreateLocation()
        {
            string name = "NRC McMinnville";
            double latitude = 35.708118;
            double longitude = -85.744488;
            List<Location> allLocations = new List<Location>();
            ConnectMocksToDataStore(allLocations);
            mock_location_set.Setup(l => l.Add(It.IsAny<Location>()))
                .Callback((Location x) => allLocations.Add(x))
                .Returns(mock_location_set.Object.Where(l => l.Name == name).Single);
            bool locationCreated = repo.CreateLocation(name, latitude, longitude);
            Assert.AreEqual(1, repo.GetLocations().Count);
            Assert.IsTrue(locationCreated);
        }

        [TestMethod]
        public void InsectRepositoryCreateMethod()
        {
            string name = "Sticky Trap";
            string url = "https://en.wikipedia.org/wiki/Insect_trap#Adhesive_traps";
            List<Method> allMethods = new List<Method>();
            ConnectMocksToDataStore(allMethods);
            mock_method_set.Setup(m => m.Add(It.IsAny<Method>()))
                .Callback((Method x) => allMethods.Add(x))
                .Returns(mock_method_set.Object.Where(m => m.Name == name).Single);
            bool methodCreated = repo.CreateMethod(name, url);
            Assert.AreEqual(1, repo.GetMethods().Count);
            Assert.IsTrue(methodCreated);
        }

        [TestMethod]
        public void InsectRepositoryCreateMinimalInsect()
        {
            string family = "Cerambycidae";
            string tribe = "Aseminae";
            string genus = "Atimia";
            string species = "confusa";
            string subspecies = "confusa";
            string commonName = "";
            string county = "Warren";
            string description = "Information text";
            string location = "TestLocationId";
            DateTime collectionDate = DateTime.Now;
            string identifier = "TestIdentifierId";
            string collector = "TestCollectorId";
            string author = "TestAuthorId";
            string method = "TestMethodId";
            string host = "TestHostId";
            List<Insect> allInsects = new List<Insect>();
            ConnectMocksToDataStore(allInsects);
            mock_insect_set.Setup(i => i.Add(It.IsAny<Insect>()))
                .Callback((Insect x) => allInsects.Add(x))
                .Returns(mock_insect_set.Object.Where(i => i.Genus == genus && i.Species == species).Single);
            bool insectCreated = repo.CreateInsect(
                family,
                tribe,
                genus,
                species,
                subspecies,
                commonName,
                county,
                description,
                location,
                collectionDate,
                identifier,
                collector,
                author,
                method,
                host);
            Assert.AreEqual(1, repo.GetInsects().Count);
            Assert.IsTrue(insectCreated);
        }

        [TestMethod]
        public void InsectRepositoryFullInsectCreateWithSubCreates()
        {
            string family = "Cerambycidae";
            string tribe = "Aseminae";
            string genus = "Atimia";
            string species = "confusa";
            string subspecies = "confusa";
            string commonName = "";
            string county = "Warren";
            string description = "Information text";
            string authorName = "Linnaeus";
            string authorUrl = "";
            DateTime collectionDate = DateTime.Now;
            List<Author> allAuthors = new List<Author>();
            ConnectMocksToDataStore(allAuthors);
            mock_author_set.Setup(a => a.Add(It.IsAny<Author>()))
                .Callback((Author x) => allAuthors.Add(x))
                .Returns(mock_author_set.Object.Where(a => a.Name == authorName).Single);
            bool authorCreated = repo.CreateAuthor(authorName, authorUrl);
            Author author = repo.GetAuthors().First();
            Assert.IsTrue(authorCreated);
            string firstName = "Ryan";
            string middleName = "J";
            string lastName = "Tanay";
            string email = "rtanay@gmail.com";
            string url = "http://portfolio.ryantanay.com";
            List<Collector> allCollectors = new List<Collector>();
            ConnectMocksToDataStore(allCollectors);
            mock_collector_set.Setup(c => c.Add(It.IsAny<Collector>()))
                .Callback((Collector x) => allCollectors.Add(x))
                .Returns(mock_collector_set.Object.Where(c => c.LastName == lastName && c.FirstName == firstName).Single);
            bool collectorCreated = repo.CreateCollector(firstName, middleName, lastName, email, url);
            Collector collector = repo.GetCollectors().First();
            Assert.IsTrue(collectorCreated);
            List<Identifier> allIdentifiers = new List<Identifier>();
            ConnectMocksToDataStore(allIdentifiers);
            mock_identifier_set.Setup(i => i.Add(It.IsAny<Identifier>()))
                .Callback((Identifier x) => allIdentifiers.Add(x))
                .Returns(mock_identifier_set.Object.Where(i => i.LastName == lastName && i.FirstName == firstName).Single);
            bool identifierCreated = repo.CreateIdentifier(firstName, middleName, lastName, email, url);
            Identifier identifier = repo.GetIdentifiers().First();
            Assert.IsTrue(identifierCreated);
            string hostName = "Celtis occidentalis";
            string hostCommonName = "Common hackberry";
            string hostUrl = "http://portfolio.ryantanay.com";
            List<Host> allHosts = new List<Host>();
            ConnectMocksToDataStore(allHosts);
            mock_host_set.Setup(h => h.Add(It.IsAny<Host>()))
                .Callback((Host x) => allHosts.Add(x))
                .Returns(mock_host_set.Object.Where(h => h.Name == hostName).Single);
            bool hostCreated = repo.CreateHost(hostName, hostCommonName, hostUrl);
            Host host = repo.GetHosts().First();
            Assert.IsTrue(hostCreated);
            string locationName = "NRC McMinnville";
            double latitude = 35.708118;
            double longitude = -85.744488;
            List<Location> allLocations = new List<Location>();
            ConnectMocksToDataStore(allLocations);
            mock_location_set.Setup(l => l.Add(It.IsAny<Location>()))
                .Callback((Location x) => allLocations.Add(x))
                .Returns(mock_location_set.Object.Where(l => l.Name == locationName).Single);
            bool locationCreated = repo.CreateLocation(locationName, latitude, longitude);
            Location location = repo.GetLocations().First();
            Assert.IsTrue(locationCreated);
            string methodName = "Sticky Trap";
            string methodUrl = "https://en.wikipedia.org/wiki/Insect_trap#Adhesive_traps";
            List<Method> allMethods = new List<Method>();
            ConnectMocksToDataStore(allMethods);
            mock_method_set.Setup(m => m.Add(It.IsAny<Method>()))
                .Callback((Method x) => allMethods.Add(x))
                .Returns(mock_method_set.Object.Where(m => m.Name == methodName).Single);
            bool methodCreated = repo.CreateMethod(methodName, methodUrl);
            Method method = repo.GetMethods().First();
            Assert.IsTrue(methodCreated);
            List<Insect> allInsects = new List<Insect>();
            ConnectMocksToDataStore(allInsects);
            mock_insect_set.Setup(i => i.Add(It.IsAny<Insect>()))
                .Callback((Insect x) => allInsects.Add(x))
                .Returns(mock_insect_set.Object.Where(i => i.Genus == genus && i.Species == species).Single);
            bool insectCreated = repo.CreateInsect(
                family,
                tribe,
                genus,
                species,
                subspecies,
                commonName,
                county,
                description,
                location.LocationId,
                collectionDate,
                identifier.IdentifierId,
                collector.CollectorId,
                author.AuthorId,
                method.MethodId,
                host.HostId);
            Assert.AreEqual(1, repo.GetInsects().Count);
            Assert.IsTrue(insectCreated);
        }
    }
}
