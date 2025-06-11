using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class HouseHoldMember
    {
        [Key]
        public int HouseHoldMemberId { get; set; }
        public int HouseHoldId { get; set; }
        public int PersonId { get; set; }
        public bool IsHead { get; set; }
        [Required]
        public bool IsActive { get; set; }

        [ForeignKey("HouseHoldId")]
        [InverseProperty("HouseHoldMember")]
        public virtual HouseHold HouseHold { get; set; } = null!;
        [ForeignKey("PersonId")]
        [InverseProperty("HouseHoldMember")]
        public virtual Person Person { get; set; } = null!;
    }
}
