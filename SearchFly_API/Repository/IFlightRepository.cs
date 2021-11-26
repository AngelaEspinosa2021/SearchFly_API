using SearchFly_API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFly_API.Repository
{
    public interface IFlightRepository
    {
        Task<List<FlightDto>> GetFlights();

        Task<List<FlightDto>> SearchFlights(string departureStation, string arrivalStation, DateTime departureDate);
    }
}
