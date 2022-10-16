
using Common;
using LeetCode;
using October22;

Solution solution = new Solution();

ListNode head = Utilities.BuildListNode(new int[] { 1, 2});
//Problems problems = new Problems();
//problems.ReverseBetween(head, 2, 4);
var p = solution.CountDistinctIntegers(new int[] { 1, 13, 10, 12, 31 });
Console.WriteLine(p);