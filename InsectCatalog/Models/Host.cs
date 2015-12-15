using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsectCatalog.Models
{
    public class Host : IComparable
    {
        public string CommonName { get; set; }
        [Key]
        public string HostId { get; set; }
        [Required]
        public string Name { get; set; }
        [Url]
        public string URL { get; set; }

        public int CompareTo(object obj)
        {
            Host compHost = obj as Host;
            return Name.CompareTo(compHost.Name);
        }
    }
}