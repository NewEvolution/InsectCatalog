using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsectCatalog.Models
{
    public class Author
    {
        [Key]
        public string AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Url]
        public string URL { get; set; }
    }
}