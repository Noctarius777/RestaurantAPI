using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionString = "Server=.\\SQLExpress;Database=RestaurantDB;Trusted_Connection=Yes;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // nadpisjmey moteodę OnModelCreating która przyjmuje obiekt typu ModelBuilder
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired() // wymagana
                .HasMaxLength(30); // max 30 znaków
            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();
            modelBuilder.Entity<Address>()
                .Property(c => c.City)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Address>()
               .Property(s => s.Street)
               .IsRequired()
               .HasMaxLength(50);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // konfiguracja połączenia z bazą danych  
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
