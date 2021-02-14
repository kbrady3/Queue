using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace QueueLab
{
    public class queue
    {
        // Members
        private int head;    // The index of item at the top of the queue
        private int tail;    // The index of item at the bottom of the queue
        private int queueSize;    // The number of items in the queue
        private int maxSize; // The max number of items the queue can contain
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
            return head == maxSize - 1; // Returns a bool representing whether head is equal to maxSize - 1
        }

        public bool isEmpty()
        {
            //Checks if the first element in the array is empty
            if (stackItems[0] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int size()
        {
            int nullCounter = 0;
            int hasValueCounter = 0;

            for (int i = 0; i < stackItems.Length; i++)
            {
                if (string.IsNullOrEmpty(stackItems[i]))
                {
                    nullCounter++;
                }
                else
                {
                    hasValueCounter++;
                }
            }

            //Returns the number of values the array holds
            return hasValueCounter;
        }

        public string peek()
        {
            string currentItem = stackItems[head];
            return currentItem;
        }

        public int setHead()
        {
            if(stackItems[0] == null)
            {
                head = -1;
            }
            else
            {
                head = stackItems.Length - 1;
            }
            
            return head;
        }

        public int setQueueSize()
        {
            int nullCounter = 0;

            for (int i = 0; i < stackItems.Length; i++)
            {
                if (string.IsNullOrEmpty(stackItems[i]))
                {
                    nullCounter++;
                }
            }

            queueSize = maxSize - nullCounter; 

            return queueSize;
        }


        public string dequeue()
        {
            setHead();

            if(stackItems[0] == null)
            {
                throw new queueEmptyException();
            }
            else
            {
                string itemAtHead = stackItems[head];
                stackItems[head] = null;
                return itemAtHead; //Return item that was dequeued
            }
        }

        public void enqueue(string item)
        {
            if(stackItems[0] == null)
            {
                stackItems[0] = item;
            }
            else if(stackItems[maxSize - 1] == null) //Checks if the last slot in the array is empty
            {
                string[] tempArray = new string[maxSize];

                //Array.Copy(originalArray, startIndex, newArray, startIndex, endIndex);
                Array.Copy(stackItems, 0, tempArray, 1, maxSize - 1); //Copies stackItems objects into tempArray, starting at index 1

                stackItems = tempArray;

                stackItems[0] = item;
            }
            else
            {
                throw new queueFullException();
            }
        }

        public string printQueue() 
        {
            string stackString = "";

            if (isEmpty())
            {
                throw new queueEmptyException();
            }
            else
            {
                for (int i = 0; i < stackItems.Length; i++)
                {
                    //Prints each item on a new line
                    stackString += stackItems[i] + "\n";
                }
            }
            return stackString;
        }
    }
}