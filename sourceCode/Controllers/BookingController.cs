using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlightApplication.Models;
using System.Collections;
using System.Web;

namespace FlightApplication.Controllers
{
    public class BookingController : ApiController
    {
        static IFlightsRepository repository = new FlightsRepository();
        int flightID;
        String strURL;
        public BookingController() 
        {
            if (retrieveIdFromURL() != -1)
            {
                this.flightID = retrieveIdFromURL();
                repository.BookTicket(flightID);
            }
            else
            {
                flightID = 7; //Only an example of 
            }
            
        }

        //Retrieves the flight id from the booking link url
        public int retrieveIdFromURL()
        {
            this.strURL = HttpContext.Current.Request.Url.PathAndQuery;
            string lastCharacter = strURL.Split(new char[] { @"\"[0], "/"[0] }).Last();
            int id;
            bool isNum = int.TryParse(lastCharacter, out id);
            if (isNum)
            {
                return id;
            }
            else
            {
                return -1;
            }
        }

        public Flights GET()
        {
            return repository.Get(flightID);
        }         
    }
}