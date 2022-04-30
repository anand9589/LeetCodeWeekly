// See https://aka.ms/new-console-template for more information
using Biweek77;

Console.WriteLine("Hello, World!");

var grid1 = "0,2,0,0,0,0,0],[0,0,0,2,2,1,0],[0,2,0,0,1,2,0],[0,0,2,2,2,0,2],[0,0,0,0,0,0,0";

//var grid1 = "0,0,0],[2,2,0],[1,2,0";

string[] strs = grid1.Split("],[");

int[][] grid = new int[strs.Length][];

for (int i = 0; i < strs.Length; i++)
{
    int[] g = Array.ConvertAll(strs[i].Split(','), int.Parse);
    grid[i] = g;
}

Solution solution = new Solution();
var res = solution.MaximumMinutes(grid);
Console.WriteLine(res);