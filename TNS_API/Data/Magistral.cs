namespace TNS_API.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Magistral")]
    public partial class Magistral
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string SeriesNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double Chastota { get; set; }

        [Required]
        [StringLength(20)]
        public string Koeffisient { get; set; }

        [Required]
        [StringLength(20)]
        public string Technology { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Address { get; set; }
    }
}
