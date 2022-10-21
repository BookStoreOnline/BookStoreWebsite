namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Providers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Providers()
        {
            Imports = new HashSet<Imports>();
            ProviderTranslations = new HashSet<ProviderTranslations>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imports> Imports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProviderTranslations> ProviderTranslations { get; set; }
    }
}
