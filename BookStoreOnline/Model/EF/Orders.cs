namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
            Shippings = new HashSet<Shippings>();
        }

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int? UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerAddress { get; set; }

        [StringLength(50)]
        public string CustomerEmail { get; set; }

        [Required]
        [StringLength(15)]
        public string CustomerPhoneNumber { get; set; }

        public int? PromotionID { get; set; }

        public decimal? PromotionMoney { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual Promotions Promotions { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shippings> Shippings { get; set; }
    }
}
