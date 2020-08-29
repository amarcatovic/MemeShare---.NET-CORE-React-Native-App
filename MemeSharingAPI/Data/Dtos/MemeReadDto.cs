using MemeSharingAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Dtos
{
    public class MemeReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long Likes { get; set; }
        public DateTime DateAdded { get; set; }
        public PhotoReadDto Photo { get; set; }
        public string MemeType { get; set; }
    }
}
