using Application.Movie.Queries;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieApi;
using Services.Movie;
using Services.Movie.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class MovieQueryTests
    {
        private readonly ServiceProvider serviceProvider;

        public MovieQueryTests()
        {
            var webhostEnvironmentMock = new Mock<IWebHostEnvironment>();
            webhostEnvironmentMock.Setup(x => x.EnvironmentName).Returns("Development");
            webhostEnvironmentMock.Setup(x => x.ContentRootPath).Returns(AppDomain.CurrentDomain.BaseDirectory);

            var configuration = new Startup(webhostEnvironmentMock.Object);

            var services = new ServiceCollection();
            services.AddScoped<IMediator, Mediator>();
            services.AddHttpClient<IMovieService, MovieService>();
            services.AddTransient(c => configuration);

            services.AddMediatR(typeof(GetPopularMoviesQuery).GetTypeInfo().Assembly);

            serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public async Task GetPopularMovieQueryTest()
        {
            using var scope = serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            Assert.IsNotNull(mediator, "mediator cannot be resolved by DI");

            var result = await mediator.Send(new GetPopularMoviesQuery(new GetPopularMoviesFilter(2))).ConfigureAwait(false);

            Assert.IsTrue(result.Results.Any());
            Assert.AreNotSame(0, result.Total_Results);
            Assert.AreEqual(20, result.Results.Count());
        }

        [TestMethod]
        public async Task GetMovieByIdQueryTest()
        {
            using var scope = serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            Assert.IsNotNull(mediator, "mediator cannot be resolved by DI");

            var result = await mediator.Send(new GetMovieByIdQuery(338762)).ConfigureAwait(false);

            Assert.IsNotNull(result, "there is no result for getmovie by ID");
            Assert.AreNotEqual(string.Empty, result.title, "the test faulted because there is not string value in the title field");
        }

        [TestMethod]
        public async Task GetMovieRecommendationsQueryTest()
        {
            using var scope = serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            Assert.IsNotNull(mediator, "mediator cannot be resolved by DI");

            var result = await mediator.Send(new GetMovieRecommendationsQuery(338762)).ConfigureAwait(false);

            Assert.IsNotNull(result, "there is no result for get movie recommendations by ID");
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetMovieSearchQueryTest()
        {
            using var scope = serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            Assert.IsNotNull(mediator, "mediator cannot be resolved by DI");

            var result = await mediator.Send(new GetMovieSearchQuery(new GetMovieSearchFilter("sonic", 1))).ConfigureAwait(false);

            Assert.IsNotNull(result, "there is no result for movie search");
            Assert.IsTrue(result.Results.Any());
        }
    }
}
