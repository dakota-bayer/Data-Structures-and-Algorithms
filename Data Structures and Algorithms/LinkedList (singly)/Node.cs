namespace DataStructures.SinglyLinkedList
{
    public class Node
    {
        public int data { get; set; }
        public Node? next { get; set; }

        public Node(int data)
        {
            this.data = data;
            next = null;
        }

        public bool HasNext()
        {
            return next != null;
        }
    }
}