using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MicroserviceDemo.Data.Models;
using MicroserviceDemo.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using MicroserviceDemo.DataTests.Repository;
using System.Linq;

namespace MicroserviceDemo.Data.Repository.Tests
{
    [TestClass()]
    public class RepositoryTests : IDisposable
    {
        private readonly Repository<Movie> _repository;
        private readonly Movie _newMovie;
        private readonly MovieContext _movieContext;

        public RepositoryTests()
        {
            _newMovie = new Movie
            {
                Cast = "Mock",
                Description = "Mock",
                Director = "Mocking Director",
                Favourite = true,
                IMDBRating = 1,
                MovieId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Mock Movie",
                Year = DateTime.Now
            };

            var options = new DbContextOptionsBuilder<MovieContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _movieContext = new MovieContext(options);

            _movieContext.Database.EnsureCreated();

            InitializeDB.Initialize(_movieContext);

            _repository = new Repository<Movie>(_movieContext);

        }

        [TestMethod()]
        public void AddAsyncTest()
        {
            bool result = _repository.AddAsync(_newMovie).GetAwaiter().GetResult();
            Assert.AreEqual(true, result);
        }

        

        [TestMethod()]
        public void FindAllTest()
        {
            var result = _repository.FindAll();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod()]
        public void UpdateAsyncTest()
        {
            var allMovie = _repository.FindAll();
            var firstMovie = allMovie.FirstOrDefault();
            firstMovie.Name = "Changed!";
            var wait = _repository.UpdateAsync(firstMovie).GetAwaiter();
            var result = wait.GetResult();
            Assert.IsNotNull(result);
            Assert.AreEqual("Changed!", result.Name);
        }

        public void Dispose()
        {
            _movieContext.Database.EnsureDeleted();
            _movieContext.Dispose();
        }
    }
}