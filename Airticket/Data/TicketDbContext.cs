using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Airticket.Models;

namespace Airticket.Data
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext (DbContextOptions<TicketDbContext> options)
            : base(options)
        {
        }

        public DbSet<Airticket.Models.Admin> Admin { get; set; }

        public DbSet<Airticket.Models.Booking> Booking { get; set; }

        public DbSet<Airticket.Models.Contactus> Contactus { get; set; }

        public DbSet<Airticket.Models.Flight> Flight { get; set; }

        public DbSet<Airticket.Models.User> User { get; set; }
    }
}
