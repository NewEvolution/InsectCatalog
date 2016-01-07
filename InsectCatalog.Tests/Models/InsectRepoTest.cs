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
        private Mock<DbSet<Person>> mock_person_set;
        private Mock<DbSet<Host>> mock_host_set;
        private Mock<DbSet<Image>> mock_image_set;
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

        private void ConnectMocksToDataStore(IEnumerable<Person> data_store)
        {
            var data_source = data_store.AsQueryable();
            mock_person_set.As<IQueryable<Person>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_person_set.As<IQueryable<Person>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_person_set.As<IQueryable<Person>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_person_set.As<IQueryable<Person>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.People).Returns(mock_person_set.Object);
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

        private void ConnectMocksToDataStore(IEnumerable<Image> data_store)
        {
            var data_source = data_store.AsQueryable();
            mock_image_set.As<IQueryable<Image>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_image_set.As<IQueryable<Image>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_image_set.As<IQueryable<Image>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_image_set.As<IQueryable<Image>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.Images).Returns(mock_image_set.Object);
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
            mock_person_set = new Mock<DbSet<Person>>();
            mock_host_set = new Mock<DbSet<Host>>();
            mock_image_set = new Mock<DbSet<Image>>();
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
            mock_person_set = null;
            mock_host_set = null;
            mock_image_set = null;
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
        public void InsectRepositoryGetAllPeople()
        {
            Person person1 = new Person { LastName = "Tanay" };
            Person person2 = new Person { LastName = "Addesso" };
            Person person3 = new Person { LastName = "Allen" };
            var allPeople = new List<Person>() { person1, person2, person3 };
            mock_person_set.Object.AddRange(allPeople);
            ConnectMocksToDataStore(allPeople);
            List<Person> expectedPeople = new List<Person>() { person2, person3, person1 };
            List<Person> actualPeople = repo.GetPeople();
            CollectionAssert.AreEqual(expectedPeople, actualPeople);
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
        public void InsectRepositoryGetAllImages()
        {
            Image image1 = new Image { S3Id = "TestImage1S3ID" };
            Image image2 = new Image { S3Id = "TestImage2S3ID" };
            Image image3 = new Image { S3Id = "TestImage3S3ID" };
            var allImages = new List<Image>() { image1, image2, image3 };
            mock_image_set.Object.AddRange(allImages);
            ConnectMocksToDataStore(allImages);
            List<Image> expectedImages = new List<Image>() { image1, image2, image3 };
            List<Image> actualImages = repo.GetImages();
            CollectionAssert.AreEqual(expectedImages, actualImages);
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
        public void InsectRepositoryGetRandomInsect()
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
            Insect expectedInsect = insect2;
            Insect actualInsect = repo.GetRandomInsect();
            Assert.AreEqual(expectedInsect, actualInsect);
        }

        [TestMethod]
        public void ImageRepositoryGetRandomDisplayImage()
        {
            Image image1 = new Image
            {
                S3Id = "Image1TestS3id",
                Caption = "Image 1 Test Caption",
                Display = true,
                Photographer = new Person()
            };
            Image image2 = new Image
            {
                S3Id = "Image2TestS3id",
                Caption = "Image 2 Test Caption",
                Display = false,
                Photographer = new Person()
            };
            Image image3 = new Image
            {
                S3Id = "Image3TestS3id",
                Caption = "Image 3 Test Caption",
                Display = true,
                Photographer = new Person()
            };
            var allImages = new List<Image>() { image1, image2, image3 };
            mock_image_set.Object.AddRange(allImages);
            ConnectMocksToDataStore(allImages);
            Image expectedImage = image3;
            Image actualImage = repo.GetRandomDisplayImage();
            Assert.AreEqual(expectedImage, actualImage);
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
        public void InsectRepositoryCreatePerson()
        {
            string firstName = "Ryan";
            string middleName = "J";
            string lastName = "Tanay";
            string email = "rtanay@gmail.com";
            string url = "http://portfolio.ryantanay.com";
            List<Person> allPeople = new List<Person>();
            ConnectMocksToDataStore(allPeople);
            mock_person_set.Setup(c => c.Add(It.IsAny<Person>()))
                .Callback((Person x) => allPeople.Add(x))
                .Returns(mock_person_set.Object.Where(c => c.LastName == lastName && c.FirstName == firstName).Single);
            bool personCreated = repo.CreatePerson(firstName, middleName, lastName, email, url);
            Assert.AreEqual(1, repo.GetPeople().Count);
            Assert.IsTrue(personCreated);
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
        public void InsectRepositoryCreateImage()
        {
            string s3id = "TestS3id";
            string caption = "Test Image Caption";
            bool display = false;
            Person photographer = new Person
            {
                FirstName = "Ryan",
                MiddleName = "J.",
                LastName = "Tanay",
                URL = "http://portfolio.ryantanay.com",
                Email = "rtanay@gmail.com"
            };
            List<Image> allImages = new List<Image>();
            ConnectMocksToDataStore(allImages);
            mock_image_set.Setup(i => i.Add(It.IsAny<Image>()))
                .Callback((Image x) => allImages.Add(x))
                .Returns(mock_image_set.Object.Where(i => i.S3Id == s3id).Single);
            bool imageCreated = repo.CreateImage(s3id, caption, display, photographer);
            Assert.AreEqual(1, repo.GetImages().Count);
            Assert.IsTrue(imageCreated);
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
            Location location = new Location();
            DateTime collectionDate = DateTime.Now;
            Person identifier = new Person();
            Person collector = new Person();
            Author author = new Author();
            Method method = new Method();
            Host host = new Host();
            List<Image> images = new List<Image>() { new Image(), new Image(), new Image() };
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
                host,
                images);
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
            List<Person> allPeople = new List<Person>();
            ConnectMocksToDataStore(allPeople);
            mock_person_set.Setup(c => c.Add(It.IsAny<Person>()))
                .Callback((Person x) => allPeople.Add(x))
                .Returns(mock_person_set.Object.Where(c => c.LastName == lastName && c.FirstName == firstName).Single);
            bool personCreated = repo.CreatePerson(firstName, middleName, lastName, email, url);
            Person person = repo.GetPeople().First();
            Person collector = person;
            Person identifier = person;
            Assert.IsTrue(personCreated);
            string s3id1 = "TestS3id1";
            string caption1 = "Test Image Caption 1";
            bool display1 = true;
            string s3id2 = "TestS3id2";
            string caption2 = "Test Image Caption 2";
            bool display2 = false;
            string s3id3 = "TestS3id3";
            string caption3 = "Test Image Caption 3";
            bool display3 = false;
            List<Image> allImages = new List<Image>();
            ConnectMocksToDataStore(allImages);
            mock_image_set.Setup(i => i.Add(It.IsAny<Image>()))
                .Callback((Image x) => allImages.Add(x))
                .Returns(mock_image_set.Object.Where(i => i.S3Id == s3id1).Single);
            bool imageCreated = repo.CreateImage(s3id1, caption1, display1, person);
            repo.CreateImage(s3id2, caption2, display2, person);
            repo.CreateImage(s3id3, caption3, display3, person);
            List<Image> images = repo.GetImages();
            Assert.IsTrue(imageCreated);
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
                location,
                collectionDate,
                identifier,
                collector,
                author,
                method,
                host,
                images);
            Assert.AreEqual(1, repo.GetInsects().Count);
            Assert.IsTrue(insectCreated);
        }
    }
}
