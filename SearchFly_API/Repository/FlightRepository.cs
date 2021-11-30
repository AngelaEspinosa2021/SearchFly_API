using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using SearchFly_API.Data;
using SearchFly_API.Models;
using SearchFly_API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            List<Flight> finalList = new List<Flight>(); 
            List<DateTime> shedulesAvailable = new List<DateTime>();

            shedulesAvailable = createShedulesAvailableList(departureStation, arrivalStation, departureDate, listFlights);
                    
            foreach (var list in shedulesAvailable)
            {
                finalList.Add(new Flight {DepartureStation = departureStation, ArrivalStation = arrivalStation, DepartureDate = list});
            }

            return _mapper.Map<List<FlightDto>>(finalList);
        }

        private List<DateTime> createAllShedulesList(DateTime departureDate)
        {
            List<DateTime> allShedules = new List<DateTime>();
            List<DateTime> allShedulesList = new List<DateTime>();
            allShedules.Add(Convert.ToDateTime("2021-01-01T00:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T23:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T22:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T21:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T20:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T19:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T18:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T17:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T16:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T15:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T14:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T13:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T12:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T11:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T10:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T09:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T08:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T07:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T06:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T05:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T04:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T03:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T02:00:00.0000000"));
            allShedules.Add(Convert.ToDateTime("2021-01-01T01:00:00.0000000"));
                        
            TimeSpan times = new TimeSpan();
            foreach (var list in allShedules)
            {
                times = TimeSpan.FromHours(list.Hour);
                allShedulesList.Add(departureDate.Date + times);
            }
            return (allShedulesList);
        }

        private List<DateTime> createShedulesAvailableList(string departureStation, string arrivalStation, DateTime departureDate , List<Flight> listFlights)
        {
           
            List<DateTime> allShedulesList = new List<DateTime>();
            List<DateTime> filterList = new List<DateTime>();
            List<DateTime> shedulesAvailable = new List<DateTime>();

            allShedulesList = createAllShedulesList(departureDate);

            foreach (var flight in listFlights)
            {
                var List = from m in listFlights
                           where m.DepartureStation.ToLower() == departureStation.ToLower() && m.ArrivalStation.ToLower() == arrivalStation.ToLower()
                           select m;
                if (flight.DepartureDate.Date == departureDate.Date)
                {
                    filterList.Add(flight.DepartureDate);
                }

            }

            shedulesAvailable = (from a in allShedulesList
                                 where !filterList.Any(x => x.Hour == a.Hour)
                                 select a).ToList();

            return (shedulesAvailable);

        }

    }
}
