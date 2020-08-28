using MemeSharingAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Dtos
{
    public class MemeTypeReadDto
    {
        public string TypeName { get; set; }
        public ICollection<Meme> Memes { get; set; }
    }
}
