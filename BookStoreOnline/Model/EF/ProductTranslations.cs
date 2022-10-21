namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductTranslations
    {
        public int Id { get; set; }

        public int ProductID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(4000)]
        public string Detail { get; set; }

        [StringLength(255)]
        public string SeoDescription { get; set; }

        [StringLength(50)]
        public string SeoTitle { get; set; }

        [Required]
        [StringLength(5)]
        public string LanguageID { get; set; }

        public virtual Languages Languages { get; set; }

        public virtual Products Products { get; set; }
    }
}
