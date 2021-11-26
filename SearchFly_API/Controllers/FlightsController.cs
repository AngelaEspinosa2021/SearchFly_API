using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchFly_API.Data;
using SearchFly_API.Models;
using SearchFly_API.Models.Dto;
using SearchFly_API.Repository;

namespace SearchFly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;
        protected ResponseDto _response;

        public FlightsController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
            _response = new ResponseDto();
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
            return await _context.Flights.ToListAsync();
        }

        [HttpGet("{departureStation,arrivalStation,departureDate}")]
        public async Task<ActionResult<IEnumerable<FlightDto>>> SearchFlights(string departureStation, string arrivalStation, DateTime departureDate)
        {
           
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.Id == id);
        }
    }
}
