using MicroserviceDemo.Data.Models;
using MicroserviceDemo.Domain;
using MicroserviceDemo.Services.Command;

namespace MicroserviceDemo.Profile
{
    public class MovieProfile : AutoMapper.Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDto,Movie>();
            CreateMap<Movie,MovieDto>();
            CreateMap<Movie,AddMoviesCommand>();
            CreateMap<AddMoviesCommand,Movie>();
        }
    }
}