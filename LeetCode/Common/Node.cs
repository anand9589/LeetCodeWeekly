namespace Common
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public class NodeV1
    {
        public int val;
        public IList<NodeV1> neighbors;

        public NodeV1()
        {
            val = 0;
            neighbors = new List<NodeV1>();
        }

        public NodeV1(int _val)
        {
            val = _val;
            neighbors = new List<NodeV1>();
        }

        public NodeV1(int _val, List<NodeV1> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
