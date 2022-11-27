
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

var res = solution.JobScheduling(new int[] { 1, 2, 3, 3 }, new int[] { 3, 4, 5, 6 }, new int[] { 50, 10, 40, 70 });
Console.WriteLine(res);