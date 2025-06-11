using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Generic.Data
{
    public partial class Person
    {
        public Person()
        {
            HouseHoldMember = new HashSet<HouseHoldMember>();
            PersonDisability = new HashSet<PersonDisability>();
            PersonHealthCondition = new HashSet<PersonHealthCondition>();
            PersonOccupation = new HashSet<PersonOccupation>();
            User = new HashSet<User>();
        }

        [Key]
        public int PersonId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string? MiddleName { get; set; }
        public int GenderId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        public int MaritalStatusId { get; set; }
        public int NationalityId { get; set; }
        public int OccupationId { get; set; }
        public int ReligionId { get; set; }
        public bool HasBirthCert { get; set; }
        public int RelationshipToHeadId { get; set; }
        public int? EducationalStatusLevelId { get; set; }
        public int? GovernmentSubsidyId { get; set; }
        public int? PhilHealthSourceId { get; set; }
        [NotMapped]
        public string FullName 
        {
            get 
            { 
                if(string.IsNullOrEmpty(MiddleName) || MiddleName == "-")
                {
                    return $"{FirstName}, {LastName}";
                }
                else
                {
                    return $"{FirstName}, {LastName} {MiddleName}";
                }
            }
        }

        [ForeignKey("EducationalStatusLevelId")]
        [InverseProperty("Person")]
        public virtual EducationalStatusLevel? EducationalStatusLevel { get; set; }
        [ForeignKey("GenderId")]
        [InverseProperty("Person")]
        public virtual Gender Gender { get; set; } = null!;
        [ForeignKey("GovernmentSubsidyId")]
        [InverseProperty("Person")]
        public virtual GovernmentSubsidy? GovernmentSubsidy { get; set; }
        [ForeignKey("MaritalStatusId")]
        [InverseProperty("Person")]
        public virtual MaritalStatus MaritalStatus { get; set; } = null!;
        [ForeignKey("NationalityId")]
        [InverseProperty("Person")]
        public virtual Nationality Nationality { get; set; } = null!;
        [ForeignKey("OccupationId")]
        [InverseProperty("Person")]
        public virtual Occupation Occupation { get; set; } = null!;
        [ForeignKey("PhilHealthSourceId")]
        [InverseProperty("Person")]
        public virtual PhilHealthSource? PhilHealthSource { get; set; }
        [ForeignKey("RelationshipToHeadId")]
        [InverseProperty("Person")]
        public virtual Relationship RelationshipToHead { get; set; } = null!;
        [ForeignKey("ReligionId")]
        [InverseProperty("Person")]
        public virtual Religion Religion { get; set; } = null!;
        [InverseProperty("Person")]
        public virtual ICollection<HouseHoldMember> HouseHoldMember { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<PersonDisability> PersonDisability { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<PersonHealthCondition> PersonHealthCondition { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<PersonOccupation> PersonOccupation { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<User> User { get; set; }
    }
}
