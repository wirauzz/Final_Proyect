﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurante_Proyecto.Data;

namespace Restaurante_Proyecto.Data.Migrations
{
    [DbContext(typeof(Restaurante_ProyectoDbContext))]
    partial class Restaurante_ProyectoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Restaurante_Proyecto.Data.Entities.DishEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost");

                    b.Property<string>("ImagePath");

                    b.Property<string>("MainIngredient");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Nationality")
                        .IsRequired();

                    b.Property<int?>("RestaurantId");

                    b.Property<string>("Size");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Restaurante_Proyecto.Data.Entities.RestaurantEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressNumber");

                    b.Property<string>("FoodStyle");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Restaurante_Proyecto.Data.Entities.DishEntity", b =>
                {
                    b.HasOne("Restaurante_Proyecto.Data.Entities.RestaurantEntity", "Restaurant")
                        .WithMany("Dishes")
                        .HasForeignKey("RestaurantId");
                });
#pragma warning restore 612, 618
        }
    }
}
