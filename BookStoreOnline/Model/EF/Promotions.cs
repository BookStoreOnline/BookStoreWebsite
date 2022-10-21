namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Promotions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promotions()
        {
            Carts = new HashSet<Carts>();
            Orders = new HashSet<Orders>();
            ProductPromotions = new HashSet<ProductPromotions>();
            ProductCategories1 = new HashSet<ProductCategories>();
        }

        public int Id { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public bool? ApplyForAll { get; set; }

        public int? DiscountPercent { get; set; }

        [Column(TypeName = "money")]
        public decimal? DiscountAmount { get; set; }

        public int? ProductID { get; set; }

        public int? ProductCategoryID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carts> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }

        public virtual ProductCategories ProductCategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPromotions> ProductPromotions { get; set; }

        public virtual Products Products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCategories> ProductCategories1 { get; set; }
    }
}
