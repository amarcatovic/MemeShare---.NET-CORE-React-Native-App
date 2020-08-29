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

        public async Task AddMeme(Meme meme)
        {
            await _context.Memes.AddAsync(meme);
        }

        public async Task<Meme> GetMemeById(int id)
        {
            return await _context.Memes.Include(m => m.Photo).Include(m => m.MemeType).SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Meme>> GetMemes()
        {
            return await _context.Memes.Include(m => m.Photo).Include(m => m.MemeType).OrderByDescending(m => m.DateAdded).ToListAsync();
        }

        public async Task<bool> Done()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
