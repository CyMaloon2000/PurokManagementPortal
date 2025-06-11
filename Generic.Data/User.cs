using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    [Index("Username", Name = "UQ__User__536C85E4CCCAC5F6", IsUnique = true)]
    public partial class User
    {
        [Key]
        public int UserId { get; set; }
        public int PersonId { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string Username { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("User")]
        public virtual Person Person { get; set; } = null!;
    }
}
