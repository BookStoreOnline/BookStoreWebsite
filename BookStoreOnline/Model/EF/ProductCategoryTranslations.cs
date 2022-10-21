namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductCategoryTranslations
    {
        public int Id { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string SeoDescription { get; set; }

        [StringLength(50)]
        public string SeoTitle { get; set; }

        [Required]
        [StringLength(5)]
        public string LanguageID { get; set; }

        [StringLength(50)]
        public string SeoAlias { get; set; }

        public virtual Languages Languages { get; set; }

        public virtual ProductCategories ProductCategories { get; set; }
    }
}
