namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shippings
    {
        public int Id { get; set; }

        public int OrderID { get; set; }

        public int? UserID { get; set; }

        public DateTime? ShipDate { get; set; }

        public bool Status { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual Users Users { get; set; }
    }
}
