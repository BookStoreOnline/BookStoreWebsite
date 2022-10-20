using BookStoreOnline.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreOnline.Model.Models
{
    [Table("Posts")]
    public class Post : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Alias { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [MaxLength(500)]
        public string Image { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        [ForeignKey("CategoryID")]
        public virtual PostCategory PostCategory { get; set; }
        public virtual IEnumerable<PostTag> PostTags { get; set; }

    }
}