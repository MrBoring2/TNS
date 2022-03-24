namespace TNS_API.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RayonsSPb")]
    public partial class RayonsSPb
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public double Square { get; set; }

        public int Population { get; set; }

        public int MetroCount { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }
    }
}
