using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.DataAccess.Repository
{
    public class OccupationRepository : Repository<Occupation>, IOccupationRepository
    {
        private GenericContext _context;

        public OccupationRepository(GenericContext context) : base(context)
        {
            _context = context;
        }

    }
}
