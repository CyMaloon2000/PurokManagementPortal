using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    [Index("AnimalName", Name = "NonClusteredIndex-20240624-212148", IsUnique = true)]
    public partial class Animal
    {
        public Animal()
        {
            HouseHoldAnimal = new HashSet<HouseHoldAnimal>();
        }

        [Key]
        public int AnimalId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string AnimalName { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("Animal")]
        public virtual ICollection<HouseHoldAnimal> HouseHoldAnimal { get; set; }
    }
}
