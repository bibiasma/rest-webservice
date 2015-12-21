using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlightApplication.Models;
using System.Collections;
using System.Web;
//using System.Convert;


namespace FlightApplication.Controllers
{
    public class TicketController : ApiController
    {
        static IFlightsRepository repository = new FlightsRepository();
        int flightID;
        int flightIDRet;
        public TicketController() 
        {
            flightID = 7;//Only an example of certain flight
            
            /* Below code is used on demand */
            
            //flightIDRet = 10;
            //BookTicketReturn(flightID, flightIDRet);
            //CancelTicket(flightID);
        }

        public Flights GET()
        {
            return repository.Get(flightID);
        }         
    }
}