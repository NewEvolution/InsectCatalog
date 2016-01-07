using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InsectCatalog.Models
{
    public class Insect : IComparable
    {
        [Key]
        public int InsectId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-z]+")]
        public string Family { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-z]+")]
        public string Tribe { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-z]+")]
        public string Genus { get; set; }
        [Required]
        [RegularExpression(@"^[a-z]+")]
        public string Species { get; set; }
        [DefaultValue("")]
        [Required(AllowEmptyStrings = true)]
        [RegularExpression(@"^[a-z]+")]
        public string Subspecies { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string CommonName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-z]+")]
        public string County { get; set; }
        [Required]
        public DateTime CollectionDate { get; set; }
        public virtual Person Identifier { get; set; }
        [Required]
        public virtual Person Collector { get; set; }
        [Required]
        public virtual Author Author { get; set; }
        [DefaultValue("")]
        [Required(AllowEmptyStrings = true)]
        public virtual Method Method { get; set; }
        [DefaultValue("")]
        [Required(AllowEmptyStrings = true)]
        public virtual Host Host { get; set; }
        [Required]
        public Location Location { get; set; }
        [DefaultValue ("")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }
        public virtual List<Image> Images { get; set; }

        public int CompareTo(object obj)
        {
            int compValue;
            Insect compInsect = obj as Insect;
            compValue = Family.CompareTo(compInsect.Family);
            if (compValue == 0)
            {
                compValue = Tribe.CompareTo(compInsect.Tribe);
                if (compValue == 0)
                {
                    compValue = Genus.CompareTo(compInsect.Genus);
                    if (compValue == 0)
                    {
                        compValue = Species.CompareTo(compInsect.Species);
                        if (compValue == 0)
                        {
                            compValue = -1 * (CollectionDate.CompareTo(compInsect.CollectionDate));
                        }
                    }
                }
            }
            return compValue;
        }
    }
}