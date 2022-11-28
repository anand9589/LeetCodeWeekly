
using Common;
using November22;
using static November22.Solution;
//[17,13,17,20,5,18,5,6]
//6
//char[][] arr = Utilities.Get2DCharArray(@".\Testcase.txt");

//TreeNode treeNode = Utilities.BuildTreeNode(new int?[] { 16, 14, null, 4, 15, 1 });
Solution solution = new Solution();
//var res = solution.ReverseVowels("hello");
//var res = solution.RemoveDuplicates("abbaca");
//Console.WriteLine(res);
//[["+","+","+"],[".",".","."],["+","+","+"]]

int[][] arr = Utilities.Get2DArray(@".\Testcase.txt");

//[[0,1,1],[1,0,1],[0,0,1]]
var res = solution.FindWinners(arr);
Console.WriteLine(res);