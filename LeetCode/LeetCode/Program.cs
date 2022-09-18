// See https://aka.ms/new-console-template for more information
using LeetCode;
using Week311;

TreeNode treeNode = new TreeNode(0,null,null);
treeNode.left = new TreeNode(1,null,null);
treeNode.right = new TreeNode(2,null,null);
treeNode.left.left = new TreeNode(0,null,null);
treeNode.left.right = new TreeNode(0, null, null);
treeNode.right.left = new TreeNode(0, null, null);
treeNode.right.right = new TreeNode(0, null, null);
treeNode.left.left.left = new TreeNode(1, null, null);
treeNode.left.left.right = new TreeNode(1, null, null);
treeNode.left.right.left = new TreeNode(1, null, null);
treeNode.left.right.right = new TreeNode(1, null, null);
treeNode.right.left.left = new TreeNode(2, null, null);
treeNode.right.left.right = new TreeNode(2, null, null);
treeNode.right.right.left = new TreeNode(2, null, null);
treeNode.right.right.right = new TreeNode(2, null, null);

Solution Solution = new Solution();

Solution.ReverseOddLevels(treeNode);