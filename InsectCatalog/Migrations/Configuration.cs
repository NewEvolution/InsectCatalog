namespace InsectCatalog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using InsectCatalog.Models;
    using System.Linq;
    using System.Data.Entity.Validation;

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
                Name = "Say",
                URL = "https://en.wikipedia.org/wiki/Thomas_Say"
            };

            Host host = new Host
            {
                Name = "Liriodendron tulipifera",
                CommonName = "tulip tree",
                URL = "https://en.wikipedia.org/wiki/Liriodendron_tulipifera"
            };

            Person person = new Person
            {
                FirstName = "Ryan",
                MiddleName = "J.",
                LastName = "Tanay",
                Email = "rtanay@gmail.com",
                URL = "http://portfolio.ryantanay.com"
            };

            Person collector = new Person
            {
                FirstName = "Joseph",
                MiddleName = "C.",
                LastName = "Lampley"
            };

            Person identifier = new Person
            {
                FirstName = "Nadeer",
                MiddleName = "N.",
                LastName = "Youssef"
            };

            Image image = new Image
            {
                S3Id = "somegianthashwillgohere",
                Caption = "This is text that describes the image",
                Display = true,
                Photographer = person
            };

            List<Image> images = new List<Image>() { image };

            Location location = new Location
            {
                Name = "NRC, McMinnville",
                Latitude = 35.708118,
                Longitude = -85.744488
            };

            Method method = new Method
            {
                Name = "hand"
            };

            DateTime date = new DateTime(2011, 6, 1);

            Insect insect = new Insect
            {
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
