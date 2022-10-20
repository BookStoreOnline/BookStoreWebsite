using BookStoreOnline.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreOnline.Model.Models
{
    [Table("PostCategories")]
    public class PostCategory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Alias { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int? ParentID { get; set; }
        [MaxLength(500)]
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }
    }
}