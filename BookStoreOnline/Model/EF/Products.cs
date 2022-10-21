namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            Carts = new HashSet<Carts>();
            ImportDetails = new HashSet<ImportDetails>();
            ImportDetails1 = new HashSet<ImportDetails>();
            OrderDetails = new HashSet<OrderDetails>();
            ProductTranslations = new HashSet<ProductTranslations>();
            Promotions = new HashSet<Promotions>();
            Authors = new HashSet<Authors>();
            Images = new HashSet<Images>();
            Translators = new HashSet<Translators>();
        }

        public int Id { get; set; }

        public int Stock { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(50)]
        public string SeoAlias { get; set; }

        public int? CategoryID { get; set; }

        public int? IssuingCompanyID { get; set; }

        public int? CoverID { get; set; }

        public int? PublishingCompanyID { get; set; }

        public int? AuthorID { get; set; }

        public int? TranslatorID { get; set; }

        public DateTime? PublishingDate { get; set; }

        public int? BrandID { get; set; }

        public int? OriginID { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public int? Pages { get; set; }

        public bool Status { get; set; }

        public virtual Brands Brands { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carts> Carts { get; set; }

        public virtual Covers Covers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportDetails> ImportDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportDetails> ImportDetails1 { get; set; }

        public virtual IssuingCompanies IssuingCompanies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual Originals Originals { get; set; }

        public virtual Prices Prices { get; set; }

        public virtual ProductCategories ProductCategories { get; set; }

        public virtual PublishingCompanies PublishingCompanies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductTranslations> ProductTranslations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Promotions> Promotions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Authors> Authors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Images> Images { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Translators> Translators { get; set; }
    }
}
