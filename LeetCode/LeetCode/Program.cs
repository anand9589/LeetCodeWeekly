
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

char[][] maze = new char[][] { new char[] { '+', '+', '+' }, new char[] { '.', '.', '.' }, new char[] { '+', '+', '+' } };
//[[0,1,1],[1,0,1],[0,0,1]]
var res = solution.OnesMinusZeros(new int[][] { new int[] {0,1,1 }, new int[] {1,0,1 }, new int[] {0,0,1 } });
Console.WriteLine(res);