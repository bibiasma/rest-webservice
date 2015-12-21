using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightApplication.Models;
using System.Net.Http;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using System.Uri;

namespace FlightApplication.Models
{
    public class FlightsRepository : IFlightsRepository
    {
        private List<Flights> Flights = new List<Flights>();
        private int _nextId = 0;
        private int[] prices = { 400, 580, 710, 600, 440, 670, 630 };
        private int[] availableTickets = { 10, 16, 5, 17, 4, 6, 12, 9 };
        private int year = 2013;
        private int month = 10;
        private int day = 1;
        private int hour = 0;
        private int hourIncrease = 7;

        public FlightsRepository()
        {
            createFlights(200);
        }



        public Flights getCheapestFlight(int month)
        {
            IEnumerable<Flights> allFlights = GetAll();
            List<Flights> monthFlights = new List<Flights>();

            for (int i = 0; i < allFlights.Count(); i++)
            {
                if (allFlights.ElementAt<Flights>(i).dt.Month == month)
                    monthFlights.Add(allFlights.ElementAt<Flights>(i));
            }
            monthFlights.OrderBy((p) => p.Price);
            Flights flight = monthFlights[0];
            return flight;

        }
        //Creates flights to store in the repository
        private void createFlights(int nrOfFlights)
        {
            for (int i = 0; i < nrOfFlights; i++)
            {
                Add(new Flights
                {

                    flightName = "MAH" + i,
                    ticketAvailability = availableTickets[i % 8],
                    flightId = i + 1,
                    Price = prices[i % 7],
                    dt = new DateTime(year, month, day, hour, 30, 0),
                    bookingLink = new Uri("http://localhost:1477/api/Booking/" + i)
                    
                });
                createNewDate();
            }
        }

        public IEnumerable<Flights> GetAll()
        {
            return Flights.OrderBy((s)=>s.dt).ToList();
        }

        
        public Flights Get(int id)
        {
            return Flights.FirstOrDefault(p => p.flightId == id);
        }
        
        public Flights Add(Flights item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.flightId = _nextId++;
            Flights.Add(item);
            return item;
        }

        public void BookTicket(int flightId)
        {
            Get(flightId).ticketAvailability--;
        }

        public void BookTicketReturn(int flightId, int retFlightId)
        {
            Get(flightId).ticketAvailability--;
            Get(retFlightId).ticketAvailability--;
        }

        public void CancelTicket(int flightId)
        {
            Get(flightId).ticketAvailability++;
        }

        private void createNewDate()
        {
            if (month == 12 && day >= 28 && hour > 23 - hourIncrease)
                year++;
            if (hour >= 23 - hourIncrease)
            {
                hour = 0;
                if (day == 28)
                {
                    day = 1;
                    if (month == 12)
                        month = 1;
                    else
                        month++;
                }
                else
                    day++;
            }
            else
                hour = hour + hourIncrease;
        }
    }
}