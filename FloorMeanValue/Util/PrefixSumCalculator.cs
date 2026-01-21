namespace Util
{
    public static class PrefixSumCalculator
    {
        public static long[] BuildPrefixSums(int[] values)
        {
            var prefixSums = new long[values.Length + 1];

            for (int i = 1; i <= values.Length; i++)
            {
                prefixSums[i] = prefixSums[i - 1] + values[i - 1];
            }

            return prefixSums;
        }
    }
}
