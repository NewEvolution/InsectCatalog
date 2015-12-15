using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsectCatalog.Models
{
    public class Method : IComparable
    {
        [Key]
        public string MethodId { get; set; }
        [Required]
        public string Name { get; set; }
        [Url]
        public string URL { get; set; }

        public int CompareTo(object obj)
        {
            Method compMethod = obj as Method;
            return Name.CompareTo(compMethod.Name);
        }
    }
}