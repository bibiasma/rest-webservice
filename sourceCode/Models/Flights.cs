using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;


namespace FlightApplication.Models
{
    public class Flights
    {
        public int flightId { get; set; }
        public string flightName { get; set; }
        public int ticketAvailability { get; set; }
        public decimal Price { get; set; }
        public DateTime dt { get; set; }
        //public HyperLink bookingLink { get; set; }
        public Uri bookingLink { get; set; }
    }
}