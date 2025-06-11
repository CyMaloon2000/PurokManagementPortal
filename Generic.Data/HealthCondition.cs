using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    [Index("LegendRemarks", Name = "UQ__HealthCo__F48D2411A430177B", IsUnique = true)]
    public partial class HealthCondition
    {
        public HealthCondition()
        {
            PersonHealthCondition = new HashSet<PersonHealthCondition>();
        }

        [Key]
        public int HealthConditionId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string HealthConditionName { get; set; } = null!;
        [StringLength(1)]
        [Unicode(false)]
        public string LegendRemarks { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("HealthCondition")]
        public virtual ICollection<PersonHealthCondition> PersonHealthCondition { get; set; }
    }
}
