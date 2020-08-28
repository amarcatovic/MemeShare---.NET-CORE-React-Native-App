using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Models
{
    public class MemeType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<Meme> Memes { get; set; }
    }
}
