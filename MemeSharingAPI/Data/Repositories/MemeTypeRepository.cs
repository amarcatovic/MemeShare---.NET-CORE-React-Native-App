using MemeSharingAPI.Data.Models;
using MemeSharingAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Repositories
{
    public class MemeTypeRepository : IMemeTypeRepository
    {
        private readonly MemesContext _context;

        public MemeTypeRepository(MemesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MemeType>> GetAllTypes()
        {
            return await _context.MemeTypes.ToListAsync();
        }

        public async Task<MemeType> GetMemeTypeById(int id)
        {
            return await _context.MemeTypes.FindAsync(id);
        }
    }
}
