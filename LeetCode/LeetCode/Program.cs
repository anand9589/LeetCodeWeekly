
using Common;
using LeetCode;
using October22;

//Solution solution = new Solution();

////ListNode head = Utilities.BuildListNode(new int[] { 1, 2});
//var p = solution.CountAndSay(5);
//Console.WriteLine(p);

string[] arr1 = File.ReadAllLines(@".\Testcase.txt");

int[] inorder = Array.ConvertAll(arr1[0].Split(','), int.Parse);
int[] postorder = Array.ConvertAll(arr1[1].Split(','), int.Parse);
Problems problems = new Problems();

var p = problems.BuildTree(inorder, postorder);

Console.WriteLine(p);