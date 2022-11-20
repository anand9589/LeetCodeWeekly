
using Common;
using November22;
using static November22.Solution;
//[17,13,17,20,5,18,5,6]
//6
//char[][] arr = Utilities.Get2DCharArray(@".\Testcase.txt");
Solution solution = new Solution();
//var res = solution.RemoveDuplicates("abbaca");
//Console.WriteLine(res);


StockSpanner stockSpanner = new StockSpanner();
int res = stockSpanner.Next(28);
Console.WriteLine(res);
res = stockSpanner.Next(14);
Console.WriteLine(res);
res = stockSpanner.Next(28);
Console.WriteLine(res);
res = stockSpanner.Next(35);
Console.WriteLine(res);
res = stockSpanner.Next(46);
Console.WriteLine(res);
res = stockSpanner.Next(53);
Console.WriteLine(res);
res = stockSpanner.Next(66);
Console.WriteLine(res);
res = stockSpanner.Next(80);
Console.WriteLine(res);
res = stockSpanner.Next(87);
Console.WriteLine(res);
res = stockSpanner.Next(88);
Console.WriteLine(res);