using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgendaMVC.Models;

namespace AgendaMVC.Data
{
    public class AgendaMVCContext : DbContext
    {
        public AgendaMVCContext (DbContextOptions<AgendaMVCContext> options)
            : base(options)
        {
        }

        public DbSet<AgendaMVC.Models.Contato> Contato { get; set; } = default!;
    }
}
