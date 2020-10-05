using System;
using MediatR;
namespace MicroserviceDemo.Services.Command
{
    public class AddMoviesCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int IMDBRating { get; set; }

        public string Cast { get; set; }

        public DateTime Year { get; set; }

        public string Director { get; set; }

        public bool Favourite { get; set; }
    }
}
