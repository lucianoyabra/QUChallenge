using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WordFinder.Infrastructure.Validators.V1;
using Xunit;

namespace WordFinder.Tests.MatrixValidator.V1
{
    public class MatrixValidatorTests
    {
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

            var validator = new MatrixValidator(matrix);
            var result = validator.IsValidMatrix();
            Assert.True(result);
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

            var validator = new MatrixValidator(matrix);
            var result = validator.IsValidMatrix();
            Assert.False(result);
        }
    }
}
