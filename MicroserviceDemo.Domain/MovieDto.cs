using System;

namespace MicroserviceDemo.Domain
{
    public class MovieDto
    {
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
