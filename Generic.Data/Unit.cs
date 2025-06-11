using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class Unit
    {
        public Unit()
        {
            HouseHoldVegtable = new HashSet<HouseHoldVegtable>();
        }

        [Key]
        public int UnitId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string UnitName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("Unit")]
        public virtual ICollection<HouseHoldVegtable> HouseHoldVegtable { get; set; }
    }
}
