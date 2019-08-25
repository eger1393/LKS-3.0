using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Airport
	{
		[Key]
		public int airportID { get; set; }

		// TODO подумать надо ли разбивать на 2 таблицы
		public AirportImageURL airportImageURL { get; set; }
		public string airportName { get; set; }
		public string cityName { get; set; }
		
		public AirportCoordinate coordinate { get; set; }
		public AirportCountry country { get; set; }
		
		public AirportCurrentQueueTimes currentQueueTimes { get; set; }
		public AirportForecastQueueTimes forecastQueueTimes { get; set; }

		public double? geofenceRadius { get; set; }
		public string iataCode { get; set; }
		[Required]
		public string icaoCode { get; set; }
		
		public AirportPostalAddress postalAddress { get; set; }
		public string bmezone { get; set; }
		
		public AirportVisitorsAddress vasitorsAddress { get; set; }


	}
}
