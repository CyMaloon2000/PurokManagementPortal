using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class GovernmentSubsidy
    {
        public GovernmentSubsidy()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int GovernmentSubsidyId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string GovernmentSubsidyName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("GovernmentSubsidy")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
