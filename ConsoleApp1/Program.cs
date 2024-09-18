using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WordFinder.Infrastructure;
using WordFinder.Infrastructure.Interfaces.V1;
using WordFinder.Infrastructure.Processors.V1;

namespace WordFinder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample matrix and word stream
            IEnumerable<string> matrix = new List<string>
            {
                "chill",
                "cold ",
                "wind "
            };

            IEnumerable<string> wordStream = new List<string>
            {
                "chill",
                "cold",
                "wind",
                "snow"
            };

            // Setup dependency injection
            var serviceProvider = new ServiceCollection()
                .AddTransient<IMatrixValidator>(provider => new MatrixValidator(matrix))
                .AddTransient<IWordsFinder>(provider => new WordsFinder(matrix))
                .BuildServiceProvider();

            // Resolve services
            var matrixValidator = serviceProvider.GetRequiredService<IMatrixValidator>();
            var wordsFinder = serviceProvider.GetRequiredService<IWordsFinder>();

            // Validate the matrix
            if (matrixValidator.IsValidMatrix())
            {
                Console.WriteLine("Matrix is valid. Proceeding with word search...");
                // Find words
                var foundWords = wordsFinder.Find(wordStream);

                // Output results
                Console.WriteLine("Found words:");
                foreach (var word in foundWords)
                {
                    Console.WriteLine(word);
                }
            }
            else
            {
                Console.WriteLine("Invalid matrix.");
            }
        }
    }
}
