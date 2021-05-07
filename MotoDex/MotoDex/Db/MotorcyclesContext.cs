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

        public DbSet<MotorcycleFrontTyres> MotorcycleFrontTyres { get; set; }

        public DbSet<MotorcycleRearTyres> MotorcycleRearTyres { get; set; }

        public DbSet<BreakPad> BreakPads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region MotorcycleTyres

            modelBuilder.Entity<MotorcycleFrontTyres>()
                .HasKey(mft => new { mft.MotorcycleId, mft.FrontTyreId });

            modelBuilder.Entity<MotorcycleFrontTyres>()
                .HasOne(mft => mft.Motorcycle)
                .WithMany(m => m.MotorcycleFrontTyres)
                .HasForeignKey(mft => mft.MotorcycleId);

            modelBuilder.Entity<MotorcycleFrontTyres>()
                .HasOne(mft => mft.FrontTyre)
                .WithMany(fTyre => fTyre.MotorcycleFrontTyres)
                .HasForeignKey(mft => mft.FrontTyreId);

            modelBuilder.Entity<MotorcycleRearTyres>()
                .HasKey(mft => new { mft.MotorcycleId, mft.RearTyreId });

            modelBuilder.Entity<MotorcycleRearTyres>()
                .HasOne(mft => mft.Motorcycle)
                .WithMany(m => m.MotorcycleRearTyres)
                .HasForeignKey(mft => mft.MotorcycleId);

            modelBuilder.Entity<MotorcycleRearTyres>()
                .HasOne(mft => mft.RearTyre)
                .WithMany(rTyre => rTyre.MotorcycleRearTyres)
                .HasForeignKey(mft => mft.RearTyreId);

            #endregion

        }
    }
}
