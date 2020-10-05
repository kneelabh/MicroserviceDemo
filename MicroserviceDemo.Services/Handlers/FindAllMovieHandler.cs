using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroserviceDemo.Data.Models;
using MicroserviceDemo.Data.Repository;
using MicroserviceDemo.Domain;
using MicroserviceDemo.Services.Query;

namespace MicroserviceDemo.Services.Handlers
{
    public class FindAllMovieHandler : IRequestHandler<FindAllMovieQuery, IEnumerable<MovieDto>>
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMapper _mapper;

        public FindAllMovieHandler(IRepository<Movie> movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
            _mapper = mapper  ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        public Task<IEnumerable<MovieDto>> Handle(FindAllMovieQuery request, CancellationToken cancellationToken)
        {
            //var result = await _movieRepository.FindAllMovie();
            var result = _movieRepository.FindAll();
            
            return Task.FromResult(_mapper.Map<IEnumerable<MovieDto>>(result));
        }
    }    
}