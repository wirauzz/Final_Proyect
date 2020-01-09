using Microsoft.EntityFrameworkCore;
using Restaurante_Proyecto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante_Proyecto.Data
{
    public class Restaurante_ProyectoDbContext : DbContext
    {
        public Restaurante_ProyectoDbContext(DbContextOptions<Restaurante_ProyectoDbContext> options):
            base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Crear la tabla en la base de datos
            modelBuilder.Entity<RestaurantEntity>().ToTable("Restaurants");
            //Establecer relaciones
            modelBuilder.Entity<RestaurantEntity>().HasMany(r => r.Dishes).WithOne(d => d.Restaurant);
            modelBuilder.Entity<RestaurantEntity>().Property(r => r.Id).ValueGeneratedOnAdd();

            //Crear tabla de platos en la base de datos
            modelBuilder.Entity<DishEntity>().ToTable("Dishes");
            //Establecer relaciones
            modelBuilder.Entity<DishEntity>().HasOne(d => d.Restaurant).WithMany(r => r.Dishes);
            modelBuilder.Entity<DishEntity>().Property(d => d.Id).ValueGeneratedOnAdd();
            
        }
        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<DishEntity> Dishes { get; set; }
    }
}
