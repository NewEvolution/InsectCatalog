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

        public List<Collector> GetCollectors()
        {
            List<Collector> allCollectors = (from collectors in _context.Collectors select collectors).ToList();
            allCollectors.Sort();
            return allCollectors;
        }

        public List<Identifier> GetIdentifiers()
        {
            List<Identifier> allIdentifiers = (from identifiers in _context.Identifiers select identifiers).ToList();
            allIdentifiers.Sort();
            return allIdentifiers;
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

        public bool CreateAuthor(string name, string url)
        {
            bool successfullyCreated = true;
            Author newAuthor = new Author { Name = name, URL = url };
            try
            {
                Author addedAuthor = _context.Authors.Add(newAuthor);
                _context.SaveChanges();
                if (addedAuthor == null)
                {
                    successfullyCreated = false;
                }
            }
            catch (Exception)
            {
                successfullyCreated = false;
            }
            return successfullyCreated;
        }

        public bool CreateCollector(string firstName, string middleName, string lastName, string email, string url)
        {
            bool successfullyCreated = true;
            Collector newCollector = new Collector
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Email = email,
                URL = url
            };
            try
            {
                Collector addedCollector = _context.Collectors.Add(newCollector);
                _context.SaveChanges();
                if (addedCollector == null)
                {
                    successfullyCreated = false;
                }
            }
            catch (Exception)
            {
                successfullyCreated = false;
            }
            return successfullyCreated;
        }

        public bool CreateHost(string name, string commonName, string url)
        {
            bool successfullyCreated = true;
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
                if (addedHost == null)
                {
                    successfullyCreated = false;
                }
            }
            catch (Exception)
            {
                successfullyCreated = false;
            }
            return successfullyCreated;
        }
    }
}