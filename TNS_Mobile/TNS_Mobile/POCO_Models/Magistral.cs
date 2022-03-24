using System;
using System.Collections.Generic;
using System.Text;

namespace TNS_Mobile.POCO_Models
{
    public class Magistral
    {
        public int Id { get; set; }
        public string SeriesNumber { get; set; }
        public string Name { get; set; }
        public double Chastota { get; set; }
        public string Koeffisient { get; set; }
        public string Technology { get; set; }
        public string Address { get; set; }
    }
}
