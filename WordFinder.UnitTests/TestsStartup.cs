using Microsoft.Extensions.DependencyInjection;
using System;
using WordFinder.Infrastructure;
using WordFinder.Infrastructure.Interfaces.V1;
using WordFinder.Infrastructure.Processors.V1;

namespace WordFinder.UnitTests
{
    public class TestStartup
    {
        public static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            // Register services
            serviceCollection.AddTransient<IMatrixValidator, MatrixValidator>();
            serviceCollection.AddTransient<IWordsFinder, WordsFinder>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
