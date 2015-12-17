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
    }
}