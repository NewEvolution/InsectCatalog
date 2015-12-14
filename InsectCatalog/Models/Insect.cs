using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsectCatalog.Models
{
    public class Insect
    {
        [Key]
        public string InsectId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-z]+")]
        public string Family { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-z]+")]
        public string Genus { get; set; }
        [Required]
        [RegularExpression(@"^[a-z]+")]
        public string Species { get; set; }
        [RegularExpression(@"^[a-z]+")]
        public string Subspecies { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-z]+")]
        public string Tribe { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-z]+")]
        public string County { get; set; }
        [Required]
        public DateTime CollectionDate { get; set; }
        [Required]
        public Identifier IdentifiedBy { get; set; }
        [Required]
        public Collector CollectedBy { get; set; }
        [Required]
        public Author NameAuthor { get; set; }
        public Method CollectionMethod { get; set; }
        public Host HostPlant { get; set; }
    }
}