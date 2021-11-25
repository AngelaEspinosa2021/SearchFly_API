using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SearchFly_API.Data;
using SearchFly_API.Models;
using SearchFly_API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFly_API.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public FlightRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<FlightDto> CreateUpdate(FlightDto flightDto)
        {
            Flight flight = _mapper.Map<FlightDto, Flight>(flightDto);
            if (flight.Id > 0)
            {
                _db.Flights.Update(flight);
            }
            else
            {
                await _db.Flights.AddAsync(flight);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Flight, FlightDto>(flight);

        }

        public async Task<bool> DeleteFlight(int id)
        {
            try
            {
                Flight flight = await _db.Flights.FindAsync(id);
                if(flight == null)
                {
                    return false;
                }
                _db.Flights.Remove(flight);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<FlightDto> GetFlightById(int id)
        {
            Flight flight = await _db.Flights.FindAsync(id);

            return _mapper.Map<FlightDto>(flight);
        }

        public async Task<List<FlightDto>> GetFlights()
        {
            List<Flight> list = await _db.Flights.ToListAsync();

            return _mapper.Map<List<FlightDto>>(list);
        }
    }
}
