using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsectCatalog.Models
{
    public class Method
    {
        [Key]
        public string MethodId { get; set; }
        [Required]
        public string Name { get; set; }
        [Url]
        public string URL { get; set; }
    }
}