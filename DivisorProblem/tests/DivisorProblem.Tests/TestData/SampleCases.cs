namespace DivisorProblem.Tests.TestData;

public static class SampleCases
{
    public static IEnumerable<object[]> TestCases => new List<object[]>
    {
        new object[] { 15, 2 }, // Example: n=2,14
        new object[] { 10, 1 }, // n=2
        new object[] { 5, 1 },  // n=2
        new object[] { 4, 1 },  // n=2
        new object[] { 3, 1 },  // n=2
        new object[] { 2, 0 },  // no n
    };
}