namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Languages
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Languages()
        {
            CoverTranslations = new HashSet<CoverTranslations>();
            ProductCategoryTranslations = new HashSet<ProductCategoryTranslations>();
            ProductTranslations = new HashSet<ProductTranslations>();
            ProviderTranslations = new HashSet<ProviderTranslations>();
        }

        [StringLength(5)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool? IsDefault { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoverTranslations> CoverTranslations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCategoryTranslations> ProductCategoryTranslations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductTranslations> ProductTranslations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProviderTranslations> ProviderTranslations { get; set; }
    }
}
