namespace Common
{
    public class DoublyLinkedList
    {

        public int Value { get; set; }
        public int Key { get; private set; }
        public DoublyLinkedList Previous { get; set; }
        public DoublyLinkedList Next { get; set; }
        public DoublyLinkedList()
        {
            Key = 0;
            Value = 0;
        }

        public DoublyLinkedList(int key, int val)
        {
            Key = key;
            Value = val;
        }

        public DoublyLinkedList(int value, int key, DoublyLinkedList previous, DoublyLinkedList next)
        {
            Value = value;
            Key = key;
            Previous = previous;
            Next = next;
        }
    }
}
