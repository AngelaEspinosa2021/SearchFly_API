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
        private ResponseDto _response;

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
                _response.DisplayMessage = "Listado de Vuelos Ya Reservados";
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            var flight = await _flightRepository.GetFlightById(id);
            if (flight == null)
            {
                _response.IsSucess = false;
                _response.DisplayMessage = "Vuelo No Reservado";
                return NotFound(_response);
            }
            _response.Result = flight;
            _response.DisplayMessage = "Información del Vuelo Ya Reservado";
            return Ok(flight);
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, FlightDto flightDto)
        {
            try
            {
                FlightDto model = await _flightRepository.CreateUpdate(flightDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.DisplayMessage = "Error al Actualizar el Registro.";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }

            return NoContent();
        }

        // POST: api/Flights
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(FlightDto flightDto)
        {
            try
            {
                FlightDto model = await _flightRepository.CreateUpdate(flightDto);
                _response.Result = model;
                return CreatedAtAction("GetFlight", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.DisplayMessage = "Error al Grabar el Registro";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flight>> DeleteFlight(int id)
        {
            try
            {
                bool isEliminated = await _flightRepository.DeleteFlight(id);
                if (isEliminated)
                {
                    _response.Result = isEliminated;
                    _response.DisplayMessage = "Vuelo Eliminado con Exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSucess = false;
                    _response.DisplayMessage = " Error al Eliminar Vuelo";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
