using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class HouseHoldPowerSource
    {
        [Key]
        public int HouseHoldPowerSourceId { get; set; }
        public int PowerSourceId { get; set; }
        public int HouseHoldId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("HouseHoldId")]
        [InverseProperty("HouseHoldPowerSource")]
        public virtual HouseHold HouseHold { get; set; } = null!;
        [ForeignKey("PowerSourceId")]
        [InverseProperty("HouseHoldPowerSource")]
        public virtual PowerSource PowerSource { get; set; } = null!;
    }
}
