using Microsoft.Extensions.DependencyInjection;
using System;
using WordFinder.Infras

public class TestStartup
{
    public static IServiceProvider ConfigureServices()
    {
        var serviceCollection = new ServiceCollection();

        // Register services
        serviceCollection.AddTransient<IMatrixValidator, WordFinder.Tests.MatrixValidator>();
        serviceCollection.AddTransient<IWordsFinder, WordsFinder>();

        return serviceCollection.BuildServiceProvider();
    }
}
