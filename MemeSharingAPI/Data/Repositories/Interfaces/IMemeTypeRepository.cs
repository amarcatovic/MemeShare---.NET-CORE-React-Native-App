using MemeSharingAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Repositories.Interfaces
{
    public interface IMemeTypeRepository
    {
        Task<MemeType> GetMemeTypeById(int id);
        Task<IEnumerable<MemeType>> GetAllTypes();
    }
}
