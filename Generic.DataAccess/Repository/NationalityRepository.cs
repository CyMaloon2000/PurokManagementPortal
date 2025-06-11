using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.DataAccess.Repository
{
    public class NationalityRepository : Repository<Nationality>, INationalityRepository
    {
        private GenericContext _context;
        public NationalityRepository(GenericContext context) : base(context)
        {
            _context = context;
        }
    }
}
