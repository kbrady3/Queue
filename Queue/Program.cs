using System;

namespace QueueLab
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueLab.queue myQueue = new QueueLab.queue(2);
            String item = "queueItem";
            String actual, expected;
            expected = "queueItem3";
            myQueue.enqueue(item + "1");
            myQueue.enqueue(item + "2");
            myQueue.dequeue();
            myQueue.enqueue(item + "3");
            myQueue.dequeue();
            actual = myQueue.peek();
        }
    }
}
