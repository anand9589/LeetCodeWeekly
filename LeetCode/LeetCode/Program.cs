
using Common;
using November22;
//[17,13,17,20,5,18,5,6]
//6
//char[][] arr = Utilities.Get2DCharArray(@".\Testcase.txt");
Solution solution = new Solution();
var res = solution.OuterTrees(new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 2, 0 }, new int[] { 2, 4 }, new int[] { 3, 3 }, new int[] { 4, 2 } });
Console.WriteLine(res);