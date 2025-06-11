using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class Nationality
    {
        public Nationality()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int NationalityId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string NationalityName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("Nationality")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
