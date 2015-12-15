using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsectCatalog.Models
{
    public class Collector : IComparable
    {
        [Key]
        public string CollectorId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Url]
        public string URL { get; set; }

        public int CompareTo(object obj)
        {
            Collector compCollector = obj as Collector;
            return LastName.CompareTo(compCollector.LastName);
        }
    }
}