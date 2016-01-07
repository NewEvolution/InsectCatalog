using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InsectCatalog.Models
{
    public class Host : IComparable
    {
        [Key]
        public int HostId { get; set; }
        [DefaultValue("")]
        [Required(AllowEmptyStrings = true)]
        public string CommonName { get; set; }
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