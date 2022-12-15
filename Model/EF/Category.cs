namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int? ParentID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool Status { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
