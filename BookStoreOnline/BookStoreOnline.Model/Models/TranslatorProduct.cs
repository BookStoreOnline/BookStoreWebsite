using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreOnline.Model.Models
{
    [Table("TranslatorProducts")]
    public class TranslatorProduct
    {
        [Key]
        public int TranslatorID { get; set; }

        [Key]
        public int ProductID { get; set; }
        [ForeignKey("TranslatorID")]
        public virtual Translator Translator { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}