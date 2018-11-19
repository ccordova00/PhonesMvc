using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PhonesMvc.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PhonesMvcContext(
                serviceProvider.GetRequiredService<DbContextOptions<PhonesMvcContext>>()))
            {
                // Look for any movies.
                if (context.Phone.Any())
                {
                    return;   // DB has been seeded
                }

                context.Phone.AddRange(
                     new Phone
                     {
                         Owner = "Bob Morley",
                         Sim = "8020593561567251676",
                         PhoneNumber = "555-555-1212",
                         Color = "Black",
                         Make = "LG",
                         Model = "V10",
                         ScreenSize = 3.5F
                     },

                     new Phone
                     {
                         Owner = "Amber Smith",
                         Sim = "6207891634631002041",
                         PhoneNumber = "555-314-1212",
                         Color = "Grey",
                         Make = "Samsung",
                         Model = "G6",
                         ScreenSize = 2.5F
                     },

                     new Phone
                     {
                         Owner = "Buddy Holly",
                         Sim = "24784589218463090198",
                         PhoneNumber = "555-444-1212",
                         Color = "Black",
                         Make = "Samsung",
                         Model = "Galaxy Note 8",
                         ScreenSize = 3.0F
                     },

                     new Phone
                     {
                         Owner = "George Carlin",
                         Sim = "3146604336309021756",
                         PhoneNumber = "555-658-1212",
                         Color = "Black",
                         Make = "LG",
                         Model = "V30",
                         ScreenSize = 3.0F
                     },

                     new Phone
                     {
                         Owner = "Jessica black",
                         Sim = "7595256659093206599",
                         PhoneNumber = "555-627-1212",
                         Color = "Pink",
                         Make = "Samsung",
                         Model = "G8",
                         ScreenSize = 3.5F
                     }

                );
                context.SaveChanges();
            }
        }
    }
}
