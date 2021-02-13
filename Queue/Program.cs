using System;

namespace QueueLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(2);
            String item = "queueItem";
            String actual, expected;
            expected = "queueItem1";
            // ACT
            myQueue.enqueue(item + "1");
            myQueue.enqueue(item + "2");
            actual = myQueue.peek();
        }
    }
}
