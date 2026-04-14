using Xunit;
using DivisorProblem.Services;

namespace DivisorProblem.Tests
{
    public class DivisorServiceTests
    {
        private readonly DivisorService _service;

        public DivisorServiceTests()
        {
            _service = new DivisorService();
        }

        [Fact]
        public void CountValidNumbers_WhenKIs15_Returns2()
        {
            int result = _service.CountValidNumbers(15);
            Assert.Equal(2, result);
        }

        [Fact]
        public void CountValidNumbers_WhenKIs3_Returns1()
        {
            int result = _service.CountValidNumbers(3);
            Assert.Equal(1, result); // (2,3)
        }

        [Fact]
        public void CountValidNumbers_WhenKIs2_Returns0()
        {
            int result = _service.CountValidNumbers(2);
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountValidNumbers_WhenKIs50_ReturnsExpected()
        {
            int result = _service.CountValidNumbers(50);
            Assert.True(result > 0);
        }

        [Fact]
        public void CountValidNumbers_WhenKIsNegative_Returns0()
        {
            int result = _service.CountValidNumbers(-10);
            Assert.Equal(0, result);
        }
    }
}