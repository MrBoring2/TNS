namespace Desktop_TNS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TabelEmployee")]
    public partial class TabelEmployee
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Column(TypeName = "text")]
        public string Tabel { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual EmployeeTemp EmployeeTemp { get; set; }
    }
}
