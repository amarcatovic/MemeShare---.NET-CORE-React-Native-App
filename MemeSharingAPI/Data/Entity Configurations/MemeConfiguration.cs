using MemeSharingAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Entity_Configurations
{
    public class MemeConfiguration : IEntityTypeConfiguration<Meme>
    {
        public void Configure(EntityTypeBuilder<Meme> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title)
                .IsRequired();

            builder.Property(m => m.Likes)
                .HasDefaultValue(0);

            builder.HasOne(m => m.Photo)
                .WithMany(p => p.Memes)
                .HasForeignKey(m => m.PhotoId);

            builder.HasOne(m => m.MemeType)
                .WithMany(mt => mt.Memes)
                .HasForeignKey(m => m.MemeTypeId);
        }
    }
}
