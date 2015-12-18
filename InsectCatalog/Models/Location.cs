using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsectCatalog.Models
{
    public class Location : IComparable
    {
        [Key]
        public string LocationId { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            Location compLocation = obj as Location;
            return Name.CompareTo(compLocation.Name);
        }
    }
}