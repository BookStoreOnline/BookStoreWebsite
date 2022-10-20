using BookStoreOnline.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreOnline.Model.Models
{
    [Table("Orders")]
    public class Order : Contactable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CustomerMessage { get; set; }
        public DateTime? CreatedDate { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        [MaxLength(255)]
        public string PamentMethod { get; set; }

        [Required]
        public bool PaymentStatus { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}