namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        public int? Quantity { get; set; }

        public int? CategoryID { get; set; }

        public decimal Price { get; set; }

        public decimal PromotionPrice { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public int? Weight { get; set; }

        public int? Width { get; set; }

        public int? Depth { get; set; }

        public int? Height { get; set; }

        public int? QuantityOfPage { get; set; }

        [StringLength(50)]
        public string BookLayout { get; set; }

        [StringLength(200)]
        public string Publisher { get; set; }

        public bool Status { get; set; }

        public int? ViewCount { get; set; }
    }
}