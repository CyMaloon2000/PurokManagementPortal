using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class Tree
    {
        public Tree()
        {
            HouseHoldTree = new HashSet<HouseHoldTree>();
        }

        [Key]
        public int TreeId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string TreeName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("Tree")]
        public virtual ICollection<HouseHoldTree> HouseHoldTree { get; set; }
    }
}
