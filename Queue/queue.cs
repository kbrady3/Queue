using System;
using System.Collections.Generic;
using System.Text;

namespace QueueLab
{
    public class queue
    {
        // Members
        private int head;    // TODO
        private int tail;    // TODO
        private int queueSize;    // TODO
        private int maxSize; // TODO 
        private string[] stackItems;

        public queue()
        {
            this.maxSize = 5;
            this.queueSize = 0;
            this.head = -1; 
            this.tail = -1;
            this.stackItems = new string[maxSize];
        }

        public queue(int maxSize)
        {
            this.maxSize = maxSize;
            this.queueSize = 0;
            this.head = -1;
            this.tail = -1;
            this.stackItems = new string[maxSize];
        }

        public bool isFull()
        {
            // TODO 
            return false;  // Possibly you will remove this line, this is for running Unit Tests before writing code
        }

        public bool isEmpty()
        {
            // TODO 
            return false;  // Possibly you will remove this line, this is for running Unit Tests before writing code
        }

        public int size()
        {
            // TODO 
            return -1;  // Possibly you will remove this line, this is for running Unit Tests before writing code
        }

        public string peek()
        {
            string item = null;
            // TODO
            return item; // Possibly you will remove this line, this is for running Unit Tests before writing code 
        }

        public string dequeue()
        {
            string item = null;
            // TODO
            return item; // Possibly you will remove this line, this is for running Unit Tests before writing code
        }


        public void enqueue(string item)
        {
            //TODO
        }

        public string printQueue() 
        {
            string stackString = "";
            // TODO
            return stackString; // Possibly you will remove this line, this is for running Unit Tests before writing code
        }
    }
}
