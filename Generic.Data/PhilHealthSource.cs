using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class PhilHealthSource
    {
        public PhilHealthSource()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int PhilHealthSourceId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string PhilHealthSourceName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("PhilHealthSource")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
