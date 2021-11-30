﻿using AutoMapper;
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
            var shedulesAvailable = new List<DateTime>();
            var filterList = new List<DateTime>();
            var allShedules = new List<DateTime>();
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
            


            foreach (var flight in listFlights)
            {
                var List = from m in listFlights
                                 where m.DepartureStation == departureStation && m.ArrivalStation == arrivalStation
                                 select m;
                if(flight.DepartureDate.Date == departureDate.Date)
                {
                    filterList.Add(flight.DepartureDate);
                }                
                    //return _mapper.Map<List<FlightDto>>(List);
            }
            foreach (var list1 in filterList)
            {
                foreach (var list2 in allShedules)
                {
                    if (list2.Hour != list1.Hour)
                    {    
                        shedulesAvailable.Add(list2);                                     
                       
                    }
                    
                }
            }            
            return null;
        }
    }
}
