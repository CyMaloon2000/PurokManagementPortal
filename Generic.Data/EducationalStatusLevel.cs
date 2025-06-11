using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    [Index("LegendRemarks", Name = "UQ__Educatio__F48D2411A39C7EF5", IsUnique = true)]
    public partial class EducationalStatusLevel
    {
        public EducationalStatusLevel()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int EducationalStatusLevelId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? EducationalStatusLevelName { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string LegendRemarks { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("EducationalStatusLevel")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
