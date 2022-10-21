namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Imports
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Imports()
        {
            ImportDetails = new HashSet<ImportDetails>();
        }

        public int Id { get; set; }

        public int ProviderID { get; set; }

        public DateTime? ImportedDate { get; set; }

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportDetails> ImportDetails { get; set; }

        public virtual Providers Providers { get; set; }
    }
}
