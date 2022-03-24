namespace TNS_API.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BaseStationAddresses
    {
        public int Id { get; set; }

        public int BaseStationId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string AdressPoshadki { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string MestoRaspolozenia { get; set; }

        public virtual BaseStation BaseStation { get; set; }
    }
}
