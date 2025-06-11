using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class Religion
    {
        public Religion()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int ReligionId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string ReligionName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("Religion")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
