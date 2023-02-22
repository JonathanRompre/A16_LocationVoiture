using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using A16_TP_1142718_JRompre.Models;

namespace A16_TP_1142718_JRompre.Data
{
    public class A16_TP_1142718_JRompreContext : DbContext
    {
        public A16_TP_1142718_JRompreContext (DbContextOptions<A16_TP_1142718_JRompreContext> options)
            : base(options)
        {
        }

        public DbSet<A16_TP_1142718_JRompre.Models.Automobile> Automobile { get; set; } = default!;

        public DbSet<A16_TP_1142718_JRompre.Models.Client> Client { get; set; }

        public DbSet<A16_TP_1142718_JRompre.Models.Reservation> Reservation { get; set; }

        public DbSet<A16_TP_1142718_JRompre.Models.HistoriqueReservation> HistoriqueReservation { get; set; }
    }
}
