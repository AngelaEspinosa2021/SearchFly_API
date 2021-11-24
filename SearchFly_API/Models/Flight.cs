using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Transport")]

        public int TransportRefId { get; set; }
        public Transport Transport { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Currency { get; set; }
        
    }
}
