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

        public async Task<List<FlightDto>> GetFlights()
        {
            List<Flight> list = await _db.Flights.ToListAsync();

            return _mapper.Map<List<FlightDto>>(list);
        }

        public async Task<List<FlightDto>> SearchFlights(string departureStation, string arrivalStation, DateTime departureDate)
        {
            List<Flight> listFlights = await _db.Flights.ToListAsync();
            var filterList = new List<Flight>();

            foreach (var flight in listFlights)
            {
                var List = from m in listFlights
                                 where m.DepartureStation == departureStation && m.ArrivalStation == arrivalStation && m.DepartureDate == departureDate
                                 select m;
                return _mapper.Map<List<FlightDto>>(List);
            }

            return null;

        }
    }
}
