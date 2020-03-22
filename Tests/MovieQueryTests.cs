﻿using Application.Movie.Queries;
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

            var result = await mediator.Send(new GetPopularMoviesQuery(new GetPopularMoviesFilter())).ConfigureAwait(false);

            Assert.IsTrue(result.Any());
            Assert.AreEqual(20, result.Count());
        }
    }
}