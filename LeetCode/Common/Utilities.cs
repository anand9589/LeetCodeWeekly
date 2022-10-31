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
            TreeNode root = null;

            if (index < arr.Length && arr[index] != null)
            {
                root = new TreeNode((int)arr[index], BuildTreeNode(arr, 2 * index + 1), BuildTreeNode(arr, 2 * index + 2));
            }

            return root;
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

        public static int[][] Get2DArray(string path)
        {
            string s = File.ReadAllText(path);

            s = s.TrimStart('[');
            s = s.TrimEnd(']');

            string[] arr = s.Split("],[");

            int[][] arr2 = new int[arr.Length][];

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = Array.ConvertAll(arr[i].Split(','), int.Parse);
            }

            return arr2;
        }
    }
}
