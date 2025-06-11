using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.DataAccess.Repository
{
    public class ReligionRepository : Repository<Religion>, IReligionRepository
    {
        private GenericContext _context;
        public ReligionRepository(GenericContext context) : base(context)
        {
            _context = context;
        }
    }
}
