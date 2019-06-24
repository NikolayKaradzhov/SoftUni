using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace p07.CustomLinkedList
{
    class DoublyLinkedList<T> : IEnumerable<T>
    {
        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; }

            public ListNode<T> NextNode { get; set; }

            public ListNode<T> PreviousNode { get; set; }
        }

        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            ListNode<T> newHead = new ListNode<T>(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            ListNode<T> newTail = new ListNode<T>(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newTail;
            }
            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            ValidateCount();

            T firstElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;

            return firstElement;
        }

        public T RemoveLast()
        {
            ValidateCount();

            T lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;

            return lastElement;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            int counter = 0;

            ListNode<T> currentNode = this.head;

            while (currentNode != null)
            {
                array[counter++] = currentNode.Value;

                currentNode = currentNode.NextNode;
            }

            return array;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);

                currentNode = currentNode.NextNode;
            }
        }

        public List<T> ToList()
        {
            List<T> list = new List<T>();

            var currentNode = this.head;

            while (currentNode != null)
            {
                list.Add(currentNode.Value);

                currentNode = currentNode.NextNode;
            }

            return list;
        }

        public bool Contains(T value)
        {
            ListNode<T> currentNode = this.head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }

                currentNode = currentNode.NextNode;
            }

            return false;
        }

        private void ValidateCount()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(
                    "The list is empty");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> nodeHead = this.head;
            ListNode<T> nodeTail = this.tail;

            while (nodeHead != null)
            {
                yield return nodeHead.Value;

                nodeHead = nodeHead.NextNode;
            }

            while (nodeTail != null)
            {
                yield return nodeTail.Value;

                nodeTail = nodeTail.PreviousNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}