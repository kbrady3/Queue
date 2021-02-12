using System;
using Xunit;

namespace TestQueueLab
{
    public class QueueLabTests
    {

        [Fact]
        public void TestCreatequeue()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(1);
            bool actual;
            // ACT
            actual = myQueue.isEmpty();
            // ASSERT
            Assert.True(actual);
        }

        [Fact]
        public void TestIsEmptyTrue()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(1);
            bool actual;
            // ACT
            actual = myQueue.isEmpty();
            // ASSERT
            Assert.True(actual);
        }

        [Fact]
        public void TestIsEmptyFalse()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(1);
            String item = "C# is Fun!";
            bool actual;
            // ACT
            myQueue.enqueue(item);
            actual = myQueue.isEmpty();
            // ASSERT
            Assert.False(actual);
        }

        [Fact]
        public void TestIsFullTrue()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(3);
            String item = "C# is Fun!";
            bool actual;
            // ACT
            myQueue.enqueue(item);
            myQueue.enqueue(item);
            myQueue.enqueue(item);
            myQueue.dequeue();
            myQueue.enqueue(item);
            myQueue.dequeue();
            myQueue.enqueue(item);
            actual = myQueue.isFull();
            // ASSERT
            Assert.True(actual);
        }

        [Fact]
        public void TestIsFullFalse()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(1);
            bool actual;
            // ACT
            actual = myQueue.isFull();
            // ASSERT
            Assert.False(actual);
        }

        [Fact]
        public void TestEnqueue()
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
            // ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestEnqueueFullQueue()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(1);
            String item = "queueItem";
            // ACT
            myQueue.enqueue(item);
            // ASSERT
            Assert.Throws<QueueLab.queueFullException>(() => myQueue.enqueue(item));
        }

        [Fact]
        public void TestDequeue()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(1);
            String item = "queueItem";
            String actual, expected;
            expected = item;
            myQueue.enqueue(item);
            // ACT
            actual = myQueue.dequeue();
            // ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSizeZero()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(2);
            int actual, expected;
            expected = 0;
            // ACT
            actual = myQueue.size();
            // ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSizeNonZero()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(2);
            String item = "queueItem";
            int actual, expected;
            expected = 2;
            // ACT
            myQueue.enqueue(item + "1");
            myQueue.enqueue(item + "2");
            actual = myQueue.size();
            // ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDequeueEmptyQueue()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(1);
            // ACT
            // ASSERT
            Assert.Throws<QueueLab.queueEmptyException>(() => myQueue.dequeue());
        }

        [Fact]
        public void TestWrapAround()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(2);
            String item = "queueItem";
            String actual, expected;
            expected = "queueItem3";
            // ACT
            myQueue.enqueue(item + "1");
            myQueue.enqueue(item + "2");
            myQueue.dequeue();
            myQueue.enqueue(item + "3");
            myQueue.dequeue();
            actual = myQueue.peek();
            // ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPeek()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(1);
            String item = "queueItem";
            String actual, expected;
            expected = item;
            // ACT
            myQueue.enqueue(item);
            actual = myQueue.peek();
            // ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPeekEmptyQueue()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(1);
            // ACT
            // ASSERT
            Assert.Throws<QueueLab.queueEmptyException>(() => myQueue.peek());
        }

        [Fact]
        public void TestPrintQueueEmptyQueue()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(1);
            // ACT
            // ASSERT
            Assert.Throws<QueueLab.queueEmptyException>(() => myQueue.printQueue());
        }
        [Fact]
        public void TestPrintQueue()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(2);
            String item = "queueItem";
            String actual, expected;
            expected = "queueItem1\nqueueItem2\n";
            // ACT
            myQueue.enqueue(item + "1");
            myQueue.enqueue(item + "2");
            actual = myQueue.printQueue();
            // ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPrintQueueWrapAround()
        {
            // ARRANGE
            QueueLab.queue myQueue = new QueueLab.queue(2);
            String item = "queueItem";
            String actual, expected;
            expected = "queueItem2\nqueueItem3\n";
            // ACT
            myQueue.enqueue(item + "1");
            myQueue.enqueue(item + "2");
            myQueue.dequeue();
            myQueue.enqueue(item + "3");
            actual = myQueue.printQueue();
            // ASSERT
            Assert.Equal(expected, actual);
        }

    }
}
