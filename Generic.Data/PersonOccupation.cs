using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class PersonOccupation
    {
        [Key]
        public int PersonOccupationId { get; set; }
        public int PersonId { get; set; }
        public int OccupationId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Salary { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("OccupationId")]
        [InverseProperty("PersonOccupation")]
        public virtual Occupation Occupation { get; set; } = null!;
        [ForeignKey("PersonId")]
        [InverseProperty("PersonOccupation")]
        public virtual Person Person { get; set; } = null!;
    }
}
