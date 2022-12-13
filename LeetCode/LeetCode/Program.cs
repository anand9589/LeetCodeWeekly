using December22;
using Common;
//using static December22.Solution;

////["Allocator","allocate","allocate","allocate","free","allocate","allocate","allocate","free","allocate","free"]
////[[10],[1,1],[1,2],[1,3],[2],[3,4],[1,1],[1,1],[1],[10,2],[7]]

var head = Utilities.Get2DArray();
Solution solution = new Solution();
var p = solution.MinFallingPathSum(new int[][] { new int[] { 2, 1, 3 }, new int[] { 6, 5, 4 }, new int[] { 7, 8, 9 } });
//Allocator allocator = new Allocator(10);
//Console.WriteLine(allocator.Allocate(11, 1));
//Console.WriteLine(allocator.Allocate(1, 1));
//Console.WriteLine(allocator.Allocate(1, 2));
//Console.WriteLine(allocator.Allocate(1, 3));
//Console.WriteLine(allocator.Free(2));
//Console.WriteLine(allocator.Allocate(3, 4));
//Console.WriteLine(allocator.Allocate(1, 1));
//Console.WriteLine(allocator.Allocate(1, 1));
//Console.WriteLine(allocator.Free(1));
//Console.WriteLine(allocator.Allocate(10, 2));
//Console.WriteLine(allocator.Free(7));

