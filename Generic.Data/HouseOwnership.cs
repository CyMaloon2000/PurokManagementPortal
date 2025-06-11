using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class HouseOwnership
    {
        public HouseOwnership()
        {
            HouseHold = new HashSet<HouseHold>();
        }

        [Key]
        public int HouseOwnershipId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string HouseOwnershipName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("HouseOwnership")]
        public virtual ICollection<HouseHold> HouseHold { get; set; }
    }
}
