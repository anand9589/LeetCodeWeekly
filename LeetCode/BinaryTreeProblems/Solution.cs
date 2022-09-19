namespace BinaryTreeProblems
{
    public class Solution
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            TreeNode root = null;

            root = new TreeNode(preorder[0], null, null);

            int index = Array.IndexOf(inorder, preorder[0]);

            int[] leftNode = inorder.Take(index).ToArray();
            int [] rightNode = inorder.Skip(index+1).ToArray();


            root.Left = leftNode.Length > 0 ? BuildTree(preorder.Skip(1).Take(leftNode.Length).ToArray(), leftNode) : null;
            root.Right = rightNode.Length > 0 ? BuildTree(preorder.Skip(leftNode.Length+1).ToArray(), rightNode) : null;

            return root;
        }

        //private TreeNode BuildTree_Helper()
        //{

        //}
    }
}
