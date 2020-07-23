using System;
using System.Collections.Generic;

namespace RapportCQRS.Model.Models
{
    public partial class AConnections
    {
        public long Id { get; set; }
        public int Email { get; set; }
        public DateTime DateConnection { get; set; }
        public string Ipaddress { get; set; }
        public bool? Successful { get; set; }
    }
}
