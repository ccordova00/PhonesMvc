using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhonesMvc.Models
{
    public class PhonesMvcContext : DbContext
    {
        public PhonesMvcContext (DbContextOptions<PhonesMvcContext> options)
            : base(options)
        {
        }

        public DbSet<PhonesMvc.Models.Phone> Phone { get; set; }
    }
}
