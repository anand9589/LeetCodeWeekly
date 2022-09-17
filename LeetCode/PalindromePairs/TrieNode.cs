namespace PalindromePairs
{
    public class TrieNode
    {
        public TrieNode[] Next { get; set; }

        public int Index { get; set; }

        public List<int> TrieNodeList { get; set; }

        public TrieNode()
        {
            Next = new TrieNode[26];
            Index = -1;
            TrieNodeList = new List<int>();
        }
    }
}