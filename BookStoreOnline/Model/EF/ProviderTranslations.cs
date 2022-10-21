namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProviderTranslations
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int ProviderCompanyID { get; set; }

        [Required]
        [StringLength(5)]
        public string LanguageID { get; set; }

        public virtual Languages Languages { get; set; }

        public virtual Providers Providers { get; set; }
    }
}
