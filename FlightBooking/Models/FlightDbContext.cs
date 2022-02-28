using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Models
{
    public class FlightDbContext : DbContext

    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Airport>().HasMany(airport => airport.Source)
                                          .WithOne(x => x.Source)
                                          .HasForeignKey(con => con.SourceId);

            modelbuilder.Entity<Airport>().HasMany(airport => airport.Destination)
                                       .WithOne(x => x.Destination)
                                       .HasForeignKey(con => con.DestinationId);

        }

        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        //public DbSet<User> Users { get; set; }
    }
}
