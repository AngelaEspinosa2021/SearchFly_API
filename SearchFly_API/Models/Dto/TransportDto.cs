using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFly_API.Models.Dto
{
    public class TransportDto
    {
        public int Id { get; set; }

        public string FlightNumber { get; set; }

        public ICollection<Flight> Flight { get; set; }
    }
}
