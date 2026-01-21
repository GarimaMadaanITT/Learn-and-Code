using System;

namespace FloorMeanValue.Util
{
    public static class InputReader
    {
        public static int[] ReadIntArray()
        {
            return Array.ConvertAll(
                Console.ReadLine()!.Split(' '),
                int.Parse
            );
        }
    }
}
