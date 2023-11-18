using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cucu_Denisa_Flavia_lab2_REFACUT.Models;

namespace Cucu_Denisa_Flavia_lab2_REFACUT.Data
{
    public class Cucu_Denisa_Flavia_lab2_REFACUTContext : DbContext
    {
        public Cucu_Denisa_Flavia_lab2_REFACUTContext (DbContextOptions<Cucu_Denisa_Flavia_lab2_REFACUTContext> options)
            : base(options)
        {
        }

        public DbSet<Cucu_Denisa_Flavia_lab2_REFACUT.Models.Book> Book { get; set; } = default!;

        public DbSet<Cucu_Denisa_Flavia_lab2_REFACUT.Models.Publisher>? Publisher { get; set; }

        public DbSet<Cucu_Denisa_Flavia_lab2_REFACUT.Models.Author>? Author { get; set; }
    }
}
