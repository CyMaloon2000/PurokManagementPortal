using Generic.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Data;
using Microsoft.EntityFrameworkCore;

namespace Generic.DataAccess.Repository
{
    public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        private GenericContext _context;

        public GenderRepository(GenericContext context) : base(context)
        {
            _context = context;
        }

    }
}
