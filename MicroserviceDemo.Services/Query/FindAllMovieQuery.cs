using System.Collections.Generic;
using MediatR;
using MicroserviceDemo.Domain;

namespace MicroserviceDemo.Services.Query
{
    public class FindAllMovieQuery : IRequest<IEnumerable<MovieDto>>
    {

    }
}
