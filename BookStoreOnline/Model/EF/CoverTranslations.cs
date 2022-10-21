namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CoverTranslations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int CoverID { get; set; }

        [Required]
        [StringLength(5)]
        public string LanguageID { get; set; }

        public virtual Covers Covers { get; set; }

        public virtual Languages Languages { get; set; }
    }
}
