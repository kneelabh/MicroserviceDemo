using MicroserviceDemo.Data.DBContext;
using MicroserviceDemo.Data.Models;
using System;
using System.Linq;

namespace MicroserviceDemo.DataTests.Repository
{
    public class InitializeDB
    {
        public static void Initialize(MovieContext context)
        {
            if (context.Movies.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(MovieContext context)
        {
            var movies = new[]
            {
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
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();
        }
    }
}
