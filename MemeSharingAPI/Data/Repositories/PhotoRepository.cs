using MemeSharingAPI.Data.Models;
using MemeSharingAPI.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly MemesContext _context;

        public PhotoRepository(MemesContext context)
        {
            _context = context;
        }

        public async Task AddPhoto(Photo photo)
        {
            await _context.Photos.AddAsync(photo);
            await _context.SaveChangesAsync();
        }

        public async Task<Photo> GetPhotoById(int id)
        {
            return await _context.Photos.FindAsync(id);
        }
    }
}
