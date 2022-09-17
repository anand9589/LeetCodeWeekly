namespace PalindromePairs
{
    public class Solution
    {
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            IList<IList<int>> list = new List<IList<int>>();

            TrieNode trieNode = new TrieNode();

            for (int i = 0; i < words.Length; i++)
            {
                addWord(trieNode, words[i], i);
            }

            for (int i = 0; i < words.Length; i++)
            {
                search(words, i, trieNode, list);
            }

            return list;
        }

        private void search(string[] words, int i, TrieNode trieNode, IList<IList<int>> list)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                if (trieNode.Index>=0&&trieNode.Index!=i&&isPalindrome(words[i],j, words[i].Length-1))
                {
                    list.Add(new List<int>() { i, trieNode.Index });
                }

                trieNode = trieNode.Next[words[i][j]-'a'];

                if (trieNode == null) return;
            }

            foreach (var j in trieNode.TrieNodeList)
            {
                if (i == j) continue;
                list.Add(new List<int>() { i, j});
            }
        }

        private void addWord(TrieNode trieNode, string word, int index)
        {
            for (int i = word.Length-1; i >= 0; i--)
            {
                int j = word[i]-'a';

                if (trieNode.Next[j] == null)
                {
                    trieNode.Next[j]=new TrieNode();
                }

                if (isPalindrome(word, 0, i))
                {
                    trieNode.TrieNodeList.Add(index);
                }

                trieNode = trieNode.Next[j];
            }

            trieNode.TrieNodeList.Add(index);
            trieNode.Index = index;
        }

        private bool isPalindrome(string word, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                if (word[startIndex++] != word[endIndex--]) return false;
            }
            return true;
        }
    }
}
