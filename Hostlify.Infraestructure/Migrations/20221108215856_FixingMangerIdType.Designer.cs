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
    [Migration("20221108215856_FixingMangerIdType")]
    partial class FixingMangerIdType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Hostlify.Infraestructure.History", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 11, 8, 16, 58, 56, 199, DateTimeKind.Local).AddTicks(8353));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("endDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("guestEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("guestId")
                        .HasColumnType("int");

                    b.Property<string>("guestName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("initialDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("managerId")
                        .HasColumnType("int");

                    b.Property<int?>("price")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("roomName")
                        .HasMaxLength(15)
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("History", (string)null);
                });

            modelBuilder.Entity("Hostlify.Infraestructure.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 11, 8, 16, 58, 56, 199, DateTimeKind.Local).AddTicks(7015));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Rooms")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Plans", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}