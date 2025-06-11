using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class Vegetable
    {
        public Vegetable()
        {
            HouseHoldVegtable = new HashSet<HouseHoldVegtable>();
        }

        [Key]
        public int VegetableId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string VegtableName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("Vegtable")]
        public virtual ICollection<HouseHoldVegtable> HouseHoldVegtable { get; set; }
    }
}
