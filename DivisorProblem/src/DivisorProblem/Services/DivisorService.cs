using DivisorProblem.Interfaces;

namespace DivisorProblem.Services;

public class DivisorService : IDivisorService
{
    public int CountDivisors(int n)
    {
        if (n <= 0) return 0;
        int count = 0;
        for (int i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                count++;
                if (i != n / i)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public int CountValidNumbers(int k)
    {
        int count = 0;
        for (int n = 2; n < k; n++)
        {
            if (CountDivisors(n) == CountDivisors(n + 1))
            {
                count++;
            }
        }
        return count;
    }
}