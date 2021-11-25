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

        Task<FlightDto> GetFlightById(int id);

        Task<FlightDto> CreateUpdate(FlightDto flightDto);

        Task<bool> DeleteFlight(int id);
    }
}
