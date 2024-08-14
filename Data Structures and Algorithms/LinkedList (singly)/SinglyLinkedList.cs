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
                while (currentNode.HasNext())
                {
                    currentNode = currentNode.next;
                }
                currentNode.next = node;
            }

            length++;
        }

        public void InsertAt(int index, int data)
        {
            var insertNode = new Node(data);

            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException();
            }

            if (head == null)
            {
                head = insertNode;
                length = 1;
                return;
            }

            if (index == 0)
            {
                var previousHead = head;
                head = insertNode;
                insertNode.next = previousHead;
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

            var currentNext = currentNode.next;
            currentNode.next = insertNode;
            insertNode.next = currentNext;

            length++;
        }

        public override string ToString()
        {
            if (head == null)
            {
                return string.Empty;
            }

            var current = head;
            var str = current.data.ToString();

            while (current.HasNext())
            {
                current = current.next;
                str += $" {current.data}";
            }

            return str;
        }

        public bool RemoveFirst(int removalData)
        {
            var current = head;
            var previous = head;

            while (current != null && current.data != removalData)
            {
                previous = current;
                current = current.next;
            }

            if (current != null && current.data == removalData)
            {
                // implement removal logic here
                if (current == head)
                {
                    head = current.next;
                }
                else
                {
                    previous.next = current.next;
                }
                length--;
                return true;
            }

            return false;
        }

        public void RemoveAll(int removalData)
        {
            var current = head;
            var previous = head;

            while (current != null)
            {
                if (current.data == removalData)
                {
                    if (current == head)
                    {
                        previous = null;
                        head = current.next;
                    }
                    else
                    {
                        previous.next = current.next;
                        previous = previous;
                    }
                    length--;
                }
                else
                {
                    previous = current;
                }

                current = current.next;
            }
        }
    }
}