using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreOnline.Model.Models
{
    [Table("Pages")]
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Content { get; set; }
        [MaxLength(255)]
        public string MetaKeyword { get; set; }
        [MaxLength(255)]
        public string MetaDescription { get; set; }
        public bool Status { get; set; }
    }
}
