using Xunit;
using UE1.Library;

namespace UE1.Library.Test;

public class PrimeCheckerTest
{
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(97)]
    public void PrimeChecker_PrimeNumber_ReturnsTrue(int number)
    {
        var result = PrimeChecker.IsPrime(number);
        Assert.True(result);
    }

    private const int MAX_COMPOSITE = 100;

    public static TheoryData<int> NonPrimeNumbers
    {
        get
        {
            var data = new TheoryData<int>();

            for (int i = 2; i <= MAX_COMPOSITE / 2; i++)
            {
                for (int j = i; i * j <= MAX_COMPOSITE; j++)
                {
                    data.Add(i * j);
                }
            }

            return data;
        }
    }

    [Theory]
    [MemberData(nameof(NonPrimeNumbers))]
    public void PrimeChecker_NonPrimeNumber_ReturnsFalse(int number)
    {
        var result = PrimeChecker.IsPrime(number);
        Assert.False(result);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-3)]
    public void PrimeChecker_InvalidNumber_ReturnsFalse(int number)
    {
        var result = PrimeChecker.IsPrime(number);
        Assert.False(result);
    }
}
