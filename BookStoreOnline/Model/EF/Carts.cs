namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Carts
    {
        public int Id { get; set; }

        public int? ProductID { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public int? PromotionID { get; set; }

        public decimal? PromotionMoney { get; set; }

        public virtual Products Products { get; set; }

        public virtual Promotions Promotions { get; set; }
    }
}
