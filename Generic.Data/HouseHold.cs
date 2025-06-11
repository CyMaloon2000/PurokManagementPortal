using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    [Index("HouseHoldNo", Name = "UQ__HouseHol__BE3422BB6CE563F4", IsUnique = true)]
    public partial class HouseHold
    {
        public HouseHold()
        {
            HouseHoldAnimal = new HashSet<HouseHoldAnimal>();
            HouseHoldMember = new HashSet<HouseHoldMember>();
            HouseHoldPowerSource = new HashSet<HouseHoldPowerSource>();
            HouseHoldStruture = new HashSet<HouseHoldStruture>();
            HouseHoldTree = new HashSet<HouseHoldTree>();
            HouseHoldVegtable = new HashSet<HouseHoldVegtable>();
            HouseHoldWaterSource = new HashSet<HouseHoldWaterSource>();
        }

        [Key]
        public int HouseHoldId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string HouseHoldNo { get; set; } = null!;
        public int? NoOfFamilies { get; set; }
        public int? HouseOwnershipId { get; set; }

        [ForeignKey("HouseOwnershipId")]
        [InverseProperty("HouseHold")]
        public virtual HouseOwnership? HouseOwnership { get; set; }
        [InverseProperty("HouseHold")]
        public virtual ICollection<HouseHoldAnimal> HouseHoldAnimal { get; set; }
        [InverseProperty("HouseHold")]
        public virtual ICollection<HouseHoldMember> HouseHoldMember { get; set; }
        [InverseProperty("HouseHold")]
        public virtual ICollection<HouseHoldPowerSource> HouseHoldPowerSource { get; set; }
        [InverseProperty("HouseHold")]
        public virtual ICollection<HouseHoldStruture> HouseHoldStruture { get; set; }
        [InverseProperty("HouseHold")]
        public virtual ICollection<HouseHoldTree> HouseHoldTree { get; set; }
        [InverseProperty("HouseHold")]
        public virtual ICollection<HouseHoldVegtable> HouseHoldVegtable { get; set; }
        [InverseProperty("HouseHold")]
        public virtual ICollection<HouseHoldWaterSource> HouseHoldWaterSource { get; set; }
    }
}
