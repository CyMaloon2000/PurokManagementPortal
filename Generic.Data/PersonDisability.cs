using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class PersonDisability
    {
        [Key]
        public int PersonDisabilityId { get; set; }
        public int PersonId { get; set; }
        public int DisabilityId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("DisabilityId")]
        [InverseProperty("PersonDisability")]
        public virtual Disability Disability { get; set; } = null!;
        [ForeignKey("PersonId")]
        [InverseProperty("PersonDisability")]
        public virtual Person Person { get; set; } = null!;
    }
}
