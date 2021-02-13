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
            setQueueSize();
            setHead();

            if (head == maxSize - 1 && stackItems[head] != null)
            {
                throw new queueFullException();
            }
            else
            {
                string[] tempString = new string[queueSize];

                if (stackItems[0] == null)
                {
                    stackItems[0] = item; //Enqueue the item
                }
                else
                {
                    for (int i = 0; i < stackItems.Length; i++)
                    {
                        if (stackItems[i] != null)
                        {
                            string currentItem = stackItems[i]; //Gets current item from stackItems

                            if (i == stackItems.Length - 1) //Ensures it won't try to go past the max size when it adds 1 to the index
                            {
                                break;
                            }
                            else
                            {
                                tempString[i + 1] = currentItem; //Copies currentItem to tempString, one position higher than it was in stackItems
                            }
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
