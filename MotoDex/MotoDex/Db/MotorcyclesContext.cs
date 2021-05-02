using Microsoft.EntityFrameworkCore;
using MotoDex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoDex.Db
{
    public class MotorcyclesContext : DbContext
    {
        public MotorcyclesContext(DbContextOptions<MotorcyclesContext> options) : base(options)
        {
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }

        public DbSet<MotorcycleMake> MotorcycleMakes { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Tyre> Tyres { get; set; }

        public DbSet<BreakPad> BreakPads { get; set; }
    }
}
