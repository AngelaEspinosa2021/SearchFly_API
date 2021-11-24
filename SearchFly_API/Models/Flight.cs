using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFly_API.Models
{
    public class Flight
    {
        public int Id { get; set; }

        public string DepartureStation { get; set; }

        public string ArrivalStation { get; set; }

        public DateTime DepartureDate { get; set; }

        public Decimal Price { get; set; }

        public string Currency { get; set; }
    }
}
