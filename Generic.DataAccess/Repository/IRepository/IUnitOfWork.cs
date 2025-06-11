using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.DataAccess.Repository.IRepository
{
    public interface IUnitofWork
    {
        IGenderRepository GenderRepository { get; }
        IReligionRepository ReligionRepository { get; }
        IDisabilityRepository DisabilityRepository { get; }
        IEducationStatusLevelRepository EducationStatusLevelRepository { get; }
        IMaritalStatusRepository MaritalStatusRepository { get; }
        IOccupationRepository OccupationRepository { get; }
        IHealthConditionRepository HealthConditionRepository { get; }
        INationalityRepository NationalityRepository { get; }
        IRelationshipRepository RelationshipRepository { get; }
        IPersonRepository PersonRepository { get; }
        IGovernmentSubsidyRepository GovernmentSubsidyRepository { get; }
        IPhilHealthSoruce PhilHealthSoruceRepository { get; }
        void Save();
    }
}
