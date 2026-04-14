using DivisorProblem.Services;

namespace DivisorProblem;

class Program
{
    static void Main(string[] args)
    {
        var service = new DivisorService();
        int t = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < t; i++)
        {
            int k = int.Parse(Console.ReadLine()!);
            Console.WriteLine(service.CountValidNumbers(k));
        }
    }
}