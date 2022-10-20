using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreOnline.Model.Models
{
    public class ProductDetail
    {
        [Key]
        public int ProductID { get; set; }
        public int IssuingCompanyID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Cover { get; set; }
        public int Pages { get; set; }
        public int PublishingCompanyID { get; set; }
        public int AuthorID { get; set; }
        public int TranslatorID { get; set; }
        public DateTime PublishingDate { get; set; }
    }
}