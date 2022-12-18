namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public long ID { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CustomerID { get; set; }

        [StringLength(200)]
        public string CustomerName { get; set; }

        [StringLength(15)]
        public string CustomerPhone { get; set; }

        [StringLength(200)]
        public string CustomerAddress { get; set; }

        [StringLength(200)]
        public string CustomerEmail { get; set; }

        public int? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
