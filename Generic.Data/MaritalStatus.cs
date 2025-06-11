using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class MaritalStatus
    {
        public MaritalStatus()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int MaritalStatusId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string StatusName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("MaritalStatus")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
