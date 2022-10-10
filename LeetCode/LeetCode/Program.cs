
using Common;
using October22;

Solution solution = new Solution();
TreeNode treeNode = new TreeNode(5,
    new TreeNode(3, new TreeNode(2, null, null), new TreeNode(4, null, null)),
    new TreeNode(6, null, new TreeNode(7, null, null)));
solution.BreakPalindrome("aabbaa");
//Console.WriteLine(  solution.DeleteString("aaaaa"));
//solution.MaxSum(new int[][] { new int[] { 6, 2, 1, 3 }, new int[] { 4, 2, 1, 5 }, new int[] { 9, 2, 8, 7 }, new int[] { 4, 1, 2, 9 } });

//solution.MaxSum(new int[][] { new int[] { 520626, 685427, 788912, 800638, 717251, 683428 }, new int[] { 23602, 608915, 697585, 957500, 154778, 209236 }, new int[] { 287585, 588801, 818234, 73530, 939116, 252369 } });
//using LeetCode;
//using static October22.Solution;
//["TimeMap","set","get","get","set","get","get"]
////[[],["foo","bar",1],["foo",1],["foo",3],["foo","bar2",4],["foo",4],["foo",5]]
//Problems problems = new Problems();
//problems.IsHappy(19);
//problems.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 });
//TimeMap timeMap = new TimeMap();
//timeMap.Set("foo", "bar", 1);
//timeMap.Get("foo", 1);
//timeMap.Get("foo", 3);
//timeMap.Set("foo", "bar2", 4);
//timeMap.Get("foo", 4);
//timeMap.Get("foo", 3);
//timeMap.Get("foo", 1);

