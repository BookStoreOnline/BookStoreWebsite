using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreOnline.Model.Models
{
    public class ProductDetail
    {
        [Key]
        public int ProductID { get; set; }
        public int IssuingCompanyID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int CoverID { get; set; }
        public int Pages { get; set; }
        public int PublishingCompanyID { get; set; }
        public int AuthorID { get; set; }
        public int TranslatorID { get; set; }
        public DateTime PublishingDate { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        [ForeignKey("IssuingCompanyID")]
        public virtual IssuingCompany IssuingCompany { get; set; }
        [ForeignKey("PublishingCompanyID")]
        public virtual PublishingCompany PublishingCompany { get; set; }
        [ForeignKey("CoverID")]
        public virtual Cover Cover { get; set; }
    }
}