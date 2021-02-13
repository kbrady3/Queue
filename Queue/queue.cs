using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace QueueLab
{
    public class queue
    {
        // Members
        private int head;    // The top of the queue
        private int tail;    // The bottom of the queue
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
            string item = null;
            // TODO
            return item; // Possibly you will remove this line, this is for running Unit Tests before writing code 
        }

        public int setHead()
        {
            for (int i = 0; i < stackItems.Length; i++)
            {
                if (string.IsNullOrEmpty(stackItems[i]))
                {
                    //Gets the index of the last not null value
                    head = i - 1;
                    break;
                }
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

            string itemAtHead = stackItems[head];
            stackItems[head] = null;
            return itemAtHead; //Return item that was dequeued
        }


        public void enqueue(string item)
        {
            setQueueSize();

            string[] tempString = new string[queueSize];

            if(stackItems[0] == null)
            {
                stackItems[0] = item; //Enqueue the item
            }
            else
            {
                for (int i = 0; i < queueSize; i++)
                {
                    string currentItem = stackItems[i]; //Gets current item from stackItems

                    if (i == queueSize - 1) //Ensures it won't try to go past the max size when it adds 1 to the index
                    {
                        break;
                    }
                    else
                    {
                        tempString[i + 1] = currentItem; //Copies currentItem to tempString, one position higher than it was in stackItems
                    }
                }

                stackItems[0] = item; //Enqueue the item

                for (int i = 0; i < tempString.Length; i++)
                {
                    if (i == tempString.Length - 1) //Ensures it won't try to go past the max size when it adds 1 to the index
                    {
                        break;
                    }
                    else
                    {
                        stackItems[i + 1] = tempString[i]; //Move items up one index
                    }
                }
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
