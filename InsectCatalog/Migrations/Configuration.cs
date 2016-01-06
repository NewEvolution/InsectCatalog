namespace InsectCatalog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using InsectCatalog.Models;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InsectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InsectContext context)
        {
            Author author = new Author
            {
                AuthorId = "0a",
                Name = "Say",
                URL = "https://en.wikipedia.org/wiki/Thomas_Say"
            };

            Host host = new Host
            {
                HostId = "0a",
                Name = "Liriodendron tulipifera",
                CommonName = "tulip tree",
                URL = "https://en.wikipedia.org/wiki/Liriodendron_tulipifera"
            };

            Person person = new Person
            {
                PersonId = "0a",
                FirstName = "Ryan",
                MiddleName = "J.",
                LastName = "Tanay",
                Email = "rtanay@gmail.com",
                URL = "http://portfolio.ryantanay.com"
            };

            Person collector = new Person
            {
                PersonId = "0b",
                FirstName = "Joseph",
                MiddleName = "C.",
                LastName = "Lampley"
            };

            Person identifier = new Person
            {
                PersonId = "0c",
                FirstName = "Nadeer",
                MiddleName = "N.",
                LastName = "Youssef"
            };

            Image image = new Image
            {
                ImageId = "0a",
                S3Id = "somegianthashwillgohere",
                Caption = "This is text that describes the image",
                Display = true,
                Photographer = person
            };

            List<Image> images = new List<Image>() { image };

            Location location = new Location
            {
                LocationId = "0a",
                Name = "NRC, McMinnville",
                Latitude = 35.708118,
                Longitude = -85.744488
            };

            Method method = new Method
            {
                MethodId = "0a",
                Name = "hand"
            };

            DateTime date = new DateTime(2011, 6, 1);

            Insect insect = new Insect
            {
                InsectId ="0a",
                Family = "Cerambycidae",
                Tribe = "Lamiinae",
                Genus = "Ecyrus",
                Species = "dasycerus",
                Subspecies = "dasycerus",
                CommonName = "",
                Identifier = identifier,
                Author = author,
                County = "Warren",
                Location = location,
                CollectionDate = date,
                Collector = collector,
                Method = method,
                Description = "",
                Host = host,
                Images = images
            };

            context.Authors.AddOrUpdate(a => a.AuthorId, author);
            context.Hosts.AddOrUpdate(h => h.HostId, host);
            context.People.AddOrUpdate(p => p.PersonId, person, collector, identifier);
            context.Images.AddOrUpdate(i => i.ImageId, image);
            context.Locations.AddOrUpdate(l => l.LocationId, location);
            context.Methods.AddOrUpdate(m => m.MethodId, method);
            context.Insects.AddOrUpdate(i => i.InsectId, insect);
        }
    }
}
