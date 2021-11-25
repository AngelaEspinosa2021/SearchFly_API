using SearchFly_API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFly_API.Repository
{
    public class FlightRepository : IFlightRepository
    {
        public Task<FlightDto> CreateUpdate(FlightDto flightDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFlight(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FlightDto> GetFlightById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FlightDto>> GetFlights()
        {
            throw new NotImplementedException();
        }
    }
}
