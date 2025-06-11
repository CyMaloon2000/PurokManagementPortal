using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class HouseHoldStruture
    {
        [Key]
        public int HouseHoldStrutureId { get; set; }
        public int? StructureTypeId { get; set; }
        public int? HouseHoldId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("HouseHoldId")]
        [InverseProperty("HouseHoldStruture")]
        public virtual HouseHold? HouseHold { get; set; }
        [ForeignKey("StructureTypeId")]
        [InverseProperty("HouseHoldStruture")]
        public virtual StructureType? StructureType { get; set; }
    }
}
