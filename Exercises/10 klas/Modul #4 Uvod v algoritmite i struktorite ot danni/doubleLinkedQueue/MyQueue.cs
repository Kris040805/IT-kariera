using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doubleLinkedQueue
{
    class MyQueue<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }

            public Node(T value)
            {
                Value = value;
            }


        }


        private Node head;
        private Node tail;
        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            Node newNode = new Node(element);

            if (this.Count == 0)
            {
                this.head = newNode;
            }
            else
            {
                newNode.PrevNode = this.tail;
                this.tail.NextNode = newNode;
            }

            this.tail = newNode;
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            
            T value = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PrevNode = null;
            }
            
            Count--;

            return value;
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];

            Node currntNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                arr[i] = currntNode.Value;
                currntNode = currntNode.NextNode;
            }

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currntNode = this.head;

            while (currntNode != null)
            {
                yield return currntNode.Value;
                currntNode = currntNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
