﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Suppliers.Data;

namespace Suppliers.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20201202155155_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("Suppliers.Models.Purchase", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<string>("EmployeeName")
                        .HasColumnName("employee_name");

                    b.Property<decimal>("Price")
                        .HasColumnName("price");

                    b.Property<string>("ProductName")
                        .HasColumnName("product_name");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.HasKey("id");

                    b.ToTable("Purchase");
                });
#pragma warning restore 612, 618
        }
    }
}