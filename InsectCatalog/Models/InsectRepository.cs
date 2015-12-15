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
            var query = from insects in _context.Insects select insects;
            List<Insect> foundInsects = query.Where(insect => insect.Description.Contains(searchString)).ToList();
            foundInsects.Sort();
            return foundInsects; 
        }
    }
}