using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class PersonHealthCondition
    {
        [Key]
        public int PersonHealthConditionId { get; set; }
        public int PersonId { get; set; }
        public int HealthConditionId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("HealthConditionId")]
        [InverseProperty("PersonHealthCondition")]
        public virtual HealthCondition HealthCondition { get; set; } = null!;
        [ForeignKey("PersonId")]
        [InverseProperty("PersonHealthCondition")]
        public virtual Person Person { get; set; } = null!;
    }
}
