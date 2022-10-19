
using Common;
using LeetCode;
using October22;

//Solution solution = new Solution();

////ListNode head = Utilities.BuildListNode(new int[] { 1, 2});
//var p = solution.CountAndSay(5);
//Console.WriteLine(p);

string[] arr1 = File.ReadAllLines(@".\Testcase.txt");
int k = Convert.ToInt32(arr1[1]);
string[] arr2 = arr1[0].Split(',');
int?[] arr = new int?[arr2.Length];
for (int i = 0; i < arr2.Length; i++)
{
    if (arr2[i] != "null") arr[i] = Convert.ToInt32(arr2[i]);
}
TreeNode root = Utilities.BuildTreeNode(arr);
//int[] postorder = Array.ConvertAll(arr1[1].Split(','), int.Parse);
Problems problems = new Problems();

var p = problems.PathSum(root, k);

Console.WriteLine(p);