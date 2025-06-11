using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class HouseHoldTree
    {
        [Key]
        public int HouseHoldTreeId { get; set; }
        public int? TreeId { get; set; }
        public int HouseHoldId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("HouseHoldId")]
        [InverseProperty("HouseHoldTree")]
        public virtual HouseHold HouseHold { get; set; } = null!;
        [ForeignKey("TreeId")]
        [InverseProperty("HouseHoldTree")]
        public virtual Tree? Tree { get; set; }
    }
}
