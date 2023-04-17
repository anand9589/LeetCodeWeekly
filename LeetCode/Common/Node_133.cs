namespace Common
{
    public class Node_133
    {
        public int val;
        public IList<Node_133> neighbors;

        public Node_133()
        {
            val = 0;
            neighbors = new List<Node_133>();
        }

        public Node_133(int _val)
        {
            val = _val;
            neighbors = new List<Node_133>();
        }

        public Node_133(int _val, List<Node_133> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
