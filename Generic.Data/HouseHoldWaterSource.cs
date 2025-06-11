using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class HouseHoldWaterSource
    {
        [Key]
        public int HouseHoldWaterSourceId { get; set; }
        public int WaterSourceId { get; set; }
        public int HouseHoldId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("HouseHoldId")]
        [InverseProperty("HouseHoldWaterSource")]
        public virtual HouseHold HouseHold { get; set; } = null!;
        [ForeignKey("WaterSourceId")]
        [InverseProperty("HouseHoldWaterSource")]
        public virtual WaterSource WaterSource { get; set; } = null!;
    }
}
