using System;
using System.Web;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace InsectCatalog.Models
{
    public class InsectContext : ApplicationDbContext
    {
        public virtual DbSet<Insect> Insects { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Host> Hosts { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Method> Methods { get; set; }
    }
}