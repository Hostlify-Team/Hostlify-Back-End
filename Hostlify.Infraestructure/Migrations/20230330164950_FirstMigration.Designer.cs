﻿// <auto-generated />
using System;
using Hostlify.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hostlify.Infraestructure.Migrations
{
    [DbContext(typeof(HostlifyDB))]
    [Migration("20230330164950_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Hostlify.Infraestructure.FoodServices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cream")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CreamQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(7409));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Dish")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DishQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Drink")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DrinkQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Instruction")
                        .HasMaxLength(999)
                        .HasColumnType("varchar(999)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<int>("ManagerID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FoodServices", (string)null);
                });

            modelBuilder.Entity("Hostlify.Infraestructure.History", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(6457));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<string>("description")
                        .HasColumnType("longtext");

                    b.Property<string>("endDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("guestName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("initialDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("managerId")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("roomName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("id");

                    b.ToTable("History", (string)null);
                });

            modelBuilder.Entity("Hostlify.Infraestructure.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(5570));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(999)
                        .HasColumnType("varchar(999)");

                    b.Property<bool>("Emergency")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("EndDate")
                        .HasColumnType("longtext");

                    b.Property<int?>("GuestId")
                        .HasColumnType("int");

                    b.Property<string>("Initialdate")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<bool>("ServicePending")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("Hostlify.Infraestructure.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(3962));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Plan")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}