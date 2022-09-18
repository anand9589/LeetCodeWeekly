namespace Week311
{
    public class Solution
    {
        public int SmallestEvenMultiple(int n)
        {
            if (n % 2 == 0) return n;

            return n * 2;
        }

        public int LongestContinuousSubstring(string s)
        {
            int result = 0;
            int index = 0;
            int counter = 1;
            while (index < s.Length - 1)
            {
                if (s[index + 1] - s[index] == 1)
                {
                    counter++;
                }
                else
                {
                    result = Math.Max(result, counter);
                    counter = 1;
                }
                index++;
            }
            return Math.Max(result, counter);
        }

        public int[] SumPrefixScores(string[] words)
        {
            int[] result = new int[words.Length];



            return result;
        }

        public TreeNode ReverseOddLevels(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 0;
            while (queue.Count > 0 && queue.Peek()!=null)
            {
                List<TreeNode> list = new List<TreeNode>();
                while (queue.Count > 0)
                {
                    list.Add(queue.Dequeue());
                }
                if (level % 2 == 1)
                {
                    int i = 0;
                    int j = list.Count-1;

                    while (i < j)
                    {
                        int temp = list[i].val;
                        list[i++].val = list[j].val;
                        list[j--].val = temp;
                    }
                }

                foreach (TreeNode node in list)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
                level++;
            }


            return root;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}