using System;
using System.ComponentModel.DataAnnotations;

namespace MicroserviceDemo.Data.Models
{
    public class Movie
    {
        [Key]
        public Guid MovieId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int IMDBRating { get; set; }

        public string Cast { get; set; }

        public DateTime Year { get; set; }

        public string Director { get; set; }

        public bool Favourite { get; set; }
    }
}