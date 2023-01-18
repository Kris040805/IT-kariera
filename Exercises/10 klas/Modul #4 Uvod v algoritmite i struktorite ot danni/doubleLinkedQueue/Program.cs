using System;

namespace doubleLinkedQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> queue = new MyQueue<int>();

            queue.Enqueue(5);
            queue.Enqueue(51);
            queue.Enqueue(511);

            queue.Dequeue();

            int[] arr = queue.ToArray();

            foreach (int item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
