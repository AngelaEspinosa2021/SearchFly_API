using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFly_API.Models.Dto
{
    public class FlightDto
    {
        public int Id { get; set; }
        
        public string DepartureStation { get; set; }
        
        public string ArrivalStation { get; set; }
        
        public DateTime DepartureDate { get; set; }

        public int TransportRefId { get; set; }

        public Transport Transport { get; set; }   
        
        public decimal Price { get; set; }    
        
        public string Currency { get; set; }

    }
}
