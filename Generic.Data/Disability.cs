using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    [Index("LegendRemarks", Name = "UQ__Disabili__F48D2411F50C3500", IsUnique = true)]
    public partial class Disability
    {
        public Disability()
        {
            PersonDisability = new HashSet<PersonDisability>();
        }

        [Key]
        public int DisabilityId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string DisabilityName { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string LegendRemarks { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("Disability")]
        public virtual ICollection<PersonDisability> PersonDisability { get; set; }
    }
}
