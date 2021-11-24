using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFly_API.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DepartureStation { get; set; }

        [Required]
        public string ArrivalStation { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public List<Transport> Transport { get; set; }
    }
}
