namespace DataStructures 
{
    public class LinkedQueue<T> 
    {
        private class Node 
        {
            public T value;
            public Node next;
        }

        private Node head = null;
        private Node tail = null;
        private int count = 0;

        public void Enqueue(T value)
        {
            Node newNode = new Node();
            newNode.value = value;

            if(count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }

            count++;
        }

        public T Dequeue()
        {
            if(count == 0)
            {
                throw new System.InvalidOperationException("Queue is empty");
            }
            T value = head.value;
            head = head.next;
            count--;

            if(count == 0)
            {
                tail = null;
            }

            return value;
        }

        public int GetCount()
        {
            return count;
        }
    }
}
