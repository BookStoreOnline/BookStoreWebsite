﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreOnline.Model.Models
{
    [Table("SupportOnlines")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Department { get; set; }
        [MaxLength(255)]
        public string Skype { get; set; }
        [MaxLength(255)]
        public string Mobile { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Zalo { get; set; }
        [MaxLength(255)]
        public string Facebook { get; set; }
        public bool Status { get; set; }
    }
}