using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class Gender
    {
        public Gender()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int GenderId { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        [DisplayName("Gender")]
        public string GenderName { get; set; } = null!;
        [Required]
        public bool IsActive { get; set; }

        [InverseProperty("Gender")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
