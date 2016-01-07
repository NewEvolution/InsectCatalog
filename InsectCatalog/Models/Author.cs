using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsectCatalog.Models
{
    public class Author : IComparable
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Url]
        public string URL { get; set; }

        public int CompareTo(object obj)
        {
            Author compAuthor = obj as Author;
            return Name.CompareTo(compAuthor.Name);
        }
    }
}