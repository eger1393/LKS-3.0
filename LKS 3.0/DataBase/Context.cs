using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ACRISFlight>().HasMany(x => x.via);
		}

		#region Properties
		public DbSet<ACRISFlight> ACRISFlights { get; set; }
		public DbSet<AircraftType> AircraftTypes { get; set; }
		public DbSet<Airline> Airlines { get; set; }
		public DbSet<AirlineContact> AirlineContacts { get; set; }
		public DbSet<Airport> Airports { get; set; }
		public DbSet<AirportCoordinate> AirportCoordinates { get; set; }
		public DbSet<AirportCountry> AirportCountries { get; set; }
		public DbSet<AirportCurrentQueueTimes> AirportCurrentQueueTimes { get; set; }
		public DbSet<AirportForecastQueueTimes> AirportForecastQueueTimes { get; set; }
		public DbSet<AirportImageURL> AirportImageURL { get; set; }
		public DbSet<AirportPostalAddress> AirportPostalAddresses { get; set; }
		public DbSet<AirportVisitorsAddress> AirportVisitorsAddresses { get; set; }
		public DbSet<Arrival> Arrivals { get; set; }
		public DbSet<BaggageClaim> BaggageClaims { get; set; }
		public DbSet<BoardingTime> BoardingTimes { get; set; }
		public DbSet<BookService> BookServices { get; set; }
		public DbSet<CheckInInfo> CheckInInfos { get; set; }
		public DbSet<CodeShares> CodeShares { get; set; }
		public DbSet<Departure> Departures { get; set; }
		public DbSet<FlightNumber> FlightNumbers { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Logo> Logo { get; set; }
		public DbSet<OperatingAirline> OperatingAirlines { get; set; }
		public DbSet<Provider> Providers { get; set; }
		public DbSet<ProviderContact> ProviderContacts { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<ServiceElements> ServiceElements { get; set; }
		public DbSet<ServiceDonwload> ServiceDonwloads { get; set; }
		public DbSet<ServiceHeader> ServiceHeaders { get; set; }
		public DbSet<ServiceItem> ServiceItems { get; set; }
		public DbSet<ServiceLocations> ServiceLocations { get; set; }
		public DbSet<Specials> Specials { get; set; }
		public DbSet<Trip> Trips { get; set; }
		public DbSet<TripServices> TripServices { get; set; }
		public DbSet<Via> Vias { get; set; }
		public DbSet<ViaArrival> ViaArrivals { get; set; }
		public DbSet<ViaBaggageClaim> ViaBaggageClaims { get; set; }
		public DbSet<ViaBoardingTime> ViaBoardingTimes { get; set; }
		public DbSet<ViaCheckInInfo> ViaCheckInInfos { get; set; }
		public DbSet<ViaDeparture> ViaDepartures { get; set; }
		#endregion
	}
}
