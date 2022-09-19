namespace BinaryTreeProblems
{
    public class TreeNode
    {
        public int Val { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int val, TreeNode left, TreeNode right)
        {
            Val = val;
            Left = left;
            Right = right;
        }
    }
}