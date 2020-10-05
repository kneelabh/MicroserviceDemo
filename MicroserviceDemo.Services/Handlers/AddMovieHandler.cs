using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroserviceDemo.Data.Models;
using MicroserviceDemo.Data.Repository;
using MicroserviceDemo.Services.Command;

namespace MicroserviceDemo.Services.Handlers
{
    public class AddMovieHandler : IRequestHandler<AddMoviesCommand, bool>
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMapper _mapper;

        public AddMovieHandler(IRepository<Movie> movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddMoviesCommand request, CancellationToken cancellationToken)
        {
            //TODO
            //_catalogRepository.ValidateAddCatalogCommand(request);


            var movie = _mapper.Map<Movie>(request);
            return await _movieRepository.AddAsync(movie);
        }
    }
}
