using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightApplication.Models;
using System.Web.UI.WebControls;


namespace FlightApplication.Models.Flights
{
    interface IFlightsRepository
    {
        Flights getCheapestFlight(int month);
        IEnumerable<Flights> GetAll();
        Flights Get(int id);
        Flights Add(Flights item);
        void BookTicket(int flightId);
        void BookTicketReturn(int flightId, int retFlightId);
        void CancelTicket(int id);
    }
}