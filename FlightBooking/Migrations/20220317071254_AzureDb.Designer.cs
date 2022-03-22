﻿// <auto-generated />
using System;
using FlightBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightBooking.Migrations
{
    [DbContext(typeof(FlightDbContext))]
    [Migration("20220317071254_AzureDb")]
    partial class AzureDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightBooking.Models.Airline", b =>
                {
                    b.Property<Guid>("AirlineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AirlineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BusinessSeat")
                        .HasColumnType("int");

                    b.Property<string>("ContactAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NonBusinessSeat")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AirlineId");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("FlightBooking.Models.Airport", b =>
                {
                    b.Property<Guid>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AirportName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirportId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("FlightBooking.Models.Booking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AirlineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<short>("Meal")
                        .HasColumnType("smallint");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("PNR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookingId");

                    b.HasIndex("AirlineId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("FlightBooking.Models.Discount", b =>
                {
                    b.Property<Guid>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("DiscountCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiscountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("FlightBooking.Models.Instrument", b =>
                {
                    b.Property<Guid>("InstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InstrumentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrumentId");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("FlightBooking.Models.Inventory", b =>
                {
                    b.Property<Guid>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AirlineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DestinationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rows")
                        .HasColumnType("int");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TicketCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("foodType")
                        .HasColumnType("smallint");

                    b.HasKey("InventoryId");

                    b.HasIndex("AirlineId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("SourceId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("FlightBooking.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Gender")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerId");

                    b.HasIndex("BookingId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("FlightBooking.Models.Booking", b =>
                {
                    b.HasOne("FlightBooking.Models.Airline", null)
                        .WithMany("Booking")
                        .HasForeignKey("AirlineId");

                    b.HasOne("FlightBooking.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("FlightBooking.Models.Inventory", b =>
                {
                    b.HasOne("FlightBooking.Models.Airline", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightBooking.Models.Airport", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightBooking.Models.Airport", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");

                    b.Navigation("Destination");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("FlightBooking.Models.Passenger", b =>
                {
                    b.HasOne("FlightBooking.Models.Booking", "Booking")
                        .WithMany("Passenger")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("FlightBooking.Models.Airline", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("FlightBooking.Models.Booking", b =>
                {
                    b.Navigation("Passenger");
                });
#pragma warning restore 612, 618
        }
    }
}
