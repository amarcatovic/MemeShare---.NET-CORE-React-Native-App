using MemeSharingAPI.Data.Models;
using MemeSharingAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Repositories
{
    public class MemeRepository : IMemeRepository
    {
        private readonly MemesContext _context;

        public MemeRepository(MemesContext context)
        {
            _context = context;
        }

        public async Task<Meme> GetMemeById(int id)
        {
            return await _context.Memes.FindAsync(id);
        }

        public async Task<IEnumerable<Meme>> GetMemes()
        {
            return await _context.Memes.ToListAsync();
        }
    }
}
