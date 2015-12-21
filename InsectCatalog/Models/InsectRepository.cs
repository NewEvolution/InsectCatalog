﻿using System;
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

        public bool CreateCollector(string firstName, string middleName, string lastName, string email, string url)
        {
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
                return addedCollector != null;
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

        public bool CreateIdentifier(string firstName, string middleName, string lastName, string email, string url)
        {
            Identifier newIdentifier = new Identifier
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Email = email,
                URL = url
            };
            try
            {
                Identifier addedIdentifier = _context.Identifiers.Add(newIdentifier);
                _context.SaveChanges();
                return addedIdentifier != null;
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
    }
}