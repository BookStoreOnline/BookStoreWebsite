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

        public virtual Author Author { get; set; }
        public virtual Product Product { get; set; }
    }
}