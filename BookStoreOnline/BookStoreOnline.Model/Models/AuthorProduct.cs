using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreOnline.Model.Models
{
    [Table("AuthorProducts")]
    public class AuthorProduct
    {
        [Key]
        public int AuthorID { get; set; }

        [Key]
        public int ProductID { get; set; }
        [ForeignKey("AuthorID")]
        public virtual Author Author { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}