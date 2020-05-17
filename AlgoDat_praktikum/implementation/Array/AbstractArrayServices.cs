using System;

namespace AlgoDat_praktikum
{
    public abstract class AbstractArrayServices
    {
        // Fixed size array
        public int[] data = new int[7];

        public void Print()
        {
            Console.Write("[");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write($"{data[i]}");
                if (i == data.Length - 1) continue;
                Console.Write(",");
            }

            Console.Write("]");
        }
    }
}