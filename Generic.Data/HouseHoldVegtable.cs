using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class HouseHoldVegtable
    {
        [Key]
        public int HouseHoldVegtableId { get; set; }
        public int VegtableId { get; set; }
        public int HouseHoldId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("HouseHoldId")]
        [InverseProperty("HouseHoldVegtable")]
        public virtual HouseHold HouseHold { get; set; } = null!;
        [ForeignKey("UnitId")]
        [InverseProperty("HouseHoldVegtable")]
        public virtual Unit Unit { get; set; } = null!;
        [ForeignKey("VegtableId")]
        [InverseProperty("HouseHoldVegtable")]
        public virtual Vegetable Vegtable { get; set; } = null!;
    }
}
