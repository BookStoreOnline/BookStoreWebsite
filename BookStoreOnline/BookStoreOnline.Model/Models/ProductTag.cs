using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreOnline.Model.Models
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key]
        public int ProductID { get; set; }
        [Key]
        public int TagID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
        [ForeignKey("TagID")]
        public virtual Tag Tag { get; set; }
    }
}