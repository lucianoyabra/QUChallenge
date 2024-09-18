using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using WordFinder.Infrastructure.Interfaces.V1;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WordFinder.UnitTests.MatrixValidatorTests.V1
{
    public class MatrixValidatorTests
    {
        private readonly IMatrixValidator _matrixValidator;

        public MatrixValidatorTests()
        {
            // Set up DI container
            var serviceProvider = TestStartup.ConfigureServices();
            _matrixValidator = serviceProvider.GetRequiredService<IMatrixValidator>();
        }

        [Fact]
        public void IsValidMatrix_ValidMatrix_ReturnsTrue()
        {
            var matrix = new List<string>
            {
                "abcd",
                "efgh",
                "ijkl",
                "mnop"
            };

            var result = _matrixValidator.IsValidMatrix();
            Assert.IsTrue(result);
        }

        [Fact]
        public void IsValidMatrix_InvalidMatrix_ReturnsFalse()
        {
            var matrix = new List<string>
            {
                "abcd",
                "efg",
                "ijkl",
                "mnop"
            };

            var result = _matrixValidator.IsValidMatrix();
            Assert.IsFalse(result);
        }
    }
}
