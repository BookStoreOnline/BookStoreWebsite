using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreOnline.Model.Models
{
    [Table("VisitorStatistics")]
    public class VisitorStatistic
    {   
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime VistitedDate { get; set; }

        [MaxLength(50)]
        public string IPAdress { get; set; }
    }
}