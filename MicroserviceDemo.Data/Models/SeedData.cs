using System;
using MicroserviceDemo.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceDemo.Data.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MovieContext>>()))
            {
                // Look for any movies.
                if (context.Movies.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        Name = "When Harry Met Sally",
                        Year = DateTime.Parse("1989-2-12"),
                        Description = "Romantic Comedy",
                        Cast = "",
                        Director = "",
                        IMDBRating = 7
                    },

                    new Movie
                    {
                        Name = "Ghostbusters ",
                        Year = DateTime.Parse("1984-3-13"),
                        Description = "Comedy",
                        Cast = "",
                        Director = "",
                        IMDBRating = 7
                    },

                    new Movie
                    {
                        Name = "Ghostbusters 2",
                        Year = DateTime.Parse("1986-2-23"),
                        Description = "Comedy",
                        Cast = "",
                        Director = "",
                        IMDBRating = 6
                    },

                    new Movie
                    {
                        Name = "Rio Bravo",
                        Year = DateTime.Parse("1959-4-15"),
                        Description = "Western",
                        Cast = "",
                        Director = "",
                        IMDBRating = 3
                    }
                );
                context.SaveChanges();
            }
        }
    }
}