namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Prices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        public int UpdatedCount { get; set; }

        public DateTime UpdatedDate { get; set; }

        public decimal Price { get; set; }

        public virtual Products Products { get; set; }
    }
}
