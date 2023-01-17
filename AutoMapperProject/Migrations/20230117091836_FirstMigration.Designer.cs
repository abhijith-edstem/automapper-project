﻿// <auto-generated />
using System;
using AutoMapperTutorial.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoMapperProject.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230117091836_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutoMapperTutorial.Domain.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AutoMapperTutorial.Domain.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AutoMapperTutorial.Domain.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderId", "OrderItemId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("AutoMapperTutorial.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AutoMapperTutorial.Domain.Order", b =>
                {
                    b.HasOne("AutoMapperTutorial.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("AutoMapperTutorial.Domain.OrderItem", b =>
                {
                    b.HasOne("AutoMapperTutorial.Domain.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoMapperTutorial.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AutoMapperTutorial.Domain.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
