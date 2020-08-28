using MemeSharingAPI.Data;
using MemeSharingAPI.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Helpers
{
    public static class PopulateDb
    {
        public static void Populate(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<MemesContext>());
            }
        }

        public static void SeedData(MemesContext context)
        {
            Console.WriteLine("Running SeedData Method...");
            context.Database.Migrate();

            if(!context.MemeTypes.Any())
            {
                Console.WriteLine("Adding Basic Meme Types to the database!");
                context.MemeTypes.AddRange(
                    new MemeType() { TypeName = "Trending"},
                    new MemeType() { TypeName = "Funny" },
                    new MemeType() { TypeName = "NSFW" },
                    new MemeType() { TypeName = "Classic" },
                    new MemeType() { TypeName = "Political" },
                    new MemeType() { TypeName = "America" },
                    new MemeType() { TypeName = "Nerd" },
                    new MemeType() { TypeName = "Gaming" },
                    new MemeType() { TypeName = "YouTube" },
                    new MemeType() { TypeName = "(G)Old" },
                    new MemeType() { TypeName = "Other" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("There are Meme Types already in the database!");
            }
        }
    }
}
