using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.DataAccess.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private GenericContext _context;
        public PersonRepository(GenericContext context) : base(context)
        {
            _context = context;
        }
    }
}
