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

        List<FlightDto> IFlightRepository.SearchFlights(string departureStation, string arrivalStation, string departureDate)
        {
            List<Flight> lstFlights = new List<Flight>();
            if (!string.IsNullOrEmpty(departureStation) && !string.IsNullOrEmpty(arrivalStation) && !string.IsNullOrEmpty(departureDate))
            {
                DateTime _date = DateTime.Now;
                DateTime.TryParse(departureDate, out _date);
                var listFlights = _db.Flights
                    .Where(m => m.DepartureStation == departureStation && m.ArrivalStation == arrivalStation && m.DepartureDate == _date)
                    .Select(m => new FlightDto
                    {
                        Id = m.Id,
                        DepartureStation = m.DepartureStation,
                        ArrivalStation = m.ArrivalStation,
                        DepartureDate = (DateTime)m.DepartureDate,
                        Transport = m.Transport,
                        Price = (decimal)m.Price,
                        Currency = m.Currency,
                    });
                return listFlights.ToList();
            }
            return null;
        }
    }
}
