using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.DataAccess.Repository
{
    public class DisabilityRepository : Repository<Disability>, IDisabilityRepository
    {
        private GenericContext _context;
        public DisabilityRepository(GenericContext context) : base(context)
        {
            _context = context;
        }
    }
}
