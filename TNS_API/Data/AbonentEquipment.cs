namespace TNS_API.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AbonentEquipment")]
    public partial class AbonentEquipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AbonentEquipment()
        {
            Abonent = new HashSet<Abonent>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string SeriesNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Ports { get; set; }

        [Required]
        [StringLength(50)]
        public string Standart { get; set; }

        [Required]
        [StringLength(100)]
        public string Speed { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abonent> Abonent { get; set; }
    }
}
