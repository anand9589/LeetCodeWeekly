
using Common;
using LeetCode;
using October22;
using static LeetCode.Problems;

//Solution solution = new Solution();

////ListNode head = Utilities.BuildListNode(new int[] { 1, 2});


//string[] arr1 = File.ReadAllLines(@".\Testcase.txt");
//string[] arr2 = arr1[0].Replace("\"","").Split(',');
//var p =solution.MaxLength(arr2);
//int[] arr3 = Array.ConvertAll(arr1[1].Split(','), int.Parse);
//var p = solution.LongestNiceSubarray(arr2);
//Console.WriteLine(p);
//int k = Convert.ToInt32(arr1[1]);
//string[] arr2 = arr1[0].Split(',');
//int?[] arr = new int?[arr2.Length];
//for (int i = 0; i < arr2.Length; i++)
//{
//    if (arr2[i] != "null") arr[i] = Convert.ToInt32(arr2[i]);
//}
//TreeNode root = Utilities.BuildTreeNode(arr);
////int[] postorder = Array.ConvertAll(arr1[1].Split(','), int.Parse);
//Problems problems = new Problems();

//var p = problems.Min(new int[] { 5, 6, 2, 7, 4 });

//Console.WriteLine(p);

CustomStack customStack = new CustomStack(3);
customStack.Push(1);
customStack.Push(2);
customStack.Pop();
customStack.Push(2);
customStack.Push(3);
customStack.Push(4);
customStack.Increment(5, 100);
customStack.Increment(2,100);
customStack.Pop();
customStack.Pop();
customStack.Pop();
Console.ReadLine();