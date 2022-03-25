namespace Desktop_TNS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeTemp")]
    public partial class EmployeeTemp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeTemp()
        {
            TabelEmployee = new HashSet<TabelEmployee>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TabelEmployee> TabelEmployee { get; set; }
    }
}
