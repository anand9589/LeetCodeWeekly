using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace December22
{
    public class Solution
    {
        #region Day 1 Problem 1704. Determine if String Halves Are Alike
        public bool HalvesAreAlike(string s)
        {
            int count = 0;
            HashSet<char> vowels = new HashSet<char> { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };

            int low = 0;
            int high = s.Length - 1;

            while (low < high)
            {
                if (vowels.Contains(s[low]))
                {
                    count++;
                }
                if (vowels.Contains(s[high]))
                {
                    count--;
                }
                low++;
                high--;
            }

            return count == 0;
        }
        #endregion

        #region Day 2 Problem 1657. Determine if Two Strings Are Close
        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;

            int[] arr1 = new int[26];
            int[] arr2 = new int[26];

            int index = 0;
            while (index < word1.Length)
            {
                arr1[word1[index] - 'a']++;
                arr2[word2[index] - 'a']++;

                index++;
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                if ((arr1[i] == 0 && arr2[i] != 0) || (arr2[i] == 0 && arr1[i] != 0)) return false;
            }

            Array.Sort(arr1);
            Array.Sort(arr2);

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }

            return true;
        }

        public bool CloseStrings_V1(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;

            SortedDictionary<char, int> word1Map = new SortedDictionary<char, int>();
            SortedDictionary<char, int> word2Map = new SortedDictionary<char, int>();

            int i = 0;

            while (i < word1.Length)
            {
                if (!word1Map.ContainsKey(word1[i]))
                {
                    word1Map.Add(word1[i], 0);
                }
                word1Map[word1[i]]++;

                if (!word2Map.ContainsKey(word2[i]))
                {
                    word2Map.Add(word2[i], 0);
                }
                word2Map[word2[i]]++;

                i++;
            }

            foreach (var key in word1Map.Keys)
            {
                if (!word2Map.ContainsKey(key)) return false;
                var k = word2Map.Keys.FirstOrDefault(x => word2Map[x] == word1Map[key]);

                if (k == '\0') return false;

                word2Map[k] = -1;
            }

            return true;
        }
        #endregion

        #region Day 3 Problem 451. Sort Characters By Frequency
        public string FrequencySort(string s)
        {
            Dictionary<char, int> word1Map = new Dictionary<char, int>();
            int index = 0;

            while (index < s.Length)
            {
                if (!word1Map.ContainsKey(s[index]))
                {
                    word1Map.Add(s[index], 0);
                }
                word1Map[s[index]]++;
                index++;
            }

            word1Map = word1Map.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (char key in word1Map.Keys)
            {
                for (int i = 0; i < word1Map[key]; i++)
                {
                    stringBuilder.Append(key);
                }
            }



            return stringBuilder.ToString();
        }
        #endregion

        #region Day 4 Problem 2256. Minimum Average Difference
        public int MinimumAverageDifference(int[] nums)
        {
            int result = int.MaxValue;
            int index = -1;
            int[] arr = new int[nums.Length];
            long sum = nums.Sum(x => (long)x);
            long num1 = 0;
            long num2 = sum;
            int n = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                num1 += nums[i];
                num2 -= nums[i];
                arr[i] = (int)Math.Abs(num1 / (i + 1) - (num2 > 0 ? num2 / (n - i - 1) : 0));
                if (result > arr[i])
                {
                    result = arr[i];
                    index = i;
                }
            }
            return index;
        }


        #endregion

        #region Day 5 Problem 876. Middle of the Linked List
        public ListNode MiddleNode(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;

            while (fast != null)
            {
                if (fast.next == null)
                {
                    return slow;
                }
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }
        #endregion

        #region Day 6 Problem 328. Odd Even Linked List
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return head;
            ListNode resultNode = new ListNode(-1);
            ListNode temp = resultNode;
            ListNode oddNode = head;
            temp.next = oddNode;
            ListNode evenNode = head.next;

            ListNode temp1 = oddNode;
            ListNode temp2 = evenNode;
            ListNode lastOddNode = oddNode;
            while (temp1 != null && temp2 != null)
            {
                temp1.next = temp2.next;
                temp1 = temp1.next;
                if (temp1 != null)
                {
                    temp2.next = temp1.next;
                    temp2 = temp2.next;
                    lastOddNode = temp1;
                }

            }
            if (temp1 != null)
            {
                temp1.next = evenNode;
            }
            if (temp2 != null)
            {
                lastOddNode.next = evenNode;
            }
            return resultNode.next;
        }

        public ListNode OddEvenList_V1(ListNode head)
        {
            if (head == null) return head;
            List<int> list = new List<int>();
            ListNode resultNode = new ListNode(-1);
            ListNode temp = resultNode;
            while (head != null)
            {
                list.Add(head.val);
                head = head.next;
            }

            for (int i = 0; i < list.Count; i = i + 2)
            {
                temp.next = new ListNode(list[i]);
                temp = temp.next;
            }

            for (int i = 1; i < list.Count; i = i + 2)
            {
                temp.next = new ListNode(list[i]);
                temp = temp.next;
            }
            return resultNode.next;
        }
        #endregion

        #region Day 7 Problem 938. Range Sum of BST
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null) return 0;

            if (root.val < low) return RangeSumBST(root.right, low, high);

            if (root.val > high) return RangeSumBST(root.left, low, high);

            int result = 0;

            if (root.val <= high && root.val >= low)
            {
                result += root.val;
            }

            return result + RangeSumBST(root.left, low, high) + RangeSumBST(root.right, low, high);
        }
        #endregion

        #region Day 8 Problem 872. Leaf-Similar Trees
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            Queue<int> list = new Queue<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            stack.Push(root1);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();

                if (node.left == null && node.right == null)
                {
                    list.Enqueue(node.val);
                    continue;
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
            }

            stack.Push(root2);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();

                if (node.left == null && node.right == null)
                {
                    if (list.Count == 0 || list.Dequeue() != node.val) return false;
                    continue;
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
            }

            return list.Count == 0;
        }
        #endregion

        #region Day 9 Problem 1026. Maximum Difference Between Node and Ancestor
        int MaxAncestorDiffResult = 0;
        public int MaxAncestorDiff(TreeNode root)
        {
            if (root != null)
            {
                MaxAncestorDiff_Helper(root);
            }

            return MaxAncestorDiffResult;
        }

        private (int min, int max) MaxAncestorDiff_Helper(TreeNode root)
        {
            if (root == null) return (int.MaxValue, int.MinValue);

            if (root.left == null && root.right == null) return (root.val, root.val);

            (int min, int max) left = MaxAncestorDiff_Helper(root.left);
            (int min, int max) right = MaxAncestorDiff_Helper(root.right);

            int mi = Math.Min(left.min, right.min);
            int ma = Math.Max(left.max, right.max);

            MaxAncestorDiffResult = Math.Max(MaxAncestorDiffResult, Math.Max(Math.Abs(root.val - mi), Math.Abs(root.val - ma)));

            mi = Math.Min(mi, root.val);
            ma = Math.Max(ma, root.val);
            return (mi, ma);
        }

        #endregion

        #region Day 10 Problem 1339. Maximum Product of Splitted Binary Tree
        public int MaxProduct(TreeNode root)
        {
            IList<long> list = new List<long>();

            if (root == null) return 0;

            long rootSum = totalSum(root, list);

            list.Remove(rootSum);
            long result = 0;
            foreach (long val in list)
            {

                result = Math.Max((rootSum - val) * val, result);
            }
            return (int)(result % 1000000007);
        }

        private long totalSum(TreeNode root, IList<long> list)
        {
            if (root == null) return 0;

            long sum = root.val + totalSum(root.left, list) + totalSum(root.right, list);
            list.Add(sum);
            return sum;

        }


        #endregion

        #region Day 11 Problem
        #endregion

        #region Day 12 Problem
        #endregion

        #region Day 13 Problem
        #endregion

        #region Day 14 Problem
        #endregion

        #region Day 15 Problem
        #endregion

        #region Day 16 Problem
        #endregion

        #region Day 17 Problem
        #endregion

        #region Day 18 Problem
        #endregion

        #region Day 19 Problem
        #endregion

        #region Day 20 Problem
        #endregion

        #region Day 21 Problem
        #endregion

        #region Day 22 Problem
        #endregion

        #region Day 23 Problem
        #endregion

        #region Day 24 Problem
        #endregion

        #region Day 25 Problem
        #endregion

        #region Day 26 Problem
        #endregion

        #region Day 27 Problem
        #endregion

        #region Day 28 Problem
        #endregion

        #region Day 29 Problem
        #endregion

        #region Day 30 Problem
        #endregion

        #region Day 31 Problem
        #endregion

        #region Problem 2478. Number of Beautiful Partitions

        private const int mod = 1_000_000_007;

        private ISet<char> prime;

        public int BeautifulPartitions(string s, int k, int minLength)
        {
            int n = s.Length;

            prime = new HashSet<char>
        {
            '2',
            '3',
            '5',
            '7'
        };

            int[,] dp = new int[k + 1, n];
            int[,] suffix = new int[k + 1, n];

            minLength = Math.Max(2, minLength);

            int prev = 0;
            for (int f = n - 2; f >= 0; f--)
            {
                if (prime.Contains(s[f]) && !prime.Contains(s[n - 1]) && n - f >= minLength)
                {
                    dp[1, f] = 1;
                }

                if (f == 0 || !prime.Contains(s[f - 1]))
                {
                    prev = (dp[1, f] + prev) % mod;
                }
                suffix[1, f] = prev;
            }

            Console.WriteLine("DP");
            ArrayPrint(dp, k + 1);
            Console.WriteLine();
            Console.WriteLine("SUFFIX");
            ArrayPrint(suffix, k + 1);
            int start;
            int end;
            for (int i = 2; i <= k; i++)
            {
                prev = 0;
                for (int f = n - 2; f >= 0; f--)
                {
                    start = Math.Min(n - 1, f + minLength);
                    end = n - (i - 2) * minLength;

                    if (prime.Contains(s[f]) && start < end)
                    {
                        dp[i, f] = (dp[i, f] + suffix[i - 1, start]) % mod;
                        if (end < n)
                        {
                            dp[i, f] = (dp[i, f] - suffix[i - 1, end]) % mod;
                        }
                    }

                    if (f == 0 || !prime.Contains(s[f - 1]))
                    {
                        prev = (dp[i, f] + prev) % mod;
                    }
                    suffix[i, f] = prev;
                }
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("DP");
                ArrayPrint(dp, k + 1);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("SUFFIX");
                ArrayPrint(suffix, k + 1);
            }

            return dp[k, 0];
        }

        private void ArrayPrint(int[,] dp, int partitions)
        {
            int p = dp.Length / partitions;
            int cnt = 0;
            foreach (var item in dp)
            {
                if (cnt == p) { Console.WriteLine(); cnt = 0; }

                Console.Write(item + " ");
                cnt++;
            }

            Console.WriteLine();
        }

        #endregion

        #region Weekly 322
        public bool IsCircularSentence(string sentence)
        {
            string[] strs = sentence.Split(' ');


            for (int i = 0; i < strs.Length; i++)
            {
                if (i == strs.Length - 1)
                {
                    return strs[0][0] == strs[i][strs[i].Length - 1];
                }
                else
                {
                    if (strs[i][strs[i].Length - 1] != strs[i + 1][0]) return false;
                }
            }
            return true;
        }

        public long DividePlayers(int[] skill)
        {
            long result = 0;
            return result;
        }
        #endregion
    }
}
