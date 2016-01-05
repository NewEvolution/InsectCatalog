using System;
using System.Web;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InsectCatalog.Models
{
    public class Image : IComparable
    {
        [Key]
        public string ImageId { get; set; }
        [Required]
        public string S3Id { get; set; }
        [DefaultValue ("")]
        [Required(AllowEmptyStrings = true)]
        public string Caption { get; set; }
        [DefaultValue (false)]
        [Required]
        public bool Display { get; set; }

        public int CompareTo(object obj)
        {
            Image compImage = obj as Image;
            return S3Id.CompareTo(compImage.S3Id);
        }
    }
}