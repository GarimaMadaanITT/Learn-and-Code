using Xunit;
using DivisorProblem.Services;

public class DivisorServiceParameterizedTests
{
    private readonly DivisorService _service = new DivisorService();

    [Theory]
    [InlineData(15, 2)]
    [InlineData(3, 1)]
    [InlineData(2, 0)]
    [InlineData(1, 0)]
    public void CountValidNumbers_VariousInputs(int k, int expected)
    {
        var result = _service.CountValidNumbers(k);
        Assert.Equal(expected, result);
    }
}