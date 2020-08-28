using MemeSharingAPI.Data.Entity_Configurations;
using MemeSharingAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data
{
    public class MemesContext : DbContext
    {
        public MemesContext(DbContextOptions<MemesContext> opt) : base (opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Meme> Memes { get; set; }
        public DbSet<MemeType> MemeTypes { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
