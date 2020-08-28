using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Dtos
{
    public class MemeCreateDto
    {
        public MemeCreateDto()
        {
            DateAdded = DateTime.Now;
        }

        public string Title { get; set; }
        public long Likes { get; set; }
        public DateTime DateAdded { get; set; }
        public IFormFile PhotoFile { get; set; }
        public int MemeTypeId { get; set; }
    }
}
