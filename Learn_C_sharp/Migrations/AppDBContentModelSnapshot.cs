﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Data;

namespace Shop.Migrations
{
    [DbContext(typeof(AppDBContent))]
    partial class AppDBContentModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shop.Data.Models.Car", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Categoryid")
                        .HasColumnType("int");

                    b.Property<bool>("availableCar")
                        .HasColumnType("bit");

                    b.Property<int>("categoryIDCar")
                        .HasColumnType("int");

                    b.Property<string>("imgCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isFavouriteCar")
                        .HasColumnType("bit");

                    b.Property<string>("longDescCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("priceCar")
                        .HasColumnType("int");

                    b.Property<string>("shortDescCar")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Shop.Data.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Shop.Data.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("orderTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Shop.Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("carId")
                        .HasColumnType("int");

                    b.Property<int>("orderAD")
                        .HasColumnType("int");

                    b.Property<int?>("orderid")
                        .HasColumnType("int");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("carId");

                    b.HasIndex("orderid");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Shop.Data.Models.ShopCartItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShopCartId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("carid")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("carid");

                    b.ToTable("ShopCartItem");
                });

            modelBuilder.Entity("Shop.Data.Models.Car", b =>
                {
                    b.HasOne("Shop.Data.Models.Category", "Category")
                        .WithMany("cars")
                        .HasForeignKey("Categoryid");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shop.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("Shop.Data.Models.Car", "car")
                        .WithMany()
                        .HasForeignKey("carId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.Order", "order")
                        .WithMany("OrderDetail")
                        .HasForeignKey("orderid");

                    b.Navigation("car");

                    b.Navigation("order");
                });

            modelBuilder.Entity("Shop.Data.Models.ShopCartItem", b =>
                {
                    b.HasOne("Shop.Data.Models.Car", "car")
                        .WithMany()
                        .HasForeignKey("carid");

                    b.Navigation("car");
                });

            modelBuilder.Entity("Shop.Data.Models.Category", b =>
                {
                    b.Navigation("cars");
                });

            modelBuilder.Entity("Shop.Data.Models.Order", b =>
                {
                    b.Navigation("OrderDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
