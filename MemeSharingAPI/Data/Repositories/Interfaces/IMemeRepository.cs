using MemeSharingAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Repositories.Interfaces
{
    public interface IMemeRepository
    {
        Task<Meme> GetMemeById(int id);
        Task<IEnumerable<Meme>> GetMemes();

        Task AddMeme(Meme meme);
        Task<bool> Done();
    }
}
