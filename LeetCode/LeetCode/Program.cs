using December22;
using Common;
//using static December22.Solution;
//using December22.MyQueue;

////["Allocator","allocate","allocate","allocate","free","allocate","allocate","allocate","free","allocate","free"]
////[[10],[1,1],[1,2],[1,3],[2],[3,4],[1,1],[1,1],[1],[10,2],[7]]

//var head = Utilities.Get2DArray();
Solution solution = new Solution();
//var p = solution.MinFallingPathSum(new int[][] { new int[] { 2, 1, 3 }, new int[] { 6, 5, 4 }, new int[] { 7, 8, 9 } });
string[] tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };

var a = solution.EvalRPN(tokens);
Console.WriteLine(a);

