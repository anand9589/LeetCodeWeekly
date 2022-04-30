// See https://aka.ms/new-console-template for more information
using Biweek77;

Console.WriteLine("Hello, World!");
Solution solution = new Solution();
var res = solution.CountUnguarded(4, 6, new int[][] { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 3 } }, new int[][] { new int[] { 0, 1 }, new int[] { 2, 2 }, new int[] { 1, 4 } });
Console.WriteLine(res);