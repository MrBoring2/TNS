namespace Desktop_TNS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public int RoleId { get; set; }

        [Required]
        [StringLength(100)]
        public string img { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
    }
}
