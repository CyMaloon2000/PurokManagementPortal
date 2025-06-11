using Generic.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.DataAccess.Repository
{
    public class UnitOfWork : IUnitofWork
    {
        private GenericContext _context;

        public UnitOfWork(GenericContext context)
        {
            _context = context;
            GenderRepository = new GenderRepository(_context);
            ReligionRepository = new ReligionRepository(_context);
            DisabilityRepository = new DisabilityRepository(_context);
            EducationStatusLevelRepository = new EducationStatusLevelRepository(_context);
            MaritalStatusRepository = new MaritalStatusRepository(_context);
            OccupationRepository = new OccupationRepository(_context);
            HealthConditionRepository = new HealthConditionRepository(_context);
            NationalityRepository = new NationalityRepository(_context);
            RelationshipRepository = new RelationshipRepository(_context);
            PersonRepository = new PersonRepository(_context);
            GovernmentSubsidyRepository = new GovernmentSubsidyRepository(_context);
            PhilHealthSoruceRepository = new PhilHealthSourceRepository(_context);
        }
        public IGenderRepository GenderRepository { get; private set; }
        public IReligionRepository ReligionRepository { get; private set; }
        public IDisabilityRepository DisabilityRepository {get; private set;}
        public IEducationStatusLevelRepository EducationStatusLevelRepository { get; private set; }
        public IMaritalStatusRepository MaritalStatusRepository { get; private set; }
        public IOccupationRepository OccupationRepository { get; private set; }
        public IHealthConditionRepository HealthConditionRepository { get; private set; }
        public INationalityRepository NationalityRepository { get; private set; }
        public IRelationshipRepository RelationshipRepository { get; private set; }
        public IPersonRepository PersonRepository { get; private set; }
        public IGovernmentSubsidyRepository GovernmentSubsidyRepository { get; private set; }
        public IPhilHealthSoruce PhilHealthSoruceRepository { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
