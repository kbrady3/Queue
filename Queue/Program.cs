using System;

namespace QueueLab
{
    class Program
    {
        static void Main(string[] args)
        {
            queue q = new queue();
            q.enqueue("Hello world");
            q.enqueue("Hi");
            string d = q.dequeue();
            Console.WriteLine(q.printQueue());
            Console.WriteLine(d);
        }
    }
}
