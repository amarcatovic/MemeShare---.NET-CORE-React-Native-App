using MemeSharingAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Repositories.Interfaces
{
    public interface IPhotoRepository
    {
        Task<Photo> GetPhotoById(int id);
    }
}
