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
            try
            {
                var list = await _flightRepository.GetFlights();
                _response.Result = list;
                _response.DisplayMessage = "Lista de Vuelos Reservados";
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        [HttpGet("{departureStation}/{arrivalStation}/{departureDate}")]

        public async Task<ActionResult<IEnumerable<Flight>>> SearchFlights(string departureStation, string arrivalStation, DateTime departureDate)
        {
            var reservedTimes = await _flightRepository.SearchFlights(departureStation, arrivalStation, departureDate);
            if (reservedTimes == null)
            {
                _response.IsSucess = false;
                _response.DisplayMessage = "No hay vuelos reservados.";
                return NotFound(_response);
            }
            _response.Result = reservedTimes;
            _response.DisplayMessage = "Listado de Vuelos ya reservados para ese dia.";
            return Ok(reservedTimes);
        }        
    }
}
