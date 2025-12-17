using System;
using CountryNeighborLookup.Services;

namespace CountryNeighborLookup
{
    class CountryNeighborFinder
    {
        static void Main(string[] args)
        {
            CountryNeighborReader neighborReader = new CountryNeighborReader("CountryNeighbors.json");

            while (true)
            {
                Console.WriteLine("\nCountry Neighbor Finder ");
                Console.WriteLine("1. Find neighbours");
                Console.WriteLine("2. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Country Code (e.g., IN, US, NZ): ");
                        string countryCode = Console.ReadLine();

                        List<String> neighbors = neighborReader.GetNeighbors(countryCode);

                        if (neighbors == null)
                        {
                            Console.WriteLine("Country code not found.");
                        }
                        else if (neighbors.Count == 0)
                        {
                            Console.WriteLine("This country has no adjacent land countries.");
                        }
                        else
                        {
                            Console.WriteLine("Adjacent Countries:");
                            foreach (String country in neighbors)
                            {
                                Console.WriteLine(country);
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("Exit application.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try Again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
