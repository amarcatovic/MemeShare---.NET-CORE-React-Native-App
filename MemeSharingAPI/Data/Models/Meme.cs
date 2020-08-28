using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Models
{
    public class Meme
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long Likes { get; set; }
        public DateTime DateAdded { get; set; }
        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
        public MemeType MemeType { get; set; }
        public int MemeTypeId { get; set; }
    }
}
