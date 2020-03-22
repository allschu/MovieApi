using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieApi;
using Services.Movie;
using Services.Movie.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class MovieServiceTests
    {
        private readonly ServiceProvider serviceProvider;

        public MovieServiceTests()
        {
            var webhostEnvironmentMock = new Mock<IWebHostEnvironment>();
            webhostEnvironmentMock.Setup(x => x.EnvironmentName).Returns("Development");
            webhostEnvironmentMock.Setup(x => x.ContentRootPath).Returns(AppDomain.CurrentDomain.BaseDirectory);

            var configuration = new Startup(webhostEnvironmentMock.Object);

            var services = new ServiceCollection();
            services.AddScoped<IMediator, Mediator>();
            services.AddHttpClient<IMovieService, MovieService>();
            services.AddTransient(c => configuration);

            serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public async Task GetPopularMovieTest()
        {
            using var scope = serviceProvider.CreateScope();
            var movieService = scope.ServiceProvider.GetRequiredService<IMovieService>();

            Assert.IsNotNull(movieService, "IMovieService cannot be resolved by DI");

            var result = await movieService.GetPopularMovies();

            Assert.IsNotNull(result, "There is no result from the populair movie service request");
            Assert.IsNotNull(result.results, "There is no result from the populair movie service request");
            Assert.IsTrue(result.results.Any(), "There are no values in the collections");
        }


        
    }
}
