using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class WaterSource
    {
        public WaterSource()
        {
            HouseHoldWaterSource = new HashSet<HouseHoldWaterSource>();
        }

        [Key]
        public int WaterSourceId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string WaterSourceName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("WaterSource")]
        public virtual ICollection<HouseHoldWaterSource> HouseHoldWaterSource { get; set; }
    }
}
