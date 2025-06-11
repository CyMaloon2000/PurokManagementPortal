using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class Relationship
    {
        public Relationship()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int RelationshipId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string RelationshipName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("RelationshipToHead")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
