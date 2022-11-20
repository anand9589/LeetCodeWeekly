
using Common;
using November22;
using static November22.Solution;
//[17,13,17,20,5,18,5,6]
//6
//char[][] arr = Utilities.Get2DCharArray(@".\Testcase.txt");

TreeNode treeNode = Utilities.BuildTreeNode(new int?[] { 16, 14, null, 4, 15, 1 });
Solution solution = new Solution();
var res = solution.ClosestNodes(treeNode, new List<int>() { 10, 6, 2, 9 });
//var res = solution.RemoveDuplicates("abbaca");
//Console.WriteLine(res);

