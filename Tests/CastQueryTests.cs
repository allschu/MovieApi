using Application.Cast.Queries;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieApi;
using Services.Cast;
using Services.Cast.Interfaces;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class CastQueryTests
    {
        private readonly ServiceProvider serviceProvider;

        public CastQueryTests()
        {
            var webhostEnvironmentMock = new Mock<IWebHostEnvironment>();
            webhostEnvironmentMock.Setup(x => x.EnvironmentName).Returns("Development");
            webhostEnvironmentMock.Setup(x => x.ContentRootPath).Returns(AppDomain.CurrentDomain.BaseDirectory);

            var configuration = new Startup(webhostEnvironmentMock.Object);

            var services = new ServiceCollection();
            services.AddScoped<IMediator, Mediator>();
            services.AddMediatR(typeof(GetMovieCastQuery).GetTypeInfo().Assembly);
            services.AddHttpClient<ICastService, CastService>();
            
            services.AddTransient(c => configuration);

            serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public async Task GetCastByMovieIdQueryTest()
        {
            using var scope = serviceProvider.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            Assert.IsNotNull(mediator, "mediator cannot be resolved by DI");

            var result = await mediator.Send(new GetMovieCastQuery(338762)).ConfigureAwait(false);

            Assert.IsTrue(result.Any());
            
        }
    }
}
