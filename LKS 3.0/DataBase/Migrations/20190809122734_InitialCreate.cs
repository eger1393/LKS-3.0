using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftTypes",
                columns: table => new
                {
                    aircraftTypeID = table.Column<string>(nullable: false),
                    icaoCode = table.Column<string>(nullable: true),
                    modelName = table.Column<string>(nullable: true),
                    registration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTypes", x => x.aircraftTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AirlineContacts",
                columns: table => new
                {
                    airlineContact = table.Column<string>(nullable: false),
                    country_name = table.Column<string>(nullable: true),
                    country_tag = table.Column<string>(nullable: true),
                    extended_address = table.Column<string>(nullable: true),
                    locality = table.Column<string>(nullable: true),
                    post_office_box = table.Column<string>(nullable: true),
                    postal_code = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    street_address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineContacts", x => x.airlineContact);
                });

            migrationBuilder.CreateTable(
                name: "AirportCoordinates",
                columns: table => new
                {
                    airportCoordinateID = table.Column<string>(nullable: false),
                    elevation = table.Column<int>(nullable: false),
                    latitude = table.Column<double>(nullable: false),
                    lonqitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportCoordinates", x => x.airportCoordinateID);
                });

            migrationBuilder.CreateTable(
                name: "AirportCountries",
                columns: table => new
                {
                    airportCountryID = table.Column<string>(nullable: false),
                    countryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportCountries", x => x.airportCountryID);
                });

            migrationBuilder.CreateTable(
                name: "AirportCurrentQueueTimes",
                columns: table => new
                {
                    airportCurrentQueueTimesID = table.Column<string>(nullable: false),
                    currentProjectedMaxWaitTime = table.Column<int>(nullable: false),
                    currentProjectedMinWaitTime = table.Column<int>(nullable: false),
                    currentProjectedWaitTime = table.Column<int>(nullable: false),
                    currentQueueName = table.Column<string>(nullable: true),
                    currentTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportCurrentQueueTimes", x => x.airportCurrentQueueTimesID);
                });

            migrationBuilder.CreateTable(
                name: "AirportForecastQueueTimes",
                columns: table => new
                {
                    airportForecastQueueTimesID = table.Column<string>(nullable: false),
                    forecastConfidence = table.Column<int>(nullable: false),
                    forecastProjectedWaitTime = table.Column<int>(nullable: false),
                    currentQueueName = table.Column<string>(nullable: true),
                    currentTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportForecastQueueTimes", x => x.airportForecastQueueTimesID);
                });

            migrationBuilder.CreateTable(
                name: "AirportImageURL",
                columns: table => new
                {
                    airportImageURLID = table.Column<string>(nullable: false),
                    high = table.Column<string>(nullable: true),
                    low = table.Column<string>(nullable: true),
                    medium = table.Column<string>(nullable: true),
                    native = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportImageURL", x => x.airportImageURLID);
                });

            migrationBuilder.CreateTable(
                name: "AirportPostalAddresses",
                columns: table => new
                {
                    airportPostalAddressID = table.Column<string>(nullable: false),
                    country_name = table.Column<string>(nullable: true),
                    country_tag = table.Column<string>(nullable: true),
                    extended_address = table.Column<string>(nullable: true),
                    locality = table.Column<string>(nullable: true),
                    post_office_box = table.Column<string>(nullable: true),
                    postal_code = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    street_address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportPostalAddresses", x => x.airportPostalAddressID);
                });

            migrationBuilder.CreateTable(
                name: "AirportVisitorsAddresses",
                columns: table => new
                {
                    airportVisitorsAddressID = table.Column<string>(nullable: false),
                    country_name = table.Column<string>(nullable: true),
                    country_tag = table.Column<string>(nullable: true),
                    extended_address = table.Column<string>(nullable: true),
                    locality = table.Column<string>(nullable: true),
                    post_office_box = table.Column<string>(nullable: true),
                    postal_code = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    street_address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportVisitorsAddresses", x => x.airportVisitorsAddressID);
                });

            migrationBuilder.CreateTable(
                name: "BaggageClaims",
                columns: table => new
                {
                    baggageClaimID = table.Column<string>(nullable: false),
                    carousel = table.Column<string>(nullable: true),
                    expectedTimeOnCarousel = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaggageClaims", x => x.baggageClaimID);
                });

            migrationBuilder.CreateTable(
                name: "BoardingTimes",
                columns: table => new
                {
                    boardingTimeID = table.Column<string>(nullable: false),
                    bookingClass = table.Column<string>(nullable: true),
                    time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardingTimes", x => x.boardingTimeID);
                });

            migrationBuilder.CreateTable(
                name: "CheckInInfos",
                columns: table => new
                {
                    checkInInfoID = table.Column<string>(nullable: false),
                    additionalInfo = table.Column<string>(nullable: true),
                    checkInBeginTime = table.Column<DateTime>(nullable: false),
                    checkInEndTime = table.Column<DateTime>(nullable: false),
                    checkInLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInInfos", x => x.checkInInfoID);
                });

            migrationBuilder.CreateTable(
                name: "CodeShares",
                columns: table => new
                {
                    codeSharesID = table.Column<string>(nullable: false),
                    airlineCode = table.Column<string>(nullable: true),
                    suffix = table.Column<string>(nullable: true),
                    trackNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeShares", x => x.codeSharesID);
                });

            migrationBuilder.CreateTable(
                name: "FlightNumbers",
                columns: table => new
                {
                    flightNumberID = table.Column<string>(nullable: false),
                    airlineCode = table.Column<string>(nullable: true),
                    suffix = table.Column<string>(nullable: true),
                    trackNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightNumbers", x => x.flightNumberID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    imageID = table.Column<string>(nullable: false),
                    high = table.Column<string>(nullable: true),
                    low = table.Column<string>(nullable: true),
                    medium = table.Column<string>(nullable: true),
                    native = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.imageID);
                });

            migrationBuilder.CreateTable(
                name: "Logo",
                columns: table => new
                {
                    logoID = table.Column<string>(nullable: false),
                    logo_high = table.Column<string>(nullable: true),
                    logo_low = table.Column<string>(nullable: true),
                    logo_medium = table.Column<string>(nullable: true),
                    logo_native = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logo", x => x.logoID);
                });

            migrationBuilder.CreateTable(
                name: "OperatingAirlines",
                columns: table => new
                {
                    operatingAirlineID = table.Column<string>(nullable: false),
                    iataCode = table.Column<string>(nullable: true),
                    icaoCode = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingAirlines", x => x.operatingAirlineID);
                });

            migrationBuilder.CreateTable(
                name: "ProviderContacts",
                columns: table => new
                {
                    providerContactID = table.Column<string>(nullable: false),
                    country_name = table.Column<string>(nullable: true),
                    country_tag = table.Column<string>(nullable: true),
                    extended_address = table.Column<string>(nullable: true),
                    locality = table.Column<string>(nullable: true),
                    post_office_box = table.Column<string>(nullable: true),
                    postal_code = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    street_address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderContacts", x => x.providerContactID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceElements",
                columns: table => new
                {
                    serviceElementsID = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceElements", x => x.serviceElementsID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceHeaders",
                columns: table => new
                {
                    serviceHeaderID = table.Column<string>(nullable: false),
                    bookingID = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    extBookingID = table.Column<string>(nullable: true),
                    serviceID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHeaders", x => x.serviceHeaderID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItems",
                columns: table => new
                {
                    serviceItemID = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    isBookable = table.Column<bool>(nullable: false),
                    shortDescription = table.Column<string>(nullable: true),
                    subTitle = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItems", x => x.serviceItemID);
                });

            migrationBuilder.CreateTable(
                name: "TripServices",
                columns: table => new
                {
                    tripServicesID = table.Column<string>(nullable: false),
                    bookingID = table.Column<string>(nullable: true),
                    serviceID = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripServices", x => x.tripServicesID);
                });

            migrationBuilder.CreateTable(
                name: "ViaBaggageClaims",
                columns: table => new
                {
                    viaBaggageClaimID = table.Column<string>(nullable: false),
                    carousel = table.Column<string>(nullable: true),
                    expectedTimeOnCarousel = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaBaggageClaims", x => x.viaBaggageClaimID);
                });

            migrationBuilder.CreateTable(
                name: "ViaBoardingTimes",
                columns: table => new
                {
                    viaBoardingTimeID = table.Column<string>(nullable: false),
                    bookingClass = table.Column<string>(nullable: true),
                    time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaBoardingTimes", x => x.viaBoardingTimeID);
                });

            migrationBuilder.CreateTable(
                name: "ViaCheckInInfos",
                columns: table => new
                {
                    viaCheckInInfoID = table.Column<string>(nullable: false),
                    additionalInfo = table.Column<string>(nullable: true),
                    checkInBeginTime = table.Column<DateTime>(nullable: false),
                    checkInEndTime = table.Column<DateTime>(nullable: false),
                    checkInLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaCheckInInfos", x => x.viaCheckInInfoID);
                });

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    airlineID = table.Column<string>(nullable: false),
                    airlineName = table.Column<string>(nullable: true),
                    checkIn = table.Column<string>(nullable: true),
                    checkInTime = table.Column<string>(nullable: true),
                    airlineContact1 = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    faxNumber = table.Column<string>(nullable: true),
                    flightNumberCode = table.Column<string>(nullable: true),
                    handlingAgent = table.Column<string>(nullable: true),
                    iataCode = table.Column<string>(nullable: true),
                    icaoCode = table.Column<string>(nullable: true),
                    info = table.Column<string>(nullable: true),
                    lateNightArea = table.Column<string>(nullable: true),
                    lateNightTimes = table.Column<string>(nullable: true),
                    onlineCheckInURL = table.Column<string>(nullable: true),
                    serviceTime = table.Column<string>(nullable: true),
                    telephoneNumber = table.Column<string>(nullable: true),
                    terminal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.airlineID);
                    table.ForeignKey(
                        name: "FK_Airlines_AirlineContacts_airlineContact1",
                        column: x => x.airlineContact1,
                        principalTable: "AirlineContacts",
                        principalColumn: "airlineContact",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    airportID = table.Column<string>(nullable: false),
                    airportImageURLID = table.Column<string>(nullable: true),
                    airportName = table.Column<string>(nullable: true),
                    cityName = table.Column<string>(nullable: true),
                    coordinateairportCoordinateID = table.Column<string>(nullable: true),
                    countryairportCountryID = table.Column<string>(nullable: true),
                    currentQueueTimesairportCurrentQueueTimesID = table.Column<string>(nullable: true),
                    forecastQueueTimesairportForecastQueueTimesID = table.Column<string>(nullable: true),
                    geofenceRadius = table.Column<double>(nullable: false),
                    iataCode = table.Column<string>(nullable: true),
                    icaoCode = table.Column<string>(nullable: true),
                    postalAddressairportPostalAddressID = table.Column<string>(nullable: true),
                    bmezone = table.Column<string>(nullable: true),
                    vasitorsAddressairportVisitorsAddressID = table.Column<string>(nullable: true)
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
                        name: "FK_Airports_AirportCountries_countryairportCountryID",
                        column: x => x.countryairportCountryID,
                        principalTable: "AirportCountries",
                        principalColumn: "airportCountryID",
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
                    arrivalID = table.Column<string>(nullable: false),
                    actual = table.Column<DateTime>(nullable: false),
                    baggaageClaimbaggageClaimID = table.Column<string>(nullable: true),
                    estimated = table.Column<DateTime>(nullable: false),
                    gate = table.Column<string>(nullable: true),
                    scheduled = table.Column<DateTime>(nullable: false),
                    termnal = table.Column<string>(nullable: true),
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
                    departureID = table.Column<string>(nullable: false),
                    actual = table.Column<DateTime>(nullable: false),
                    boardingTimeID = table.Column<string>(nullable: true),
                    checkInInfoID = table.Column<string>(nullable: true),
                    estimated = table.Column<DateTime>(nullable: false),
                    gate = table.Column<string>(nullable: true),
                    scheduled = table.Column<DateTime>(nullable: false),
                    terminal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departures", x => x.departureID);
                    table.ForeignKey(
                        name: "FK_Departures_BoardingTimes_boardingTimeID",
                        column: x => x.boardingTimeID,
                        principalTable: "BoardingTimes",
                        principalColumn: "boardingTimeID",
                        onDelete: ReferentialAction.Restrict);
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
                    serviceLocationsID = table.Column<string>(nullable: false),
                    area = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    humanReadable = table.Column<string>(nullable: true),
                    mapImageimageID = table.Column<string>(nullable: true),
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
                name: "Specials",
                columns: table => new
                {
                    specialsID = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    numberOfAvailable = table.Column<int>(nullable: false),
                    imageID = table.Column<string>(nullable: true),
                    begin = table.Column<DateTime>(nullable: false),
                    end = table.Column<DateTime>(nullable: false),
                    coupon = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    providerID = table.Column<string>(nullable: false),
                    contactproviderContactID = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    fax = table.Column<string>(nullable: true),
                    logoID = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true)
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
                    bookServiceID = table.Column<string>(nullable: false),
                    serviceHeaderID = table.Column<string>(nullable: true)
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
                    tripID = table.Column<string>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false),
                    flights = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true),
                    servicestripServicesID = table.Column<string>(nullable: true),
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
                    viaArrivalID = table.Column<string>(nullable: false),
                    actual = table.Column<DateTime>(nullable: false),
                    baggaageClaimviaBaggageClaimID = table.Column<string>(nullable: true),
                    estimated = table.Column<DateTime>(nullable: false),
                    gate = table.Column<string>(nullable: true),
                    scheduled = table.Column<DateTime>(nullable: false),
                    termnal = table.Column<string>(nullable: true),
                    transferInformation = table.Column<string>(nullable: true)
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
                    viaDepartureID = table.Column<string>(nullable: false),
                    actual = table.Column<DateTime>(nullable: false),
                    boardingTimeviaBoardingTimeID = table.Column<string>(nullable: true),
                    checkInInfoviaCheckInInfoID = table.Column<string>(nullable: true),
                    estimated = table.Column<DateTime>(nullable: false),
                    gate = table.Column<string>(nullable: true),
                    scheduled = table.Column<DateTime>(nullable: false),
                    terminal = table.Column<string>(nullable: true)
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
                name: "OpeningHour",
                columns: table => new
                {
                    openingHourID = table.Column<string>(nullable: false),
                    column1 = table.Column<string>(nullable: true),
                    column2 = table.Column<string>(nullable: true),
                    serviceLocationsID = table.Column<string>(nullable: true)
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
                    serviceID = table.Column<string>(nullable: false),
                    serviceProviderproviderID = table.Column<string>(nullable: true),
                    specialsID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.serviceID);
                    table.ForeignKey(
                        name: "FK_Services_Providers_serviceProviderproviderID",
                        column: x => x.serviceProviderproviderID,
                        principalTable: "Providers",
                        principalColumn: "providerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Specials_specialsID",
                        column: x => x.specialsID,
                        principalTable: "Specials",
                        principalColumn: "specialsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vias",
                columns: table => new
                {
                    viaID = table.Column<string>(nullable: false),
                    arrivalviaArrivalID = table.Column<string>(nullable: true),
                    departureviaDepartureID = table.Column<string>(nullable: true),
                    viaAirport = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vias", x => x.viaID);
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

            migrationBuilder.CreateTable(
                name: "ServiceDonwloads",
                columns: table => new
                {
                    serviceDonwloadID = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true),
                    serviceID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDonwloads", x => x.serviceDonwloadID);
                    table.ForeignKey(
                        name: "FK_ServiceDonwloads_Services_serviceID",
                        column: x => x.serviceID,
                        principalTable: "Services",
                        principalColumn: "serviceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACRISFlights",
                columns: table => new
                {
                    ACRISFlightID = table.Column<string>(nullable: false),
                    aircrafTypeaircraftTypeID = table.Column<string>(nullable: true),
                    arrivalID = table.Column<string>(nullable: true),
                    arrivalAirport = table.Column<string>(nullable: true),
                    codeSharesID = table.Column<string>(nullable: true),
                    departureID = table.Column<string>(nullable: true),
                    departureAirport = table.Column<string>(nullable: true),
                    flightNumberID = table.Column<string>(nullable: true),
                    flightStatus = table.Column<string>(nullable: true),
                    operatingAirlineID = table.Column<string>(nullable: true),
                    originDate = table.Column<DateTime>(nullable: false),
                    viaID = table.Column<string>(nullable: true)
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
                        name: "FK_ACRISFlights_CodeShares_codeSharesID",
                        column: x => x.codeSharesID,
                        principalTable: "CodeShares",
                        principalColumn: "codeSharesID",
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACRISFlights_OperatingAirlines_operatingAirlineID",
                        column: x => x.operatingAirlineID,
                        principalTable: "OperatingAirlines",
                        principalColumn: "operatingAirlineID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACRISFlights_Vias_viaID",
                        column: x => x.viaID,
                        principalTable: "Vias",
                        principalColumn: "viaID",
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
                name: "IX_ACRISFlights_codeSharesID",
                table: "ACRISFlights",
                column: "codeSharesID");

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
                name: "IX_ACRISFlights_viaID",
                table: "ACRISFlights",
                column: "viaID");

            migrationBuilder.CreateIndex(
                name: "IX_Airlines_airlineContact1",
                table: "Airlines",
                column: "airlineContact1");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_airportImageURLID",
                table: "Airports",
                column: "airportImageURLID");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_coordinateairportCoordinateID",
                table: "Airports",
                column: "coordinateairportCoordinateID");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_countryairportCountryID",
                table: "Airports",
                column: "countryairportCountryID");

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
                name: "IX_Arrivals_baggaageClaimbaggageClaimID",
                table: "Arrivals",
                column: "baggaageClaimbaggageClaimID");

            migrationBuilder.CreateIndex(
                name: "IX_BookServices_serviceHeaderID",
                table: "BookServices",
                column: "serviceHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Departures_boardingTimeID",
                table: "Departures",
                column: "boardingTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Departures_checkInInfoID",
                table: "Departures",
                column: "checkInInfoID");

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
                name: "IX_ServiceDonwloads_serviceID",
                table: "ServiceDonwloads",
                column: "serviceID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLocations_mapImageimageID",
                table: "ServiceLocations",
                column: "mapImageimageID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_serviceProviderproviderID",
                table: "Services",
                column: "serviceProviderproviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_specialsID",
                table: "Services",
                column: "specialsID");

            migrationBuilder.CreateIndex(
                name: "IX_Specials_imageID",
                table: "Specials",
                column: "imageID");

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
                name: "IX_Vias_arrivalviaArrivalID",
                table: "Vias",
                column: "arrivalviaArrivalID");

            migrationBuilder.CreateIndex(
                name: "IX_Vias_departureviaDepartureID",
                table: "Vias",
                column: "departureviaDepartureID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACRISFlights");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "BookServices");

            migrationBuilder.DropTable(
                name: "OpeningHour");

            migrationBuilder.DropTable(
                name: "ServiceDonwloads");

            migrationBuilder.DropTable(
                name: "ServiceElements");

            migrationBuilder.DropTable(
                name: "ServiceItems");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "AircraftTypes");

            migrationBuilder.DropTable(
                name: "Arrivals");

            migrationBuilder.DropTable(
                name: "CodeShares");

            migrationBuilder.DropTable(
                name: "Departures");

            migrationBuilder.DropTable(
                name: "FlightNumbers");

            migrationBuilder.DropTable(
                name: "OperatingAirlines");

            migrationBuilder.DropTable(
                name: "Vias");

            migrationBuilder.DropTable(
                name: "AirlineContacts");

            migrationBuilder.DropTable(
                name: "AirportImageURL");

            migrationBuilder.DropTable(
                name: "AirportCoordinates");

            migrationBuilder.DropTable(
                name: "AirportCountries");

            migrationBuilder.DropTable(
                name: "AirportCurrentQueueTimes");

            migrationBuilder.DropTable(
                name: "AirportForecastQueueTimes");

            migrationBuilder.DropTable(
                name: "AirportPostalAddresses");

            migrationBuilder.DropTable(
                name: "AirportVisitorsAddresses");

            migrationBuilder.DropTable(
                name: "ServiceHeaders");

            migrationBuilder.DropTable(
                name: "ServiceLocations");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "TripServices");

            migrationBuilder.DropTable(
                name: "BaggageClaims");

            migrationBuilder.DropTable(
                name: "BoardingTimes");

            migrationBuilder.DropTable(
                name: "CheckInInfos");

            migrationBuilder.DropTable(
                name: "ViaArrivals");

            migrationBuilder.DropTable(
                name: "ViaDepartures");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Specials");

            migrationBuilder.DropTable(
                name: "ViaBaggageClaims");

            migrationBuilder.DropTable(
                name: "ViaBoardingTimes");

            migrationBuilder.DropTable(
                name: "ViaCheckInInfos");

            migrationBuilder.DropTable(
                name: "ProviderContacts");

            migrationBuilder.DropTable(
                name: "Logo");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
