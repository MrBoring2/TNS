namespace Desktop_TNS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        [Column(TypeName = "date")]
        public DateTime BalanceDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Zadolzenost { get; set; }

        public int AbonentId { get; set; }

        public virtual Abonent Abonent { get; set; }
    }
}
