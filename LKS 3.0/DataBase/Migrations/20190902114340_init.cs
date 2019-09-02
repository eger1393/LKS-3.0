using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftTypes",
                columns: table => new
                {
                    aircraftTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    icaoCode = table.Column<string>(maxLength: 10, nullable: true),
                    modelName = table.Column<string>(maxLength: 255, nullable: true),
                    registration = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTypes", x => x.aircraftTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AirlineContacts",
                columns: table => new
                {
                    airlineContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    country_name = table.Column<string>(maxLength: 255, nullable: false),
                    country_tag = table.Column<string>(maxLength: 100, nullable: true),
                    extended_address = table.Column<string>(nullable: true),
                    locality = table.Column<string>(maxLength: 255, nullable: false),
                    post_office_box = table.Column<string>(maxLength: 50, nullable: true),
                    postal_code = table.Column<string>(maxLength: 50, nullable: true),
                    region = table.Column<string>(maxLength: 255, nullable: false),
                    street_address = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineContacts", x => x.airlineContactId);
                });

            migrationBuilder.CreateTable(
                name: "AirportCoordinates",
                columns: table => new
                {
                    airportCoordinateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    elevation = table.Column<int>(nullable: true),
                    latitude = table.Column<double>(nullable: false),
                    lonqitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportCoordinates", x => x.airportCoordinateID);
                });

            migrationBuilder.CreateTable(
                name: "AirportCurrentQueueTimes",
                columns: table => new
                {
                    airportCurrentQueueTimesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    currentProjectedMaxWaitTime = table.Column<int>(nullable: true),
                    currentProjectedMinWaitTime = table.Column<int>(nullable: true),
                    currentProjectedWaitTime = table.Column<int>(nullable: true),
                    currentQueueName = table.Column<string>(maxLength: 255, nullable: true),
                    currentTime = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportCurrentQueueTimes", x => x.airportCurrentQueueTimesID);
                });

            migrationBuilder.CreateTable(
                name: "AirportForecastQueueTimes",
                columns: table => new
                {
                    airportForecastQueueTimesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    forecastConfidence = table.Column<int>(nullable: true),
                    forecastProjectedWaitTime = table.Column<int>(nullable: true),
                    currentQueueName = table.Column<string>(maxLength: 255, nullable: true),
                    currentTime = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportForecastQueueTimes", x => x.airportForecastQueueTimesID);
                });

            migrationBuilder.CreateTable(
                name: "AirportImageURL",
                columns: table => new
                {
                    airportImageURLID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    high = table.Column<string>(maxLength: 20, nullable: true),
                    low = table.Column<string>(maxLength: 20, nullable: true),
                    medium = table.Column<string>(maxLength: 20, nullable: true),
                    native = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportImageURL", x => x.airportImageURLID);
                });

            migrationBuilder.CreateTable(
                name: "AirportInfos",
                columns: table => new
                {
                    airportInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    valid_from = table.Column<DateTime>(nullable: true),
                    valid_to = table.Column<DateTime>(nullable: true),
                    created = table.Column<DateTime>(nullable: true),
                    title = table.Column<string>(maxLength: 255, nullable: true),
                    infoType = table.Column<string>(maxLength: 255, nullable: true),
                    message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportInfos", x => x.airportInfoId);
                });

            migrationBuilder.CreateTable(
                name: "AirportPostalAddresses",
                columns: table => new
                {
                    airportPostalAddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    country_name = table.Column<string>(maxLength: 255, nullable: false),
                    country_tag = table.Column<string>(maxLength: 100, nullable: true),
                    extended_address = table.Column<string>(nullable: true),
                    locality = table.Column<string>(maxLength: 255, nullable: false),
                    post_office_box = table.Column<string>(maxLength: 50, nullable: true),
                    postal_code = table.Column<string>(maxLength: 50, nullable: true),
                    region = table.Column<string>(maxLength: 255, nullable: false),
                    street_address = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportPostalAddresses", x => x.airportPostalAddressID);
                });

            migrationBuilder.CreateTable(
                name: "AirportVisitorsAddresses",
                columns: table => new
                {
                    airportVisitorsAddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    country_name = table.Column<string>(maxLength: 255, nullable: false),
                    country_tag = table.Column<string>(maxLength: 100, nullable: true),
                    extended_address = table.Column<string>(nullable: true),
                    locality = table.Column<string>(maxLength: 255, nullable: false),
                    post_office_box = table.Column<string>(maxLength: 50, nullable: true),
                    postal_code = table.Column<string>(maxLength: 50, nullable: true),
                    region = table.Column<string>(maxLength: 255, nullable: false),
                    street_address = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportVisitorsAddresses", x => x.airportVisitorsAddressID);
                });

            migrationBuilder.CreateTable(
                name: "BaggageClaims",
                columns: table => new
                {
                    baggageClaimID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    carousel = table.Column<string>(maxLength: 255, nullable: true),
                    expectedTimeOnCarousel = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaggageClaims", x => x.baggageClaimID);
                });

            migrationBuilder.CreateTable(
                name: "CheckInInfos",
                columns: table => new
                {
                    checkInInfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    additionalInfo = table.Column<string>(maxLength: 300, nullable: true),
                    checkInBeginTime = table.Column<DateTime>(nullable: true),
                    checkInEndTime = table.Column<DateTime>(nullable: true),
                    checkInLocation = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInInfos", x => x.checkInInfoID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    imageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    high = table.Column<string>(maxLength: 20, nullable: true),
                    low = table.Column<string>(maxLength: 20, nullable: true),
                    medium = table.Column<string>(maxLength: 20, nullable: true),
                    native = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.imageID);
                });

            migrationBuilder.CreateTable(
                name: "Logo",
                columns: table => new
                {
                    logoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    logo_high = table.Column<string>(maxLength: 20, nullable: true),
                    logo_low = table.Column<string>(maxLength: 20, nullable: true),
                    logo_medium = table.Column<string>(maxLength: 20, nullable: true),
                    logo_native = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logo", x => x.logoID);
                });

            migrationBuilder.CreateTable(
                name: "OperatingAirlines",
                columns: table => new
                {
                    operatingAirlineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    iataCode = table.Column<string>(maxLength: 10, nullable: true),
                    icaoCode = table.Column<string>(maxLength: 10, nullable: true),
                    name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingAirlines", x => x.operatingAirlineID);
                });

            migrationBuilder.CreateTable(
                name: "ProviderContacts",
                columns: table => new
                {
                    providerContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    country_name = table.Column<string>(maxLength: 255, nullable: false),
                    country_tag = table.Column<string>(maxLength: 100, nullable: true),
                    extended_address = table.Column<string>(nullable: true),
                    locality = table.Column<string>(maxLength: 255, nullable: false),
                    post_office_box = table.Column<string>(maxLength: 50, nullable: true),
                    postal_code = table.Column<string>(maxLength: 50, nullable: true),
                    region = table.Column<string>(maxLength: 255, nullable: false),
                    street_address = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderContacts", x => x.providerContactID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceHeaders",
                columns: table => new
                {
                    serviceHeaderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bookingID = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    extBookingID = table.Column<string>(nullable: true),
                    serviceID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHeaders", x => x.serviceHeaderID);
                });

            migrationBuilder.CreateTable(
                name: "TripServices",
                columns: table => new
                {
                    tripServicesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bookingID = table.Column<string>(nullable: true),
                    serviceID = table.Column<string>(nullable: false),
                    source = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripServices", x => x.tripServicesID);
                });

            migrationBuilder.CreateTable(
                name: "ViaBaggageClaims",
                columns: table => new
                {
                    viaBaggageClaimID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    carousel = table.Column<string>(maxLength: 255, nullable: true),
                    expectedTimeOnCarousel = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaBaggageClaims", x => x.viaBaggageClaimID);
                });

            migrationBuilder.CreateTable(
                name: "ViaBoardingTimes",
                columns: table => new
                {
                    viaBoardingTimeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bookingClass = table.Column<string>(maxLength: 255, nullable: true),
                    time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaBoardingTimes", x => x.viaBoardingTimeID);
                });

            migrationBuilder.CreateTable(
                name: "ViaCheckInInfos",
                columns: table => new
                {
                    viaCheckInInfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    additionalInfo = table.Column<string>(maxLength: 255, nullable: true),
                    checkInBeginTime = table.Column<DateTime>(nullable: true),
                    checkInEndTime = table.Column<DateTime>(nullable: true),
                    checkInLocation = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaCheckInInfos", x => x.viaCheckInInfoID);
                });

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    airlineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    airlineName = table.Column<string>(maxLength: 255, nullable: false),
                    checkIn = table.Column<string>(maxLength: 255, nullable: true),
                    checkInTime = table.Column<string>(maxLength: 50, nullable: true),
                    airlineContactId = table.Column<int>(nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    faxNumber = table.Column<string>(maxLength: 50, nullable: true),
                    flightNumberCode = table.Column<string>(maxLength: 50, nullable: true),
                    handlingAgent = table.Column<string>(maxLength: 100, nullable: true),
                    iataCode = table.Column<string>(maxLength: 10, nullable: true),
                    icaoCode = table.Column<string>(maxLength: 10, nullable: false),
                    info = table.Column<string>(maxLength: 255, nullable: true),
                    lateNightArea = table.Column<string>(maxLength: 255, nullable: true),
                    lateNightTimes = table.Column<string>(maxLength: 255, nullable: true),
                    onlineCheckInURL = table.Column<string>(maxLength: 255, nullable: true),
                    serviceTime = table.Column<string>(maxLength: 50, nullable: true),
                    telephoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    terminal = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.airlineID);
                    table.ForeignKey(
                        name: "FK_Airlines_AirlineContacts_airlineContactId",
                        column: x => x.airlineContactId,
                        principalTable: "AirlineContacts",
                        principalColumn: "airlineContactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AirportInfoExternalLink",
                columns: table => new
                {
                    airportInfoExternalLinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    url = table.Column<string>(maxLength: 255, nullable: false),
                    airportInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportInfoExternalLink", x => x.airportInfoExternalLinkId);
                    table.ForeignKey(
                        name: "FK_AirportInfoExternalLink_AirportInfos_airportInfoId",
                        column: x => x.airportInfoId,
                        principalTable: "AirportInfos",
                        principalColumn: "airportInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    airportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    airportImageURLID = table.Column<int>(nullable: true),
                    airportName = table.Column<string>(maxLength: 255, nullable: true),
                    cityName = table.Column<string>(maxLength: 255, nullable: true),
                    coordinateairportCoordinateID = table.Column<int>(nullable: true),
                    currentQueueTimesairportCurrentQueueTimesID = table.Column<int>(nullable: true),
                    forecastQueueTimesairportForecastQueueTimesID = table.Column<int>(nullable: true),
                    geofenceRadius = table.Column<double>(nullable: true),
                    iataCode = table.Column<string>(maxLength: 10, nullable: true),
                    icaoCode = table.Column<string>(maxLength: 10, nullable: false),
                    postalAddressairportPostalAddressID = table.Column<int>(nullable: true),
                    timezone = table.Column<string>(maxLength: 50, nullable: true),
                    vasitorsAddressairportVisitorsAddressID = table.Column<int>(nullable: true),
                    telephoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.airportID);
                    table.ForeignKey(
                        name: "FK_Airports_AirportImageURL_airportImageURLID",
                        column: x => x.airportImageURLID,
                        principalTable: "AirportImageURL",
                        principalColumn: "airportImageURLID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Airports_AirportCoordinates_coordinateairportCoordinateID",
                        column: x => x.coordinateairportCoordinateID,
                        principalTable: "AirportCoordinates",
                        principalColumn: "airportCoordinateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Airports_AirportCurrentQueueTimes_currentQueueTimesairportCurrentQueueTimesID",
                        column: x => x.currentQueueTimesairportCurrentQueueTimesID,
                        principalTable: "AirportCurrentQueueTimes",
                        principalColumn: "airportCurrentQueueTimesID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Airports_AirportForecastQueueTimes_forecastQueueTimesairportForecastQueueTimesID",
                        column: x => x.forecastQueueTimesairportForecastQueueTimesID,
                        principalTable: "AirportForecastQueueTimes",
                        principalColumn: "airportForecastQueueTimesID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Airports_AirportPostalAddresses_postalAddressairportPostalAddressID",
                        column: x => x.postalAddressairportPostalAddressID,
                        principalTable: "AirportPostalAddresses",
                        principalColumn: "airportPostalAddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Airports_AirportVisitorsAddresses_vasitorsAddressairportVisitorsAddressID",
                        column: x => x.vasitorsAddressairportVisitorsAddressID,
                        principalTable: "AirportVisitorsAddresses",
                        principalColumn: "airportVisitorsAddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Arrivals",
                columns: table => new
                {
                    arrivalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    actual = table.Column<DateTime>(nullable: true),
                    baggaageClaimbaggageClaimID = table.Column<int>(nullable: true),
                    estimated = table.Column<DateTime>(nullable: true),
                    gate = table.Column<string>(maxLength: 10, nullable: true),
                    scheduled = table.Column<DateTime>(nullable: false),
                    termnal = table.Column<string>(maxLength: 10, nullable: true),
                    transferInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrivals", x => x.arrivalID);
                    table.ForeignKey(
                        name: "FK_Arrivals_BaggageClaims_baggaageClaimbaggageClaimID",
                        column: x => x.baggaageClaimbaggageClaimID,
                        principalTable: "BaggageClaims",
                        principalColumn: "baggageClaimID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departures",
                columns: table => new
                {
                    departureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    actual = table.Column<DateTime>(nullable: true),
                    checkInInfoID = table.Column<int>(nullable: true),
                    estimated = table.Column<DateTime>(nullable: true),
                    gate = table.Column<string>(maxLength: 10, nullable: true),
                    scheduled = table.Column<DateTime>(nullable: false),
                    terminal = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departures", x => x.departureID);
                    table.ForeignKey(
                        name: "FK_Departures_CheckInInfos_checkInInfoID",
                        column: x => x.checkInInfoID,
                        principalTable: "CheckInInfos",
                        principalColumn: "checkInInfoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceLocations",
                columns: table => new
                {
                    serviceLocationsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    area = table.Column<string>(maxLength: 255, nullable: false),
                    description = table.Column<string>(nullable: true),
                    humanReadable = table.Column<string>(maxLength: 255, nullable: false),
                    mapImageimageID = table.Column<int>(nullable: true),
                    x = table.Column<int>(nullable: false),
                    y = table.Column<int>(nullable: false),
                    z = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLocations", x => x.serviceLocationsID);
                    table.ForeignKey(
                        name: "FK_ServiceLocations_Images_mapImageimageID",
                        column: x => x.mapImageimageID,
                        principalTable: "Images",
                        principalColumn: "imageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    providerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contactproviderContactID = table.Column<int>(nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    fax = table.Column<string>(maxLength: 100, nullable: true),
                    logoID = table.Column<int>(nullable: true),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    website = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.providerID);
                    table.ForeignKey(
                        name: "FK_Providers_ProviderContacts_contactproviderContactID",
                        column: x => x.contactproviderContactID,
                        principalTable: "ProviderContacts",
                        principalColumn: "providerContactID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Providers_Logo_logoID",
                        column: x => x.logoID,
                        principalTable: "Logo",
                        principalColumn: "logoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookServices",
                columns: table => new
                {
                    bookServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    serviceHeaderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookServices", x => x.bookServiceID);
                    table.ForeignKey(
                        name: "FK_BookServices_ServiceHeaders_serviceHeaderID",
                        column: x => x.serviceHeaderID,
                        principalTable: "ServiceHeaders",
                        principalColumn: "serviceHeaderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    tripID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    endDate = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    role = table.Column<string>(maxLength: 255, nullable: false),
                    servicestripServicesID = table.Column<int>(nullable: true),
                    startDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.tripID);
                    table.ForeignKey(
                        name: "FK_Trips_TripServices_servicestripServicesID",
                        column: x => x.servicestripServicesID,
                        principalTable: "TripServices",
                        principalColumn: "tripServicesID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ViaArrivals",
                columns: table => new
                {
                    viaArrivalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    actual = table.Column<DateTime>(nullable: true),
                    baggaageClaimviaBaggageClaimID = table.Column<int>(nullable: true),
                    estimated = table.Column<DateTime>(nullable: true),
                    gate = table.Column<string>(maxLength: 10, nullable: true),
                    scheduled = table.Column<DateTime>(nullable: false),
                    termnal = table.Column<string>(maxLength: 10, nullable: true),
                    transferInformation = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaArrivals", x => x.viaArrivalID);
                    table.ForeignKey(
                        name: "FK_ViaArrivals_ViaBaggageClaims_baggaageClaimviaBaggageClaimID",
                        column: x => x.baggaageClaimviaBaggageClaimID,
                        principalTable: "ViaBaggageClaims",
                        principalColumn: "viaBaggageClaimID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ViaDepartures",
                columns: table => new
                {
                    viaDepartureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    actual = table.Column<DateTime>(nullable: true),
                    boardingTimeviaBoardingTimeID = table.Column<int>(nullable: true),
                    checkInInfoviaCheckInInfoID = table.Column<int>(nullable: true),
                    estimated = table.Column<DateTime>(nullable: true),
                    gate = table.Column<string>(maxLength: 10, nullable: true),
                    scheduled = table.Column<DateTime>(nullable: false),
                    terminal = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaDepartures", x => x.viaDepartureID);
                    table.ForeignKey(
                        name: "FK_ViaDepartures_ViaBoardingTimes_boardingTimeviaBoardingTimeID",
                        column: x => x.boardingTimeviaBoardingTimeID,
                        principalTable: "ViaBoardingTimes",
                        principalColumn: "viaBoardingTimeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViaDepartures_ViaCheckInInfos_checkInInfoviaCheckInInfoID",
                        column: x => x.checkInInfoviaCheckInInfoID,
                        principalTable: "ViaCheckInInfos",
                        principalColumn: "viaCheckInInfoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AirlineWebsite",
                columns: table => new
                {
                    airlineWebsiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    url = table.Column<string>(maxLength: 255, nullable: false),
                    airlineID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineWebsite", x => x.airlineWebsiteId);
                    table.ForeignKey(
                        name: "FK_AirlineWebsite_Airlines_airlineID",
                        column: x => x.airlineID,
                        principalTable: "Airlines",
                        principalColumn: "airlineID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AirportWebsite",
                columns: table => new
                {
                    airportWebsiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    url = table.Column<string>(maxLength: 255, nullable: false),
                    airportID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportWebsite", x => x.airportWebsiteId);
                    table.ForeignKey(
                        name: "FK_AirportWebsite_Airports_airportID",
                        column: x => x.airportID,
                        principalTable: "Airports",
                        principalColumn: "airportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardingTimes",
                columns: table => new
                {
                    boardingTimeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bookingClass = table.Column<string>(maxLength: 255, nullable: true),
                    time = table.Column<DateTime>(nullable: true),
                    departureID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardingTimes", x => x.boardingTimeID);
                    table.ForeignKey(
                        name: "FK_BoardingTimes_Departures_departureID",
                        column: x => x.departureID,
                        principalTable: "Departures",
                        principalColumn: "departureID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpeningHour",
                columns: table => new
                {
                    openingHourID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    column1 = table.Column<string>(nullable: false),
                    column2 = table.Column<string>(nullable: false),
                    serviceLocationsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningHour", x => x.openingHourID);
                    table.ForeignKey(
                        name: "FK_OpeningHour_ServiceLocations_serviceLocationsID",
                        column: x => x.serviceLocationsID,
                        principalTable: "ServiceLocations",
                        principalColumn: "serviceLocationsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    serviceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    subTitle = table.Column<string>(maxLength: 255, nullable: true),
                    shortDescription = table.Column<string>(maxLength: 255, nullable: true),
                    description = table.Column<string>(nullable: true),
                    isBookable = table.Column<bool>(nullable: false),
                    iconimageID = table.Column<int>(nullable: true),
                    titleImageimageID = table.Column<int>(nullable: true),
                    titleImage_smallimageID = table.Column<int>(nullable: true),
                    desciptionImage_verticalimageID = table.Column<int>(nullable: true),
                    descriptionImage_horizontalimageID = table.Column<int>(nullable: true),
                    providerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.serviceID);
                    table.ForeignKey(
                        name: "FK_Services_Images_desciptionImage_verticalimageID",
                        column: x => x.desciptionImage_verticalimageID,
                        principalTable: "Images",
                        principalColumn: "imageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Images_descriptionImage_horizontalimageID",
                        column: x => x.descriptionImage_horizontalimageID,
                        principalTable: "Images",
                        principalColumn: "imageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Images_iconimageID",
                        column: x => x.iconimageID,
                        principalTable: "Images",
                        principalColumn: "imageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Providers_providerID",
                        column: x => x.providerID,
                        principalTable: "Providers",
                        principalColumn: "providerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Images_titleImage_smallimageID",
                        column: x => x.titleImage_smallimageID,
                        principalTable: "Images",
                        principalColumn: "imageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Images_titleImageimageID",
                        column: x => x.titleImageimageID,
                        principalTable: "Images",
                        principalColumn: "imageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripFlight",
                columns: table => new
                {
                    tripFlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    flightID = table.Column<string>(maxLength: 255, nullable: false),
                    pnr = table.Column<string>(maxLength: 255, nullable: true),
                    tripID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripFlight", x => x.tripFlightId);
                    table.ForeignKey(
                        name: "FK_TripFlight_Trips_tripID",
                        column: x => x.tripID,
                        principalTable: "Trips",
                        principalColumn: "tripID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBulletpoints",
                columns: table => new
                {
                    serviceBulletpointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    order = table.Column<int>(nullable: false),
                    headerText = table.Column<string>(maxLength: 255, nullable: true),
                    footerText = table.Column<string>(maxLength: 255, nullable: true),
                    serviceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBulletpoints", x => x.serviceBulletpointId);
                    table.ForeignKey(
                        name: "FK_ServiceBulletpoints_Services_serviceID",
                        column: x => x.serviceID,
                        principalTable: "Services",
                        principalColumn: "serviceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDonwloads",
                columns: table => new
                {
                    serviceDonwloadsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    url = table.Column<string>(maxLength: 255, nullable: false),
                    serviceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDonwloads", x => x.serviceDonwloadsId);
                    table.ForeignKey(
                        name: "FK_ServiceDonwloads_Services_serviceID",
                        column: x => x.serviceID,
                        principalTable: "Services",
                        principalColumn: "serviceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTables",
                columns: table => new
                {
                    serviceTableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    order = table.Column<int>(nullable: false),
                    headerText = table.Column<string>(maxLength: 255, nullable: true),
                    footerText = table.Column<string>(maxLength: 255, nullable: true),
                    position = table.Column<string>(maxLength: 255, nullable: true),
                    serviceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTables", x => x.serviceTableId);
                    table.ForeignKey(
                        name: "FK_ServiceTables_Services_serviceID",
                        column: x => x.serviceID,
                        principalTable: "Services",
                        principalColumn: "serviceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceText",
                columns: table => new
                {
                    serviceTextId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    order = table.Column<int>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    serviceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceText", x => x.serviceTextId);
                    table.ForeignKey(
                        name: "FK_ServiceText_Services_serviceID",
                        column: x => x.serviceID,
                        principalTable: "Services",
                        principalColumn: "serviceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specials",
                columns: table => new
                {
                    specialsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    description = table.Column<string>(nullable: true),
                    numberOfAvailable = table.Column<int>(nullable: false),
                    imageID = table.Column<int>(nullable: true),
                    begin = table.Column<DateTime>(nullable: true),
                    end = table.Column<DateTime>(nullable: true),
                    coupon = table.Column<string>(maxLength: 255, nullable: true),
                    serviceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specials", x => x.specialsID);
                    table.ForeignKey(
                        name: "FK_Specials_Images_imageID",
                        column: x => x.imageID,
                        principalTable: "Images",
                        principalColumn: "imageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specials_Services_serviceID",
                        column: x => x.serviceID,
                        principalTable: "Services",
                        principalColumn: "serviceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBulletpointElements",
                columns: table => new
                {
                    serviceBulletpointElementsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    value = table.Column<string>(nullable: false),
                    serviceBulletpointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBulletpointElements", x => x.serviceBulletpointElementsId);
                    table.ForeignKey(
                        name: "FK_ServiceBulletpointElements_ServiceBulletpoints_serviceBulletpointId",
                        column: x => x.serviceBulletpointId,
                        principalTable: "ServiceBulletpoints",
                        principalColumn: "serviceBulletpointId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTableRow",
                columns: table => new
                {
                    serviceTableRowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    column1 = table.Column<string>(nullable: false),
                    column2 = table.Column<string>(nullable: false),
                    serviceTableId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTableRow", x => x.serviceTableRowId);
                    table.ForeignKey(
                        name: "FK_ServiceTableRow_ServiceTables_serviceTableId",
                        column: x => x.serviceTableId,
                        principalTable: "ServiceTables",
                        principalColumn: "serviceTableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightNumbers",
                columns: table => new
                {
                    flightNumberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    airlineCode = table.Column<string>(maxLength: 50, nullable: false),
                    suffix = table.Column<string>(maxLength: 50, nullable: true),
                    trackNumber = table.Column<string>(maxLength: 50, nullable: false),
                    ACRISFlightID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightNumbers", x => x.flightNumberID);
                });

            migrationBuilder.CreateTable(
                name: "ACRISFlights",
                columns: table => new
                {
                    ACRISFlightID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    aircrafTypeaircraftTypeID = table.Column<int>(nullable: true),
                    arrivalID = table.Column<int>(nullable: true),
                    arrivalAirport = table.Column<string>(maxLength: 255, nullable: true),
                    departureID = table.Column<int>(nullable: true),
                    departureAirport = table.Column<string>(maxLength: 255, nullable: true),
                    flightNumberID = table.Column<int>(nullable: false),
                    flightStatus = table.Column<string>(maxLength: 100, nullable: false),
                    operatingAirlineID = table.Column<int>(nullable: false),
                    originDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACRISFlights", x => x.ACRISFlightID);
                    table.ForeignKey(
                        name: "FK_ACRISFlights_AircraftTypes_aircrafTypeaircraftTypeID",
                        column: x => x.aircrafTypeaircraftTypeID,
                        principalTable: "AircraftTypes",
                        principalColumn: "aircraftTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACRISFlights_Arrivals_arrivalID",
                        column: x => x.arrivalID,
                        principalTable: "Arrivals",
                        principalColumn: "arrivalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACRISFlights_Departures_departureID",
                        column: x => x.departureID,
                        principalTable: "Departures",
                        principalColumn: "departureID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACRISFlights_FlightNumbers_flightNumberID",
                        column: x => x.flightNumberID,
                        principalTable: "FlightNumbers",
                        principalColumn: "flightNumberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ACRISFlights_OperatingAirlines_operatingAirlineID",
                        column: x => x.operatingAirlineID,
                        principalTable: "OperatingAirlines",
                        principalColumn: "operatingAirlineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vias",
                columns: table => new
                {
                    viaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    arrivalviaArrivalID = table.Column<int>(nullable: true),
                    departureviaDepartureID = table.Column<int>(nullable: true),
                    viaAirport = table.Column<string>(maxLength: 255, nullable: true),
                    ACRISFlightID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vias", x => x.viaID);
                    table.ForeignKey(
                        name: "FK_Vias_ACRISFlights_ACRISFlightID",
                        column: x => x.ACRISFlightID,
                        principalTable: "ACRISFlights",
                        principalColumn: "ACRISFlightID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vias_ViaArrivals_arrivalviaArrivalID",
                        column: x => x.arrivalviaArrivalID,
                        principalTable: "ViaArrivals",
                        principalColumn: "viaArrivalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vias_ViaDepartures_departureviaDepartureID",
                        column: x => x.departureviaDepartureID,
                        principalTable: "ViaDepartures",
                        principalColumn: "viaDepartureID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACRISFlights_aircrafTypeaircraftTypeID",
                table: "ACRISFlights",
                column: "aircrafTypeaircraftTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ACRISFlights_arrivalID",
                table: "ACRISFlights",
                column: "arrivalID");

            migrationBuilder.CreateIndex(
                name: "IX_ACRISFlights_departureID",
                table: "ACRISFlights",
                column: "departureID");

            migrationBuilder.CreateIndex(
                name: "IX_ACRISFlights_flightNumberID",
                table: "ACRISFlights",
                column: "flightNumberID");

            migrationBuilder.CreateIndex(
                name: "IX_ACRISFlights_operatingAirlineID",
                table: "ACRISFlights",
                column: "operatingAirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_Airlines_airlineContactId",
                table: "Airlines",
                column: "airlineContactId");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineWebsite_airlineID",
                table: "AirlineWebsite",
                column: "airlineID");

            migrationBuilder.CreateIndex(
                name: "IX_AirportInfoExternalLink_airportInfoId",
                table: "AirportInfoExternalLink",
                column: "airportInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_airportImageURLID",
                table: "Airports",
                column: "airportImageURLID");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_coordinateairportCoordinateID",
                table: "Airports",
                column: "coordinateairportCoordinateID");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_currentQueueTimesairportCurrentQueueTimesID",
                table: "Airports",
                column: "currentQueueTimesairportCurrentQueueTimesID");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_forecastQueueTimesairportForecastQueueTimesID",
                table: "Airports",
                column: "forecastQueueTimesairportForecastQueueTimesID");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_postalAddressairportPostalAddressID",
                table: "Airports",
                column: "postalAddressairportPostalAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_vasitorsAddressairportVisitorsAddressID",
                table: "Airports",
                column: "vasitorsAddressairportVisitorsAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_AirportWebsite_airportID",
                table: "AirportWebsite",
                column: "airportID");

            migrationBuilder.CreateIndex(
                name: "IX_Arrivals_baggaageClaimbaggageClaimID",
                table: "Arrivals",
                column: "baggaageClaimbaggageClaimID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardingTimes_departureID",
                table: "BoardingTimes",
                column: "departureID");

            migrationBuilder.CreateIndex(
                name: "IX_BookServices_serviceHeaderID",
                table: "BookServices",
                column: "serviceHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Departures_checkInInfoID",
                table: "Departures",
                column: "checkInInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightNumbers_ACRISFlightID",
                table: "FlightNumbers",
                column: "ACRISFlightID");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningHour_serviceLocationsID",
                table: "OpeningHour",
                column: "serviceLocationsID");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_contactproviderContactID",
                table: "Providers",
                column: "contactproviderContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_logoID",
                table: "Providers",
                column: "logoID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBulletpointElements_serviceBulletpointId",
                table: "ServiceBulletpointElements",
                column: "serviceBulletpointId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBulletpoints_serviceID",
                table: "ServiceBulletpoints",
                column: "serviceID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDonwloads_serviceID",
                table: "ServiceDonwloads",
                column: "serviceID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLocations_mapImageimageID",
                table: "ServiceLocations",
                column: "mapImageimageID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_desciptionImage_verticalimageID",
                table: "Services",
                column: "desciptionImage_verticalimageID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_descriptionImage_horizontalimageID",
                table: "Services",
                column: "descriptionImage_horizontalimageID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_iconimageID",
                table: "Services",
                column: "iconimageID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_providerID",
                table: "Services",
                column: "providerID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_titleImage_smallimageID",
                table: "Services",
                column: "titleImage_smallimageID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_titleImageimageID",
                table: "Services",
                column: "titleImageimageID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTableRow_serviceTableId",
                table: "ServiceTableRow",
                column: "serviceTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTables_serviceID",
                table: "ServiceTables",
                column: "serviceID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceText_serviceID",
                table: "ServiceText",
                column: "serviceID");

            migrationBuilder.CreateIndex(
                name: "IX_Specials_imageID",
                table: "Specials",
                column: "imageID");

            migrationBuilder.CreateIndex(
                name: "IX_Specials_serviceID",
                table: "Specials",
                column: "serviceID");

            migrationBuilder.CreateIndex(
                name: "IX_TripFlight_tripID",
                table: "TripFlight",
                column: "tripID");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_servicestripServicesID",
                table: "Trips",
                column: "servicestripServicesID");

            migrationBuilder.CreateIndex(
                name: "IX_ViaArrivals_baggaageClaimviaBaggageClaimID",
                table: "ViaArrivals",
                column: "baggaageClaimviaBaggageClaimID");

            migrationBuilder.CreateIndex(
                name: "IX_ViaDepartures_boardingTimeviaBoardingTimeID",
                table: "ViaDepartures",
                column: "boardingTimeviaBoardingTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_ViaDepartures_checkInInfoviaCheckInInfoID",
                table: "ViaDepartures",
                column: "checkInInfoviaCheckInInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Vias_ACRISFlightID",
                table: "Vias",
                column: "ACRISFlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Vias_arrivalviaArrivalID",
                table: "Vias",
                column: "arrivalviaArrivalID");

            migrationBuilder.CreateIndex(
                name: "IX_Vias_departureviaDepartureID",
                table: "Vias",
                column: "departureviaDepartureID");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightNumbers_ACRISFlights_ACRISFlightID",
                table: "FlightNumbers",
                column: "ACRISFlightID",
                principalTable: "ACRISFlights",
                principalColumn: "ACRISFlightID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACRISFlights_AircraftTypes_aircrafTypeaircraftTypeID",
                table: "ACRISFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_ACRISFlights_Arrivals_arrivalID",
                table: "ACRISFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_ACRISFlights_Departures_departureID",
                table: "ACRISFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_ACRISFlights_FlightNumbers_flightNumberID",
                table: "ACRISFlights");

            migrationBuilder.DropTable(
                name: "AirlineWebsite");

            migrationBuilder.DropTable(
                name: "AirportInfoExternalLink");

            migrationBuilder.DropTable(
                name: "AirportWebsite");

            migrationBuilder.DropTable(
                name: "BoardingTimes");

            migrationBuilder.DropTable(
                name: "BookServices");

            migrationBuilder.DropTable(
                name: "OpeningHour");

            migrationBuilder.DropTable(
                name: "ServiceBulletpointElements");

            migrationBuilder.DropTable(
                name: "ServiceDonwloads");

            migrationBuilder.DropTable(
                name: "ServiceTableRow");

            migrationBuilder.DropTable(
                name: "ServiceText");

            migrationBuilder.DropTable(
                name: "Specials");

            migrationBuilder.DropTable(
                name: "TripFlight");

            migrationBuilder.DropTable(
                name: "Vias");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "AirportInfos");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "ServiceHeaders");

            migrationBuilder.DropTable(
                name: "ServiceLocations");

            migrationBuilder.DropTable(
                name: "ServiceBulletpoints");

            migrationBuilder.DropTable(
                name: "ServiceTables");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "ViaArrivals");

            migrationBuilder.DropTable(
                name: "ViaDepartures");

            migrationBuilder.DropTable(
                name: "AirlineContacts");

            migrationBuilder.DropTable(
                name: "AirportImageURL");

            migrationBuilder.DropTable(
                name: "AirportCoordinates");

            migrationBuilder.DropTable(
                name: "AirportCurrentQueueTimes");

            migrationBuilder.DropTable(
                name: "AirportForecastQueueTimes");

            migrationBuilder.DropTable(
                name: "AirportPostalAddresses");

            migrationBuilder.DropTable(
                name: "AirportVisitorsAddresses");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "TripServices");

            migrationBuilder.DropTable(
                name: "ViaBaggageClaims");

            migrationBuilder.DropTable(
                name: "ViaBoardingTimes");

            migrationBuilder.DropTable(
                name: "ViaCheckInInfos");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "ProviderContacts");

            migrationBuilder.DropTable(
                name: "Logo");

            migrationBuilder.DropTable(
                name: "AircraftTypes");

            migrationBuilder.DropTable(
                name: "Arrivals");

            migrationBuilder.DropTable(
                name: "BaggageClaims");

            migrationBuilder.DropTable(
                name: "Departures");

            migrationBuilder.DropTable(
                name: "CheckInInfos");

            migrationBuilder.DropTable(
                name: "FlightNumbers");

            migrationBuilder.DropTable(
                name: "ACRISFlights");

            migrationBuilder.DropTable(
                name: "OperatingAirlines");
        }
    }
}
