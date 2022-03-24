namespace TNS_API.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Abonent")]
    public partial class Abonent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Abonent()
        {
            Payment = new HashSet<Payment>();
            Tarif = new HashSet<Tarif>();
            Service = new HashSet<Service>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(40)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(300)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressProposki { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressProzivania { get; set; }

        [Required]
        [StringLength(12)]
        public string Pasport { get; set; }

        [Required]
        [StringLength(10)]
        public string CodePodrazdelenia { get; set; }

        [Required]
        [StringLength(300)]
        public string KemVidan { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataVidachi { get; set; }

        [Required]
        [StringLength(100)]
        public string DogovorNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataDogovora { get; set; }

        [StringLength(100)]
        public string DogovorType { get; set; }

        [Required]
        [StringLength(100)]
        public string PrichinaRastorzenia { get; set; }

        public int PersonalAccountNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataRastorzeniaDogovora { get; set; }

        [StringLength(50)]
        public string DovorArendi { get; set; }

        public int EquipmentId { get; set; }

        public virtual AbonentEquipment AbonentEquipment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tarif> Tarif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Service { get; set; }
    }
}
