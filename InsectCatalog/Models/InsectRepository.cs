using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace InsectCatalog.Models
{
    public class InsectRepository
    {
        private InsectContext _context;
        public InsectContext Context { get { return _context; } }

        public InsectRepository()
        {
            _context = new InsectContext();
        }

        public InsectRepository(InsectContext a_context)
        {
            _context = a_context;
        }

        public List<Insect> Search(string searchString)
        {
            List<Insect> foundInsects = (from insects in _context.Insects
                                         where insects.CommonName.Contains(searchString) ||
                                         insects.Description.Contains(searchString) ||
                                         insects.Family.Contains(searchString) ||
                                         insects.Genus.Contains(searchString) ||
                                         insects.Species.Contains(searchString) ||
                                         insects.Tribe.Contains(searchString)
                                         select insects).ToList(); 
            foundInsects.Sort();
            return foundInsects;
        }

        public List<Author> GetAuthors()
        {
            List<Author> allAuthors = (from authors in _context.Authors select authors).ToList();
            allAuthors.Sort();
            return allAuthors;
        }

        public List<Host> GetHosts()
        {
            List<Host> allHosts = (from hosts in _context.Hosts select hosts).ToList();
            allHosts.Sort();
            return allHosts;
        }

        public List<Person> GetPeople()
        {
            List<Person> allPeople = (from people in _context.People select people).ToList();
            allPeople.Sort();
            return allPeople;
        }

        public List<Image> GetImages()
        {
            List<Image> allImages = (from images in _context.Images select images).ToList();
            allImages.Sort();
            return allImages;
        }

        public Image GetRandomDisplayImage()
        {
            Image randomImage = (from images in _context.Images where images.Display orderby Guid.NewGuid() select images).First();
            return randomImage;
        }

        public List<Location> GetLocations()
        {
            List<Location> allLocations = (from locations in _context.Locations select locations).ToList();
            allLocations.Sort();
            return allLocations;
        }

        public List<Method> GetMethods()
        {
            List<Method> allMethods = (from methods in _context.Methods select methods).ToList();
            allMethods.Sort();
            return allMethods;
        }

        public List<Insect> GetInsects()
        {
            List<Insect> allInsects = (from insects in _context.Insects select insects).ToList();
            allInsects.Sort();
            return allInsects;
        }

        public Insect GetRandomInsect()
        {
            Insect randomInsect = (from insects in _context.Insects orderby Guid.NewGuid() select insects).First();
            return randomInsect;
        }

        public bool CreateAuthor(string name, string url)
        {
            Author newAuthor = new Author { Name = name, URL = url };
            try
            {
                Author addedAuthor = _context.Authors.Add(newAuthor);
                _context.SaveChanges();
                return addedAuthor != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreatePerson(string firstName, string middleName, string lastName, string email, string url)
        {
            Person newPerson = new Person
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Email = email,
                URL = url
            };
            try
            {
                Person addedPerson = _context.People.Add(newPerson);
                _context.SaveChanges();
                return addedPerson != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateHost(string name, string commonName, string url)
        {
            Host newHost = new Host
            {
                Name = name,
                CommonName = commonName,
                URL = url
            };
            try
            {
                Host addedHost = _context.Hosts.Add(newHost);
                _context.SaveChanges();
                return addedHost != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateImage(string s3id, string caption, bool display, Person photographer)
        {
            Image newImage = new Image
            {
                S3Id = s3id,
                Caption = caption,
                Display = display,
                Photographer = photographer
            };
            try
            {
                Image addedImage = _context.Images.Add(newImage);
                _context.SaveChanges();
                return addedImage != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateLocation(string name, double latitude, double longitude)
        {
            Location newLocation = new Location
            {
                Name = name,
                Latitude = latitude,
                Longitude = longitude
            };
            try
            {
                Location addedLocation = _context.Locations.Add(newLocation);
                _context.SaveChanges();
                return addedLocation != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateMethod(string name, string url)
        {
            Method newMethod = new Method
            {
                Name = name,
                URL = url
            };
            try
            {
                Method addedMethod = _context.Methods.Add(newMethod);
                _context.SaveChanges();
                return addedMethod != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateInsect(string family, string tribe, string genus, string species, string subspecies, string commonName, string county, string description, Location location, DateTime collectionDate, Person identifier, Person collector, Author author, Method method, Host host, List<Image> images)
        {
            Insect newInsect = new Insect
            {
                Family = family,
                Tribe = tribe,
                Genus = genus,
                Species = species,
                Subspecies = subspecies,
                CommonName = commonName,
                County = county,
                Description = description,
                Location = location,
                CollectionDate = collectionDate,
                Identifier = identifier,
                Collector = collector,
                Author = author,
                Method = method,
                Host = host,
                Images = images
            };
            try
            {
                Insect addedInsect = _context.Insects.Add(newInsect);
                _context.SaveChanges();
                return addedInsect != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}