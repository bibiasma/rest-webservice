using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlightApplication.Models;
using System.Collections;

namespace FlightApplication.Controllers
{
    public class cheapestFlightController : ApiController
    {
        static readonly IFlightsRepository repository = new FlightsRepository();
        public Flights GET()
        {
            return repository.getCheapestFlight(10);
        }  
    }
}