using System;
using System.Collections.Generic;

namespace RapportCQRS.Model.Models
{
    public partial class AUserRole
    {
        public int UserId { get; set; }
        public byte RoleId { get; set; }
    }
}
