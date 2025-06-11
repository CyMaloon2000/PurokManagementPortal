using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class PowerSource
    {
        public PowerSource()
        {
            HouseHoldPowerSource = new HashSet<HouseHoldPowerSource>();
        }

        [Key]
        public int PowerSourceId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string PowerSourceName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("PowerSource")]
        public virtual ICollection<HouseHoldPowerSource> HouseHoldPowerSource { get; set; }
    }
}
