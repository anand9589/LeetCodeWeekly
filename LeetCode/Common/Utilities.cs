namespace Common
{
    public static class Utilities
    {
        public static ListNode BuildListNode(int[] arr)
        {
            ListNode dummyNode = new ListNode(0, null);
            ListNode temp = dummyNode;
            for (int i = 0; i < arr.Length; i++)
            {
                temp.next = new ListNode(arr[i]);
                temp = temp.next;
            }

            return dummyNode.next;
        }

        public static TreeNode BuildTreeNode(int?[] arr, int index = 0)
        {

            if (index >= arr.Length || arr[index] == null) return null;

            return new TreeNode((int)arr[index], BuildTreeNode(arr, (2 * index) + 1), BuildTreeNode(arr, (2 * index) + 2));

        }

        public static int[] GetArray(string path = @"C:\Users\anand\source\repos\Leetcode2023\Leetcode2023\Testcase.txt")
        {
            string[] str = File.ReadAllLines(path);

            int[] arr = Array.ConvertAll(str[0].Trim('[').Trim(']').Split(','), int.Parse);

            return arr;
        }

        public static TreeNode BuildTreeNode(int[] arr, int index = 0)
        {
            TreeNode root = null;

            if (index < arr.Length)
            {
                root = new TreeNode((int)arr[index], BuildTreeNode(arr, 2 * index + 1), BuildTreeNode(arr, 2 * index + 2));
            }

            return root;
        }



        public static TreeNode BuildTreeNode(string path = @"C:\Users\anand\source\repos\Leetcode2023\Leetcode2023\Testcase.txt")
        {
            string[] s = File.ReadAllText(path).Trim('[', ']').Split(",");
            int?[] arr = new int?[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != "null")
                {
                    arr[i] = int.Parse(s[i]);
                }
            }

            return BuildTreeNode(arr);
        }

        public static int[][] Get2DArray(string path = @"C:\Users\anand\source\repos\Leetcode2023\Leetcode2023\Testcase.txt")
        {
            string[] strs = File.ReadAllLines(path);
            string s = strs[0];
            s = s.TrimStart('[');
            s = s.TrimEnd(']');

            string[] arr = s.Split("],[");

            int[][] arr2 = new int[arr.Length][];

            for (int i = 0; i < arr2.Length; i++)
            {
                if (string.IsNullOrEmpty(arr[i]))
                {
                    arr2[i] = new int[0];
                }
                else
                {
                    arr2[i] = Array.ConvertAll(arr[i].Split(','), int.Parse);
                }
            }

            return arr2;
        }

        public static int[] GetIntArray(string path = @"C:\Users\anand\source\repos\LeetCodeWeekly\LeetCode\LeetCode\Testcase.txt")
        {
            string s = File.ReadAllText(path);

            s = s.TrimStart('[');
            s = s.TrimEnd(']');

            string[] arr = s.Split(",");

            return Array.ConvertAll(arr, int.Parse);
        }

        public static char[][] Get2DCharArray(string path = @"C:\Users\anand\source\repos\LeetCodeWeekly\LeetCode\LeetCode\Testcase.txt")
        {
            string[] arr = getArray(path);

            char[][] arr2 = new char[arr.Length][];

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = Array.ConvertAll(arr[i].Split(','), char.Parse);
            }

            return arr2;
        }

        private static string[] getArray(string path)
        {
            string s = File.ReadAllText(path);

            s = s.TrimStart('[');
            s = s.TrimEnd(']');
            s = s.Replace("\"", "");
            string[] arr = s.Split("],[");
            return arr;
        }

        public static IList<IList<string>> GetListofListofString(string path = @"C:\Users\anand\source\repos\Leetcode2023\Leetcode2023\Testcase.txt")
        {
            IList<IList<string>> list = new List<IList<string>>();

            string[] arr = getArray(path);

            foreach (string str in arr)
            {
                list.Add(new List<string>(str.Split(",")));
            }

            return list;
        }

        //public static string[] GetStringArray(string path, int lineIndex = 0)
        //{
        //    string s = File.ReadAllText(path);

        //}
    }
}