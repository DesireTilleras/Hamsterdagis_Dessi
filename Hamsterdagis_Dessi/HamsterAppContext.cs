using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd_database;


namespace Hamsterdagis_Dessi
{
    class HamsterAppContext : DbContext
    {
        public DbSet<Hamster> Hamsters { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<ExerciseArea> ExerciseAreas { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Logg_Activities> Logg_Activities { get; set; }

        public HamsterAppContext()
        {

        }
        public HamsterAppContext(DbContextOptions<HamsterAppContext> options)
    : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=advDesireTilleras;Trusted_Connection=True;")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
