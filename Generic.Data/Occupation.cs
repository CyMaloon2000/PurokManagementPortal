using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class Occupation
    {
        public Occupation()
        {
            Person = new HashSet<Person>();
            PersonOccupation = new HashSet<PersonOccupation>();
        }

        [Key]
        public int OccupationId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string OccupationName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("Occupation")]
        public virtual ICollection<Person> Person { get; set; }
        [InverseProperty("Occupation")]
        public virtual ICollection<PersonOccupation> PersonOccupation { get; set; }
    }
}
