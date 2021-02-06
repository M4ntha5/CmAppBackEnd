﻿// <auto-generated />
using System;
using CmApp.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CmApp.Contracts.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210206141234_Initial1")]
    partial class Initial1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CmApp.Contracts.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BodyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Displacement")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Drive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Engine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interior")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ManufactureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Power")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Series")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Steering")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transmission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Vin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.HasIndex("ModelId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.CarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarImages");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.PasswordReset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordResets");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Repair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Shipping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("AuctionFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("AuctionFeeCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Customs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomsCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TransferFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TransferFeeCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TransportationFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TransportationFeeCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Shippings");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Summary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BoughtPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SoldDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("SoldPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Summaries");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Tracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirBag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContainerNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Damage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOrdered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatePickedUp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<string>("FinalPort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keys")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Radio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Running")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wheels")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Trackings");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.TrackingImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TrackingId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TrackingId");

                    b.ToTable("TrackingImages");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Car", b =>
                {
                    b.HasOne("CmApp.Contracts.Models.Make", "Make")
                        .WithMany()
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CmApp.Contracts.Models.Model", "Model")
                        .WithOne("Car")
                        .HasForeignKey("CmApp.Contracts.Models.Car", "ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CmApp.Contracts.Models.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CmApp.Contracts.Models.CarImage", b =>
                {
                    b.HasOne("CmApp.Contracts.Models.Car", "Car")
                        .WithMany("Images")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Equipment", b =>
                {
                    b.HasOne("CmApp.Contracts.Models.Car", "Car")
                        .WithMany("Equipment")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Model", b =>
                {
                    b.HasOne("CmApp.Contracts.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CmApp.Contracts.Models.PasswordReset", b =>
                {
                    b.HasOne("CmApp.Contracts.Models.User", "User")
                        .WithMany("PasswordResets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Repair", b =>
                {
                    b.HasOne("CmApp.Contracts.Models.Car", "Car")
                        .WithMany("Repairs")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Shipping", b =>
                {
                    b.HasOne("CmApp.Contracts.Models.Car", "Car")
                        .WithOne("Shipping")
                        .HasForeignKey("CmApp.Contracts.Models.Shipping", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Summary", b =>
                {
                    b.HasOne("CmApp.Contracts.Models.Car", "Car")
                        .WithOne("Summary")
                        .HasForeignKey("CmApp.Contracts.Models.Summary", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CmApp.Contracts.Models.Tracking", b =>
                {
                    b.HasOne("CmApp.Contracts.Models.Car", "Car")
                        .WithOne("Tracking")
                        .HasForeignKey("CmApp.Contracts.Models.Tracking", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CmApp.Contracts.Models.TrackingImage", b =>
                {
                    b.HasOne("CmApp.Contracts.Models.Tracking", "Tracking")
                        .WithMany("Images")
                        .HasForeignKey("TrackingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
