namespace Desktop_TNS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SetiDostupa")]
    public partial class SetiDostupa
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string SeriesNumber { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int Count { get; set; }

        [Required]
        [StringLength(100)]
        public string Standart { get; set; }

        public double Chastota { get; set; }

        [Required]
        [StringLength(100)]
        public string Interfaces { get; set; }

        [Required]
        [StringLength(20)]
        public string Speed { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Address { get; set; }
    }
}
