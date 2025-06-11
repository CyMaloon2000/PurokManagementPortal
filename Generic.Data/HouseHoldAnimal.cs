using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class HouseHoldAnimal
    {
        [Key]
        public int HouseHoldAnimalId { get; set; }
        public int AnimalId { get; set; }
        public int HouseHoldId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("AnimalId")]
        [InverseProperty("HouseHoldAnimal")]
        public virtual Animal Animal { get; set; } = null!;
        [ForeignKey("HouseHoldId")]
        [InverseProperty("HouseHoldAnimal")]
        public virtual HouseHold HouseHold { get; set; } = null!;
    }
}
