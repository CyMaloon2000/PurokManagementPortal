using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Generic.Data;

namespace Generic.DataAccess
{
    public partial class GenericContext : DbContext
    {
        public GenericContext()
        {
        }

        public GenericContext(DbContextOptions<GenericContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; } = null!;
        public virtual DbSet<Disability> Disability { get; set; } = null!;
        public virtual DbSet<EducationalStatusLevel> EducationalStatusLevel { get; set; } = null!;
        public virtual DbSet<Gender> Gender { get; set; } = null!;
        public virtual DbSet<GovernmentSubsidy> GovernmentSubsidy { get; set; } = null!;
        public virtual DbSet<HealthCondition> HealthCondition { get; set; } = null!;
        public virtual DbSet<HouseHold> HouseHold { get; set; } = null!;
        public virtual DbSet<HouseHoldAnimal> HouseHoldAnimal { get; set; } = null!;
        public virtual DbSet<HouseHoldMember> HouseHoldMember { get; set; } = null!;
        public virtual DbSet<HouseHoldPowerSource> HouseHoldPowerSource { get; set; } = null!;
        public virtual DbSet<HouseHoldStruture> HouseHoldStruture { get; set; } = null!;
        public virtual DbSet<HouseHoldTree> HouseHoldTree { get; set; } = null!;
        public virtual DbSet<HouseHoldVegtable> HouseHoldVegtable { get; set; } = null!;
        public virtual DbSet<HouseHoldWaterSource> HouseHoldWaterSource { get; set; } = null!;
        public virtual DbSet<HouseOwnership> HouseOwnership { get; set; } = null!;
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; } = null!;
        public virtual DbSet<Nationality> Nationality { get; set; } = null!;
        public virtual DbSet<Occupation> Occupation { get; set; } = null!;
        public virtual DbSet<Person> Person { get; set; } = null!;
        public virtual DbSet<PersonDisability> PersonDisability { get; set; } = null!;
        public virtual DbSet<PersonHealthCondition> PersonHealthCondition { get; set; } = null!;
        public virtual DbSet<PersonOccupation> PersonOccupation { get; set; } = null!;
        public virtual DbSet<PhilHealthSource> PhilHealthSource { get; set; } = null!;
        public virtual DbSet<PowerSource> PowerSource { get; set; } = null!;
        public virtual DbSet<Relationship> Relationship { get; set; } = null!;
        public virtual DbSet<Religion> Religion { get; set; } = null!;
        public virtual DbSet<StructureType> StructureType { get; set; } = null!;
        public virtual DbSet<Tree> Tree { get; set; } = null!;
        public virtual DbSet<Unit> Unit { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;
        public virtual DbSet<Vegetable> Vegetable { get; set; } = null!;
        public virtual DbSet<WaterSource> WaterSource { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Disability>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<EducationalStatusLevel>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<GovernmentSubsidy>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<HealthCondition>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<HouseHold>(entity =>
            {
                entity.HasOne(d => d.HouseOwnership)
                    .WithMany(p => p.HouseHold)
                    .HasForeignKey(d => d.HouseOwnershipId)
                    .HasConstraintName("FK__HouseHold__House__160F4887");
            });

            modelBuilder.Entity<HouseHoldAnimal>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.HouseHoldAnimal)
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__Anima__2A164134");

                entity.HasOne(d => d.HouseHold)
                    .WithMany(p => p.HouseHoldAnimal)
                    .HasForeignKey(d => d.HouseHoldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__House__2B0A656D");
            });

            modelBuilder.Entity<HouseHoldMember>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.HouseHold)
                    .WithMany(p => p.HouseHoldMember)
                    .HasForeignKey(d => d.HouseHoldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__House__367C1819");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.HouseHoldMember)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__Perso__37703C52");
            });

            modelBuilder.Entity<HouseHoldPowerSource>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.HouseHold)
                    .WithMany(p => p.HouseHoldPowerSource)
                    .HasForeignKey(d => d.HouseHoldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__House__19DFD96B");

                entity.HasOne(d => d.PowerSource)
                    .WithMany(p => p.HouseHoldPowerSource)
                    .HasForeignKey(d => d.PowerSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__Power__18EBB532");
            });

            modelBuilder.Entity<HouseHoldStruture>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.HouseHold)
                    .WithMany(p => p.HouseHoldStruture)
                    .HasForeignKey(d => d.HouseHoldId)
                    .HasConstraintName("FK__HouseHold__House__3C34F16F");

                entity.HasOne(d => d.StructureType)
                    .WithMany(p => p.HouseHoldStruture)
                    .HasForeignKey(d => d.StructureTypeId)
                    .HasConstraintName("FK__HouseHold__Struc__3B40CD36");
            });

            modelBuilder.Entity<HouseHoldTree>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.HouseHold)
                    .WithMany(p => p.HouseHoldTree)
                    .HasForeignKey(d => d.HouseHoldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__House__25518C17");

                entity.HasOne(d => d.Tree)
                    .WithMany(p => p.HouseHoldTree)
                    .HasForeignKey(d => d.TreeId)
                    .HasConstraintName("FK__HouseHold__TreeI__245D67DE");
            });

            modelBuilder.Entity<HouseHoldVegtable>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.HouseHold)
                    .WithMany(p => p.HouseHoldVegtable)
                    .HasForeignKey(d => d.HouseHoldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__House__30C33EC3");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.HouseHoldVegtable)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__UnitI__31B762FC");

                entity.HasOne(d => d.Vegtable)
                    .WithMany(p => p.HouseHoldVegtable)
                    .HasForeignKey(d => d.VegtableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__Vegta__2FCF1A8A");
            });

            modelBuilder.Entity<HouseHoldWaterSource>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.HouseHold)
                    .WithMany(p => p.HouseHoldWaterSource)
                    .HasForeignKey(d => d.HouseHoldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__House__1F98B2C1");

                entity.HasOne(d => d.WaterSource)
                    .WithMany(p => p.HouseHoldWaterSource)
                    .HasForeignKey(d => d.WaterSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HouseHold__Water__1EA48E88");
            });

            modelBuilder.Entity<HouseOwnership>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasOne(d => d.EducationalStatusLevel)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.EducationalStatusLevelId)
                    .HasConstraintName("FK__Person__Educatio__6D0D32F4");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__GenderId__6754599E");

                entity.HasOne(d => d.GovernmentSubsidy)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.GovernmentSubsidyId)
                    .HasConstraintName("FK__Person__Governme__6E01572D");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__MaritalS__68487DD7");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.NationalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__National__693CA210");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.OccupationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__Occupati__6A30C649");

                entity.HasOne(d => d.PhilHealthSource)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.PhilHealthSourceId)
                    .HasConstraintName("FK__Person__PhilHeal__6EF57B66");

                entity.HasOne(d => d.RelationshipToHead)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.RelationshipToHeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__Relation__6C190EBB");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.ReligionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__Religion__6B24EA82");
            });

            modelBuilder.Entity<PersonDisability>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Disability)
                    .WithMany(p => p.PersonDisability)
                    .HasForeignKey(d => d.DisabilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonDis__Disab__778AC167");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonDisability)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonDis__Perso__76969D2E");
            });

            modelBuilder.Entity<PersonHealthCondition>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.HealthCondition)
                    .WithMany(p => p.PersonHealthCondition)
                    .HasForeignKey(d => d.HealthConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonHea__Healt__72C60C4A");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonHealthCondition)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonHea__Perso__71D1E811");
            });

            modelBuilder.Entity<PersonOccupation>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.PersonOccupation)
                    .HasForeignKey(d => d.OccupationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonOcc__Occup__7C4F7684");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonOccupation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonOcc__Perso__7B5B524B");
            });

            modelBuilder.Entity<PhilHealthSource>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PowerSource>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Relationship>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Religion>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<StructureType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Tree>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__PersonId__41EDCAC5");
            });

            modelBuilder.Entity<Vegetable>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<WaterSource>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
