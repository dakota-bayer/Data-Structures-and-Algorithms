using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SinglyLinkedList
{
    public class SinglyLinkedList
    {
        public Node? head { get; private set; }
        public int length { get; private set; }

        public SinglyLinkedList()
        {
            head = null;
            length = 0;
        }

        public void Insert(int data)
        {
            var node = new Node(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                var currentNode = head;
                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }
                currentNode.next = node;
            }

            length++;
        }

        public void InsertAt(int index, Node node)
        {
            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException();
            }

            if (head == null)
            {
                head = node;
                length = 1;
                return;
            }

            if (index == 0)
            {
                var previousHead = head;
                head = node;
                head.next = previousHead;
                length++;
                return;
            }

            var currentIndex = 0;
            var currentNode = head;
            while (currentIndex < index - 1)
            {
                currentNode = currentNode.next;
                currentIndex++;
            }

            var current = head;
        }
    }
}