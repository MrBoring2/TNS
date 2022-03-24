namespace TNS_API.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaseStation")]
    public partial class BaseStation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseStation()
        {
            BaseStationAddresses = new HashSet<BaseStationAddresses>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double Square { get; set; }

        public int Chastota { get; set; }

        [Required]
        [StringLength(50)]
        public string AntenaType { get; set; }

        [Required]
        [StringLength(50)]
        public string DiaposonPokazateley { get; set; }

        [Required]
        [StringLength(50)]
        public string Standart { get; set; }

        [StringLength(50)]
        public string Coords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaseStationAddresses> BaseStationAddresses { get; set; }
    }
}
