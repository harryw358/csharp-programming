using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularQueue
{
    class Queue
    {
        private int[] queue;
        private int front = 0, rear = -1, size = 0, maxSize = 5;

        public Queue()
        {
            queue = new int[5];
        }
        public bool IsEmpty()
        {
            if (size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsFull()
        {
            if (size == maxSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Enqueue(int newItem)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue full.");
            }
            else
            {
                rear = (rear + 1) % maxSize;
                queue[rear] = newItem;
                size++;
            }
        }
        public void Dequeue()
        {
            int item;
            if (IsEmpty())
            {
                Console.WriteLine("Queue empty!");
            }
            else
            {
                item = queue[front];
                front = (front + 1) % maxSize;
                size--;
                Console.WriteLine($"Dequeued {item}");
            }
        }
        public void DisplayQueue()
        {
            for (int i = 0; i < maxSize; i++)
            {
                Console.WriteLine(i + ": " + queue[i]);
            }
        }
    }
}
