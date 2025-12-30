using Constants;
using FloorMeanValue.Util;
using System;
using Util;

namespace Game
{
    public class FloorMeanQueryProcessor
    {
        public void Run()
        {
            Console.WriteLine(Messages.EnterCounts);
            var counts = InputReader.ReadIntArray();

            int elementCount = counts[0];
            int queryCount = counts[1];

            Console.WriteLine(Messages.EnterArray);
            var array = InputReader.ReadIntArray();

            var prefixSums = PrefixSumCalculator.BuildPrefixSums(array);

            ProcessQueries(prefixSums, queryCount);
        }

        private void ProcessQueries(long[] prefixSums, int queryCount)
        {
            for (int i = 0; i < queryCount; i++)
            {
                Console.WriteLine(Messages.EnterQuery);
                var query = InputReader.ReadIntArray();

                long mean = CalculateFloorMean(
                    prefixSums,
                    query[0],
                    query[1]
                );

                Console.WriteLine(mean);
            }
        }

        private long CalculateFloorMean(
            long[] prefixSums,
            int leftIndex,
            int rightIndex)
        {
            long sum =
                prefixSums[rightIndex] -
                prefixSums[leftIndex - 1];

            int length = rightIndex - leftIndex + 1;

            return sum / length;
        }
    }
}
