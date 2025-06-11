using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class StructureType
    {
        public StructureType()
        {
            HouseHoldStruture = new HashSet<HouseHoldStruture>();
        }

        [Key]
        public int StructureTypeId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string StructureTypeName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("StructureType")]
        public virtual ICollection<HouseHoldStruture> HouseHoldStruture { get; set; }
    }
}
