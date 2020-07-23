using System;
using System.Collections.Generic;

namespace RapportCQRS.Model.Models
{
    public partial class SActivity
    {
        public short Id { get; set; }
        public short UserId { get; set; }
        public string ContenuAct { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
