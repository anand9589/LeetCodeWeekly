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

        #region Day 11 Problem 124. Binary Tree Maximum Path Sum
        int sum_124 = 0;
        public int MaxPathSum(TreeNode root)
        {
            sum_124 = int.MinValue;

            maxSumFromSubtree(root);

            return sum_124;
        }

        private int maxSumFromSubtree(TreeNode root)
        {
            if (root == null) return 0;

            int leftMaxSum = Math.Max(maxSumFromSubtree(root.left), 0);
            int rightMaxSum = Math.Max(maxSumFromSubtree(root.right), 0);

            sum_124 = Math.Max(sum_124, leftMaxSum + rightMaxSum + root.val);

            return Math.Max(leftMaxSum, rightMaxSum) + root.val;
        }
        #endregion

        #region Day 12 Problem 70. Climbing Stairs
        public int ClimbStairs(int n)
        {
            int[] dp = new int[n + 2];
            dp[1] = 1;

            for (int i = 2; i <= n + 1; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n + 1];
        }
        #endregion

        #region Day 13 Problem 931. Minimum Falling Path Sum
        public int MinFallingPathSum(int[][] matrix)
        {
            int n = matrix.Length;
            int result = int.MaxValue;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int min = matrix[i - 1][j];

                    if (j - 1 >= 0 && min > matrix[i - 1][j - 1])
                    {
                        min = matrix[i - 1][j - 1];
                    }

                    if (j + 1 < n && min > matrix[i - 1][j + 1])
                    {
                        min = matrix[i - 1][j + 1];
                    }
                    matrix[i][j] += min;
                }
            }
            return matrix[n - 1].Min();
        }
        #endregion

        #region Day 14 Problem 198. House Robber
        public int Rob(int[] nums)
        {

            if (nums.Length <= 2) return nums.Max();

            nums[2] += nums[0];

            for (int i = 3; i < nums.Length; i++)
            {
                int prev = Math.Max(nums[i - 2], nums[i - 3]);
                nums[i] += prev;
            }
            return nums[nums.Length - 1];
        }
        #endregion

        #region Day 15 Problem 1143. Longest Common Subsequence
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int[][] dp = new int[text1.Length + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[text2.Length + 1];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    if (i == 0 || j == 0) continue;

                    if (text1[i] == text2[j])
                    {
                        dp[i][j] = 1 + dp[i - 1][j - 1];
                    }
                    else
                    {
                        dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                    }
                }
            }

            return dp[text1.Length][text2.Length];
        }
        #endregion

        #region Day 16 Problem 232. Implement Queue using Stacks
        public class MyQueue
        {
            Stack<int> stack1, stack2;
            public MyQueue()
            {
                stack1 = new Stack<int>();
                stack2 = new Stack<int>();
            }

            public void Push(int x)
            {
                stack1.Push(x);
            }

            public int Pop()
            {
                int res = temp();

                while (stack2.Count > 0)
                {
                    stack1.Push(stack2.Pop());
                }
                return res;
            }

            public int Peek()
            {
                int res = temp();
                stack1.Push(res);
                while (stack2.Count > 0)
                {
                    stack1.Push(stack2.Pop());
                }
                return res;
            }

            public bool Empty()
            {
                return stack1.Count == 0 && stack2.Count == 0;
            }

            private int temp()
            {
                while (stack1.Count > 1)
                {
                    stack2.Push(stack1.Pop());
                }

                int res = stack1.Pop();
                return res;
            }
        }

        public class MyQueue_V1
        {
            Stack<int> stack1, stack2;
            public MyQueue_V1()
            {
                stack1 = new Stack<int>();
                stack2 = new Stack<int>();
            }

            public void Push(int x)
            {
                stack1.Push(x);
            }

            public int Pop()
            {
                int res = temp();

                while (stack2.Count > 0)
                {
                    stack1.Push(stack2.Pop());
                }
                return res;
            }

            public int Peek()
            {
                int res = temp();
                stack1.Push(res);
                while (stack2.Count > 0)
                {
                    stack1.Push(stack2.Pop());
                }
                return res;
            }

            public bool Empty()
            {
                return stack1.Count == 0 && stack2.Count == 0;
            }

            private int temp()
            {
                while (stack1.Count > 1)
                {
                    stack2.Push(stack1.Pop());
                }

                int res = stack1.Pop();
                return res;
            }
        }
        #endregion

        #region Day 17 Problem 150. Evaluate Reverse Polish Notation
        public int EvalRPN(string[] tokens)
        {
            int result = 0;

            Stack<string> stack = new Stack<string>();

            foreach (string token in tokens)
            {
                stack.Push(token);
            }
            string s = stack.Peek();

            if (int.TryParse(s, out int num))
            {
                return num;
            }
            result = calculeteRPN(stack);
            return result;
        }

        private int calculeteRPN(Stack<string> stack)
        {
            int num1 = int.MinValue, num2 = int.MinValue;
            char op = stack.Pop()[0];

            if (int.TryParse(stack.Peek(), out num1))
            {
                stack.Pop();
            }
            else
            {
                num1 = calculeteRPN(stack);
            }

            if (int.TryParse(stack.Peek(), out num2))
            {
                stack.Pop();
            }
            else
            {
                num2 = calculeteRPN(stack);
            }

            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num2 - num1;
                case '/':
                    return num2 / num1;
                case '*':
                    return num1 * num2;
                default:
                    return 0;
            }
        }
        #endregion

        #region Day 18 Problem 739. Daily Temperatures
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] res = new int[temperatures.Length];
            Stack<int> stack = new Stack<int>();
            //stack.Push(res.Length-1);
            //res[res.Length - 1] = 0;
            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && temperatures[stack.Peek()] <= temperatures[i])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    res[i] = 0;
                }
                else
                {
                    res[i] = stack.Peek() - i;
                }
                stack.Push(i);

            }
            return res;
        }
        #endregion

        #region Day 19 Problem 1971. Find if Path Exists in Graph
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            if (source == destination) return true;
            bool[] visited = new bool[n];
            Dictionary<int, IList<int>> path = new Dictionary<int, IList<int>>();
            for (int i = 0; i < edges.Length; i++)
            {
                addToPath(edges[i][0], edges[i][1], path);
                addToPath(edges[i][1], edges[i][0], path);
            }
            Stack<int> stack = new Stack<int>();
            stack.Push(source);

            while (stack.Count > 0)
            {
                int u = stack.Pop();
                visited[u] = true;
                if (path.ContainsKey(u))
                {
                    foreach (var item in path[u])
                    {
                        if (!visited[item])
                        {
                            if (item == destination) return true;
                            stack.Push((int)item);
                        }
                    }
                }
            }
            return false;
        }

        private static void addToPath(int v, int u, Dictionary<int, IList<int>> path)
        {
            if (!path.ContainsKey(v))
            {
                path.Add(v, new List<int>());
            }
            path[v].Add(u);
        }
        #endregion

        #region Day 20 Problem 841. Keys and Rooms
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            bool[] visited = new bool[rooms.Count];

            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int room = stack.Pop();
                visited[room] = true;
                foreach (int r in rooms[room])
                {
                    if (!visited[r]) stack.Push(r);
                }
            }

            return !visited.Any(x => !x);
        }
        #endregion

        #region Day 21 Problem 886. Possible Bipartition
        public bool PossibleBipartition(int n, int[][] dislikes)
        {
            IDictionary<int, IList<int>> dislikemap = new Dictionary<int, IList<int>>();
            bool[] visited = new bool[n + 1];
            for (int i = 1; i <= n; i++)
            {
                dislikemap.Add(i, new List<int>());
            }

            foreach (int[] dislike in dislikes)
            {
                dislikemap[dislike[0]].Add(dislike[1]);
            }

            dislikemap = dislikemap.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            List<int> group1 = new List<int>();
            List<int> group2 = new List<int>();
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();

            var d = dislikemap.Keys.FirstOrDefault();

            stack1.Push(d);

            while (stack1.Count > 0 || stack2.Count > 0)
            {
                if (stack2.Count == 0)
                {
                    while (stack1.Count > 0)
                    {
                        int k = stack1.Pop();
                        if (group2.Contains(k)) return false;
                        visited[k] = true;
                        group1.Add(k);
                        foreach (var val in dislikemap[k])
                        {
                            if (group1.Contains(val)) return false;
                            if (!visited[val]) stack2.Push(val);
                        }
                    }
                }
                else
                {
                    while (stack2.Count > 0)
                    {
                        int r = stack2.Pop();

                        if (group1.Contains(r)) return false;
                        visited[r] = true;

                        group2.Add(r);
                        foreach (var val in dislikemap[r])
                        {
                            if (group2.Contains(val)) return false;
                            if (!visited[val]) stack1.Push(val);
                        }
                    }
                }
            }

            return true;
        }

        private bool addtogroup(IList<int> values, List<int> group)
        {
            foreach (var val in values)
            {
                if (group.Contains(val)) return false;

                group.Add(val);
            }
            return true;
        }
        #endregion

        #region Day 22 Problem 834. Sum of Distances in Tree
        int[] ans_834, count_834;
        IList<HashSet<int>> graph_834;
        int n_834;
        public int[] SumOfDistancesInTree(int n, int[][] edges)
        {
            this.n_834 = n;

            this.graph_834 = new List<HashSet<int>>();
            ans_834 = new int[n];
            count_834 = Enumerable.Repeat(1, n).ToArray();

            for (int i = 0; i < n_834; i++)
            {
                graph_834.Add(new HashSet<int>());
            }

            foreach (int[] edge in edges)
            {
                graph_834[edge[0]].Add(edge[1]);
                graph_834[edge[1]].Add(edge[0]);
            }

            dfs_834_1(0, -1);
            dfs_834_2(0, -1);
            return ans_834;
        }

        private void dfs_834_1(int node, int parent)
        {
            foreach (int val in graph_834[node])
            {
                if (val != parent)
                {
                    dfs_834_1(val, node);
                    count_834[node] += count_834[val];
                    ans_834[node] += ans_834[val] + count_834[val];
                }
            }
        }

        private void dfs_834_2(int node, int parent)
        {
            foreach (int val in graph_834[node])
            {
                if (val != parent)
                {
                    ans_834[val] = ans_834[node] - count_834[val] + n_834 - count_834[val];
                    dfs_834_2(val, node);
                }
            }
        }

        public int[] SumOfDistancesInTree_V1(int n, int[][] edges)
        {
            int[] result = new int[n];
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        dp[i][j] = 0;
                    }
                    else
                    {
                        dp[i][j] = int.MaxValue;
                    }
                }
            }
            Queue<(int, int, int)> q = new Queue<(int, int, int)>();
            foreach (int[] edge in edges)
            {
                dp[edge[0]][edge[1]] = 1;
                dp[edge[1]][edge[0]] = 1;

                q.Enqueue((edge[0], edge[1], 1));
                //q.Enqueue((edge[1], edge[0], 1));
            }


            while (q.Count > 0)
            {
                (int v, int u, int w) = q.Dequeue();


                for (int i = 0; i < n; i++)
                {
                    if (i == u || i == v) continue;
                    //long vv = w;
                    //vv += dp[u][i];

                    //if (vv > int.MaxValue) continue;
                    NewMethod(dp, q, v, u, w, i);
                    NewMethod(dp, q, u, v, w, i);

                    //if (dp[v][i] != int.MaxValue)
                    //{
                    //    if (dp[u][i] > w + dp[v][i])
                    //    {
                    //        dp[v][i] = w + dp[u][i];
                    //        dp[i][v] = w + dp[u][i];

                    //        q.Enqueue((v, i, w + dp[u][i]));
                    //        //q.Enqueue((i, v, w + dp[u][i]));
                    //    }
                    //}

                }

                for (int i = 0; i < n; i++)
                {

                }
            }

            for (int i = 0; i < n; i++)
            {
                result[i] = dp[i].Sum();
            }
            return result;
        }

        private static void NewMethod(int[][] dp, Queue<(int, int, int)> q, int v, int u, int w, int i)
        {
            if (dp[u][i] != int.MaxValue)
            {
                if (dp[v][i] > w + dp[u][i])
                {
                    dp[v][i] = w + dp[u][i];
                    dp[i][v] = w + dp[u][i];

                    q.Enqueue((v, i, w + dp[u][i]));
                    //q.Enqueue((i, v, w + dp[u][i]));
                }
            }
        }

        private void helper(int[][] dp, int i, int j, int k)
        {
            if (dp[i][k] < dp[i][j] + dp[j][k])
            {
                dp[i][k] = dp[i][j] + dp[j][k];
                dp[k][i] = dp[i][j] + dp[j][k];

                Stack<(int, int)> stack = new Stack<(int, int)>();

                stack.Push((i, k));

                while (stack.Count > 0)
                {
                    var p = stack.Pop();
                }
            }
        }
        #endregion

        #region Day 23 Problem 309. Best Time to Buy and Sell Stock with Cooldown
        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2) return 0;

            int[] buy = new int[prices.Length];
            int[] sell = new int[prices.Length];

            buy[0] = -prices[0];
            sell[0] = 0;

            Console.WriteLine(string.Join(" ", buy));
            Console.WriteLine(string.Join(" ", sell));
            Console.WriteLine();
            for (int i = 1; i < prices.Length; i++)
            {
                buy[i] = Math.Max(buy[i - 1], i > 1 ? sell[i - 2] - prices[i] : -prices[i]);
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);
                Console.WriteLine(string.Join(" ", buy));
                Console.WriteLine(string.Join(" ", sell));
                Console.WriteLine();
            }
            return sell[prices.Length - 1];
        }
        #endregion

        #region Day 24 Problem 790. Domino and Tromino Tiling
        public int NumTilings_V1(int n)
        {
            if (n <= 1) return n;
            int mod = 1000000007;
            int[,] dp = new int[n, 2];

            dp[0, 0] = 1;
            dp[0, 1] = 0;

            dp[1, 0] = 2;
            dp[1, 1] = 1;

            for (int i = 2; i < n; i++)
            {
                dp[i, 0] = (dp[i - 1, 0] + dp[i - 2, 0] + 2 * dp[i - 1, 1]) % mod;
                dp[i, 1] = (dp[i - 2, 0] + dp[i - 1, 1]) % mod;
            }

            return dp[n - 1, 0];
        }

        public int NumTilings(int n)
        {
            var dp = new long[n, 3];
            var mod = 1_000_000_007;
            dp[0, 0] = 1; // full
            dp[0, 1] = 0; // top half empty in the last column
            dp[0, 2] = 0; // bottom half empty in the last column

            dp[1, 0] = 2; // full
            dp[1, 1] = 1; // top half empty in the last column
            dp[1, 2] = 1; // bottom half empty in the last column

            for (int i = 2; i < n; i++)
            {
                dp[i, 0] = (dp[i - 2, 0] + dp[i - 1, 0] + dp[i - 1, 1] + dp[i - 1, 2]) % mod; // full
                dp[i, 1] = (dp[i - 2, 0] + dp[i - 1, 2]) % mod;// top half empty in the last column
                dp[i, 2] = (dp[i - 2, 0] + dp[i - 1, 1]) % mod;// bottom half empty in the last column
            }

            return (int)dp[n - 1, 0];
        }

        #endregion

        #region Day 25 Problem 2389. Longest Subsequence With Limited Sum
        public int[] AnswerQueries(int[] nums, int[] queries)
        {
            Array.Sort(nums);

            int n = queries.Length;
            int[] result = new int[n];

            int[] prefixsum = new int[nums.Length];
            prefixsum[0] = nums[0];
            for (int i = 1; i < prefixsum.Length; i++)
            {
                prefixsum[i] = prefixsum[i - 1] + nums[i];
            }


            for (int i = 0; i < n; i++)
            {
                int k = binarySearch(prefixsum, queries[i]);
                result[i] = k + 1;
            }

            return result;
        }

        private int binarySearch(int[] arr, int target)
        {
            int result = 0;
            int low = 0;
            int high = arr.Length - 1;
            while (low <= high)
            {
                if (arr[low] == target) return low;

                if (arr[low] > target) return low - 1;

                if (arr[high] == target || arr[high] < target) return high;

                int mid = (low + high) / 2;

                if (arr[mid] == target) return mid;

                if (arr[mid] < target)
                {
                    if (mid + 1 < arr.Length && arr[mid + 1] > target) return mid;
                    low = mid + 1;
                }
                else
                {
                    if (mid - 1 >= 0 && arr[mid - 1] < target) return mid;
                    high = mid - 1;
                }
            }

            return result;
        }
        #endregion

        #region Day 26 Problem  55. Jump Game   
        public bool CanJump(int[] nums)
        {
            int n = nums.Length;
            bool[] visited = new bool[n];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int i = stack.Pop();

                visited[i] = true;

                int val = nums[i];


            }

            return false;
        }
        #endregion

        #region Day 27 Problem 2279. Maximum Bags With Full Capacity of Rocks
        public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks)
        {
            //List<(int, int)> bags = new List<(int, int)>();

            List<int> result = new List<int>();

            for (int i = 0; i < rocks.Length; i++)
            {
                int rem = capacity[i] - rocks[i];
                if (rem > 0) result.Add(capacity[i] - rocks[i]);
            }

            result = result.OrderBy(x => x).ToList();

            int fullbags = rocks.Length - result.Count;

            while (additionalRocks > 0 && result.Count > 0)
            {

                int v = result[0];

                result.RemoveAt(0);

                if (v <= additionalRocks)
                {
                    additionalRocks -= v;
                    fullbags++;
                }
            }

            return fullbags;
        }
        #endregion

        #region Day 28 Problem 1962. Remove Stones to Minimize the Total
        public int MinStoneSum(int[] piles, int k)
        {
            int lastIndex = piles.Length - 1;
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>(new IntMaxComparer());
            int total = 0;
            for (int i = 0; i < piles.Length; i++)
            {
                queue.Enqueue(piles[i], piles[i]);
                total += piles[i];
            }

            while (k > 0)
            {
                var p = queue.Dequeue();
                int sub = p / 2;
                p = p - sub;
                queue.Enqueue(p, p);
                total -= sub;
                k--;
            }


            return total;
        }

        public class IntMaxComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x < y) return 1;
                if (x > y) return -1;
                return 0;
            }

        }
        #endregion

        #region Day 29 Problem 1834. Single-Threaded CPU
        public int[] GetOrder(int[][] tasks)
        {
            int[][] tasks1 = new int[tasks.Length][];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks1[i] = new int[] { tasks[i][0], tasks[i][1], i };
            }
            Array.Sort(tasks1, (x, y) => x[1] - y[1]);
            Array.Sort(tasks1, (x, y) => x[0] - y[0]);
            PriorityQueue<(int x, int y, int index), (int x, int y, int index)> queue = new PriorityQueue<(int x, int y, int index), (int x, int y, int index)>(new IntIntComaprer());

            int[] result = new int[tasks.Length];
            int counterIndex = tasks1[0][0];
            int processIndex = 0;
            int[] task = tasks1[0];
            queue.Enqueue((task[0], task[1], task[2]), (task[0], task[1], task[2]));
            int tasksprocessIndex = 1;
            int temp = task[0];
            while (tasksprocessIndex < tasks.Length && tasks1[tasksprocessIndex][0] <= temp)
            {
                task = tasks1[tasksprocessIndex];
                queue.Enqueue((task[0], task[1], task[2]), (task[0], task[1], task[2]));
                tasksprocessIndex++;
            }
            while (processIndex < result.Length)
            {
                if (queue.Count == 0)
                {
                    task = tasks1[tasksprocessIndex];
                    temp = task[0];
                    queue.Enqueue((task[0], task[1], task[2]), (task[0], task[1], task[2]));
                    tasksprocessIndex++;
                    counterIndex = temp;
                    while (tasksprocessIndex < tasks.Length && tasks1[tasksprocessIndex][0] <= temp)
                    {
                        task = tasks1[tasksprocessIndex];
                        queue.Enqueue((task[0], task[1], task[2]), (task[0], task[1], task[2]));
                        tasksprocessIndex++;
                    }
                }
                var p = queue.Dequeue();
                result[processIndex] = p.index;
                counterIndex += p.y;

                while (tasksprocessIndex < tasks.Length && tasks1[tasksprocessIndex][0] <= counterIndex)
                {
                    task = tasks1[tasksprocessIndex];
                    queue.Enqueue((task[0], task[1], task[2]), (task[0], task[1], task[2]));
                    tasksprocessIndex++;
                }
                processIndex++;
            }
            return result;
        }

        public class IntIntComaprer : IComparer<(int x, int y, int index)>
        {
            public int Compare((int x, int y, int index) x, (int x, int y, int index) y)
            {

                if (x.y > y.y) return 1;
                if (x.y < y.y) return -1;

                if (x.index > y.index) return 1;
                if (x.index < y.index) return -1;

                if (x.x > y.x) return 1;
                if (x.x < y.x) return -1;

                return 0;
            }
        }
        #endregion

        #region Day 30 Problem 797. All Paths From Source to Target
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            IList<IList<int>> result = new List<IList<int>>();

            int lastNode = graph.Length - 1;

            Stack<IList<int>> stack = new Stack<IList<int>>();
            foreach (int node in graph[0])
            {
                stack.Push(new List<int>() { 0, node });
            }

            while (stack.Count > 0)
            {

                var nodeList = stack.Pop();

                int lastNodeVal = nodeList.Last();

                if (lastNodeVal == lastNode)
                {
                    result.Add(nodeList);
                }
                else
                {
                    foreach (var node in graph[lastNodeVal])
                    {
                        IList<int> list = new List<int>(nodeList);
                        list.Add(node);
                        stack.Push(list);
                    }
                }
            }
            return result;
        }
        public IList<IList<int>> AllPathsSourceTarget_V1(int[][] graph)
        {
            IList<IList<int>> result = new List<IList<int>>();

            int lastNode = graph.Length - 1;

            Queue<IList<int>> queue = new Queue<IList<int>>();
            foreach (int node in graph[0])
            {
                queue.Enqueue(new List<int>() { 0, node });
            }

            while (queue.Count > 0)
            {
                var nodeList = queue.Dequeue();

                int lastNodeVal = nodeList.Last();

                if (lastNodeVal == lastNode)
                {
                    result.Add(nodeList);
                }
                else
                {
                    foreach (var node in graph[lastNodeVal])
                    {
                        IList<int> list = new List<int>(nodeList);
                        list.Add(node);
                        queue.Enqueue(list);
                    }
                }
            }
            return result;
        }
        #endregion

        #region Day 31 Problem 980. Unique Paths III
        public int UniquePathsIII(int[][] grid)
        {
            int zero = 0, x = 0, y = 0, m = grid.Length, n = grid[0].Length;

            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (grid[r][c] == 0)
                    {
                        zero++;
                    }
                    else if (grid[r][c] == 1)
                    {
                        x = r;
                        y = c;
                    }
                }
            }

            return dfs_980(grid, x, y, zero);
        }

        private int dfs_980(int[][] grid, int x, int y, int zero)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[x].Length || grid[x][y] == -1) return 0;

            if (grid[x][y] == 2)
            {
                return zero == -1 ? 1 : 0;
            }

            grid[x][y] = -1;

            zero--;

            int uniquePaths = dfs_980(grid, x + 1, y, zero) +
                dfs_980(grid, x - 1, y, zero) +
                dfs_980(grid, x, y - 1, zero) +
                dfs_980(grid, x, y + 1, zero);

            grid[x][y] = 0;
            zero++;
            return uniquePaths;
        }
        #endregion

        #region Problem 130. Surrounded Regions

        public void Solve(char[][] board)
        {
            int m = board.Length;
            int n = board[0].Length;
            bool[][] visited = new bool[m][];

            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            for (int i = 0; i < m; i++)
            {
                if (board[i][0] == 'O' && !visited[i][0])
                {
                    solve_130(board, visited, i, 0);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (board[0][i] == 'O' && !visited[0][i])
                {
                    solve_130(board, visited, 0, i);
                }
            }

            for (int i = 0; i < m; i++)
            {
                if (board[i][n - 1] == 'O' && !visited[i][n - 1])
                {
                    solve_130(board, visited, i, n - 1);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (board[m - 1][i] == 'O' && !visited[m - 1][i])
                {
                    solve_130(board, visited, m - 1, i);
                }
            }

            for (int i = 1; i < m - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    if (board[i][j] == 'O' && !visited[i][j])
                    {
                        board[i][j] = 'X';
                    }
                }
            }
        }

        private void solve_130(char[][] board, bool[][] visited, int i, int j)
        {
            Queue<(int x, int y)> q = new Queue<(int x, int y)>();
            visited[i][j] = true;
            q.Enqueue((i, j));

            while (q.Count > 0)
            {
                (int x, int y) = q.Dequeue();


                if (x - 1 >= 0 && !visited[x - 1][y] && board[x - 1][y] == 'O')
                {
                    visited[x - 1][y] = true;
                    q.Enqueue((x - 1, y));
                }

                if (y - 1 >= 0 && !visited[x][y - 1] && board[x][y - 1] == 'O')
                {
                    visited[x][y - 1] = true;
                    q.Enqueue((x, y - 1));
                }

                if (x + 1 < board.Length && !visited[x + 1][y] && board[x + 1][y] == 'O')
                {
                    visited[x + 1][y] = true;
                    q.Enqueue((x + 1, y));
                }

                if (y + 1 < board[x].Length && !visited[x][y + 1] && board[x][y + 1] == 'O')
                {
                    visited[x][y + 1] = true;
                    q.Enqueue((x, y + 1));
                }
            }
        }

        public void Solve_v1(char[][] board)
        {
            bool[][] visited = new bool[board.Length][];

            for (int i = 0; i < board.Length; i++)
            {
                visited[i] = new bool[board[i].Length];
            }

            for (int i = 0; i < board.Length; i++)
            {
                if (i == 0 || i == board.Length - 1) continue;
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (j == 0 || j == board[i].Length - 1 || visited[i][j]) continue;

                    if (board[i][j] == 'O')
                    {
                        solve_130_V1(board, visited, i, j);
                    }
                }
            }
        }

        private void solve_130_V1(char[][] board, bool[][] visited, int i, int j)
        {
            bool edge = false;
            IList<(int, int)> lst = new List<(int, int)>();
            Queue<(int, int)> q = new Queue<(int, int)>();
            q.Enqueue((i, j));
            // visited[i][j] = true;

            while (q.Count > 0)
            {
                (int x, int y) = q.Dequeue();

                if (!edge && (x == 0 || y == 0 || x == board.Length - 1 || y == board[x].Length))
                {
                    edge = true;
                }

                visited[x][y] = true;
                lst.Add((x, y));
                //top y-1
                if (y - 1 >= 0 && board[x][y - 1] == 'O' && !visited[x][y - 1])
                {
                    q.Enqueue((x, y - 1));
                }


                //bottom y+1
                if (y + 1 < board[x].Length && board[x][y + 1] == 'O' && !visited[x][y + 1])
                {
                    q.Enqueue((x, y + 1));
                }

                //left x-1
                if (x - 1 >= 0 && board[x - 1][y] == 'O' && !visited[x - 1][y])
                {
                    q.Enqueue((x - 1, y));
                }

                //right x+1
                if (x + 1 < board.Length && board[x + 1][y] == 'O' && !visited[x + 1][y])
                {
                    q.Enqueue((x + 1, y));
                }

            }

            if (!edge)
            {
                foreach ((int x, int y) in lst)
                {
                    board[x][y] = 'X';
                }
            }

        }


        private void solve_130(char[][] board, bool[][] visited, Queue<(int, int)> q)
        {
            while (q.Count > 0)
            {
                (int i, int j) = q.Dequeue();
                visited[i][j] = true;


            }
        }

        #endregion

        #region Problem 743. Network Delay Time
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            int result = -1;
            Dictionary<int, IList<(int, int)>> map = new Dictionary<int, IList<(int, int)>>();

            int[] arr = Enumerable.Repeat(int.MaxValue, n).ToArray();
            bool[] visited = new bool[n];
            arr[k - 1] = 0;

            foreach (int[] time in times)
            {
                if (!map.ContainsKey(time[0] - 1))
                {
                    map.Add(time[0] - 1, new List<(int, int)>());
                }

                map[time[0] - 1].Add((time[1] - 1, time[2]));
            }

            int u = k - 1;
            while (u >= 0)
            {
                visited[u] = true;
                if (map.ContainsKey(u))
                {
                    foreach ((int v, int w) in map[u])
                    {
                        if (arr[u] + w < arr[v])
                        {
                            arr[v] = arr[u] + w;
                        }
                    }
                }

                u = -1;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (!visited[i])
                    {
                        if (u == -1 || arr[u] > arr[i])
                        {
                            u = i;
                        }
                    }
                }

                if (u != -1 && arr[u] == int.MaxValue) return -1;
            }

            return arr.Max();
        }
        #endregion

        #region Problem 744. Find Smallest Letter Greater Than Target
        public char NextGreatestLetter(char[] letters, char target)
        {
            int low = 0;
            int high = letters.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (letters[mid] == target)
                {

                }
                else if (target > letters[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            if (high <= 0 || low >= letters.Length) return letters[0];
            return letters[0];
        }
        #endregion

        #region Problem 787. Cheapest Flights Within K Stops
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            if (src == dst) return 0;
            int[] arr = Enumerable.Repeat(int.MaxValue, n).ToArray();
            Dictionary<int, List<(int, int)>> map = new Dictionary<int, List<(int, int)>>();

            for (int i = 0; i < n; i++)
            {
                map.Add(i, new List<(int, int)>());
            }


            foreach (int[] flight in flights)
            {
                map[flight[0]].Add((flight[1], flight[2]));
            }

            foreach (var key in map.Keys)
            {
                map[key] = map[key].OrderBy(x => x.Item2).ToList();
            }

            Queue<(int, int, int)> q = new Queue<(int, int, int)>();
            arr[src] = 0;
            q.Enqueue((src, 0, k));
            int result = int.MaxValue;
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                foreach (var item in map[p.Item1])
                {
                    int nxt = item.Item1;
                    int stop = p.Item3 - 1;
                    int weight = item.Item2 + p.Item2;
                    if (arr[nxt] > weight)
                    {
                        arr[nxt] = weight;
                        if (item.Item1 == dst)
                        {
                            result = Math.Min(result, weight);
                        }
                        else if (stop >= 0)
                        {
                            q.Enqueue((item.Item1, weight, stop));
                        }
                    }
                }
            }
            return result == int.MaxValue ? -1 : result;
        }
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

        #region Problem 2500. Delete Greatest Value in Each Row
        public int DeleteGreatestValue(int[][] grid)
        {
            int result = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                Array.Sort(grid[i]);
            }

            for (int i = 0; i < grid[0].Length; i++)
            {
                int k = grid[0][i];
                for (int j = 1; j < grid.Length; j++)
                {
                    k = Math.Max(k, grid[j][i]);
                }
                result += k;
            }
            return result;
        }
        #endregion

        #region Problem 2501. Longest Square Streak in an Array
        public int LongestSquareStreak(int[] nums)
        {
            Array.Sort(nums);
            // List<int> list = nums.ToList();
            int result = -1;
            int index = 0;
            while (index < nums.Length)
            {
                //int cnt = 1;
                //int i = list[0];

                //list.RemoveAt(0);

                //while (Array.BinarySearch())
                //{
                //    cnt++;
                //    i *= i;
                //    list.Remove(i);
                //}

                //result = Math.Max(result, cnt);
                int cnt = -1;
                int num = nums[index];
                int sqr = num * num;

                int found = Array.BinarySearch(nums, index + 1, nums.Length - 1 - index, sqr);

                if (found > 0)
                {
                    cnt = 2;
                    num = sqr;
                    sqr = num * num;
                    found = Array.BinarySearch(nums, found + 1, nums.Length - 1 - found, sqr);
                    while (found > 0)
                    {
                        cnt++;
                        num = sqr;
                        sqr = num * num;
                        found = Array.BinarySearch(nums, found + 1, nums.Length - 1 - found, sqr);
                    }
                }

                index++;
                result = Math.Max(result, cnt);
            }
            return result;
        }
        #endregion

        #region Problem 2502. Design Memory Allocator
        public class Allocator
        {
            int?[] arr;
            readonly int len;
            public Allocator(int n)
            {
                len = n;
                arr = new int?[len];
            }

            public int Allocate(int size, int mID)
            {
                for (int i = 0; i < len; i++)
                {
                    if (arr[i] == null)
                    {
                        int j = i;
                        int a = 0;
                        for (j = i; j < size + i && j < len; j++)
                        {
                            a++;
                            if (arr[j] != null) break;
                        }
                        if (j == size + i)
                        {
                            for (int k = i; k < size + i && k < len; k++)
                            {
                                arr[k] = mID;
                            }

                            return i;
                        }
                        else
                        {
                            i = i + a - 1;
                        }
                    }
                }
                return -1;
            }

            public int Free(int mID)
            {
                int cnt = 0;
                for (int i = 0; i < len; i++)
                {
                    if (arr[i] == mID)
                    {
                        arr[i] = null; cnt++;
                    }
                }
                return cnt;
            }
        }
        public class Allocator_V1
        {
            int?[] arr;
            int len;
            Dictionary<int, IList<(int, int)>> dict;
            SortedDictionary<int, int> freeBlocks;
            public Allocator_V1(int n)
            {
                dict = new Dictionary<int, IList<(int, int)>>();
                len = n;
                arr = new int?[len];
                freeBlocks = new SortedDictionary<int, int>();
                freeBlocks.Add(0, n);
            }

            public int Allocate(int size, int mID)
            {
                var dct = freeBlocks.FirstOrDefault(x => x.Value >= size);
                if (dct.Value >= size)
                {
                    if (!dict.ContainsKey(mID))
                    {
                        dict.Add(mID, new List<(int, int)>());
                    }

                    for (int i = dct.Key; i < size + dct.Key; i++)
                    {
                        arr[i] = mID;
                    }

                    dict[mID].Add((dct.Key, size));

                    freeBlocks.Remove(dct.Key);
                    if (dct.Value > size)
                    {
                        freeBlocks.Add(dct.Key + size, dct.Value - size);
                    }
                    return dct.Key;
                }



                return -1;
            }

            public int Free(int mID)
            {
                if (!dict.ContainsKey(mID) || dict[mID].Count == 0) return 0;
                int cnt = 0;
                //foreach (var index in dict[mID])
                //{
                //    cnt++;
                //    arr[index] = null;
                //}

                foreach ((int index, int size) in dict[mID])
                {
                    for (int i = index; i < index + size; i++)
                    {
                        cnt++;
                        arr[i] = null;
                    }
                    if (freeBlocks.ContainsKey(index + size))
                    {
                        var val = freeBlocks[index + size];

                        freeBlocks.Remove(index + size);

                        freeBlocks.Add(index, val + size);
                    }
                    else
                    {
                        var dct = freeBlocks.LastOrDefault(x => x.Key < index);
                        if (dct.Value > 0)
                        {
                            freeBlocks[dct.Key] += size;
                        }
                        else
                        {

                            freeBlocks.Add(index, size);
                        }
                    }
                }
                dict.Remove(mID);
                return cnt;
            }
        }
        #endregion

        #region Problem 2503. Maximum Number of Points From Grid Queries

        public int[] MaxPoints(int[][] grid, int[] queries)
        {
            bool[][] dp = new bool[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                dp[i] = new bool[grid[i].Length];
            }

            int[] output = new int[queries.Length];

            Dictionary<int, IList<int>> map = new Dictionary<int, IList<int>>();
            for (int i = 0; i < queries.Length; i++)
            {
                if (!map.ContainsKey(queries[i]))
                {
                    map.Add(queries[i], new List<int>());
                }
                map[queries[i]].Add(i);
            }


            Array.Sort(queries);

            Queue<(int, int)> queue = new Queue<(int, int)>();
            HashSet<(int, int)> list = new HashSet<(int, int)>();

            list.Add((0, 0));
            int[] result = new int[queries.Length];
            int counter = 0;
            for (int k = 0; k < queries.Length; k++)
            {
                queue = new Queue<(int, int)>(list);

                list = new HashSet<(int, int)>();
                int num = queries[k];
                while (queue.Count > 0)
                {
                    (int i, int j) = queue.Dequeue();
                    if (i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length) continue;

                    if (num > grid[i][j])
                    {
                        if (!dp[i][j])
                        {
                            counter++;
                            dp[i][j] = true;
                            //top i-1
                            queue.Enqueue((i - 1, j));

                            //bottom i+1
                            queue.Enqueue((i + 1, j));

                            //left j-1
                            queue.Enqueue((i, j - 1));

                            //right j+1
                            queue.Enqueue((i, j + 1));
                        }
                    }
                    else
                    {
                        list.Add((i, j));
                    }
                }

                result[k] = counter;

                output[map[queries[k]][0]] = counter;
                map[queries[k]].RemoveAt(0);
            }

            return output;
        }

        public int[] MaxPoints_v1(int[][] grid, int[] queries)
        {
            int[] result = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                int count = 0;

                if (grid[0][0] < queries[i])
                {
                    count = MaxPoints_Helper_V2(grid, queries[i]);
                }

                result[i] = count;

            }

            return result;
        }



        private int[] MaxPoints_Helper(int[][] grid, int[] queries)
        {
            bool[][] dp = new bool[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                dp[i] = new bool[grid[i].Length];
            }

            int[] output = new int[queries.Length];

            Dictionary<int, IList<int>> map = new Dictionary<int, IList<int>>();
            for (int i = 0; i < queries.Length; i++)
            {
                if (!map.ContainsKey(queries[i]))
                {
                    map.Add(queries[i], new List<int>());
                }
                map[queries[i]].Add(i);
            }


            Array.Sort(queries);

            Queue<(int, int)> queue = new Queue<(int, int)>();
            IList<(int, int)> list = new List<(int, int)>();

            list.Add((0, 0));
            int[] result = new int[queries.Length];
            int counter = 0;
            for (int k = 0; k < queries.Length; k++)
            {
                queue = new Queue<(int, int)>(list);

                list = new List<(int, int)>();
                int num = queries[k];
                while (queue.Count > 0)
                {
                    (int i, int j) = queue.Dequeue();
                    if (i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length) continue;

                    if (num > grid[i][j])
                    {
                        if (!dp[i][j])
                        {
                            counter++;
                            dp[i][j] = true;
                            //top i-1
                            queue.Enqueue((i - 1, j));

                            //bottom i+1
                            queue.Enqueue((i + 1, j));

                            //left j-1
                            queue.Enqueue((i, j - 1));

                            //right j+1
                            queue.Enqueue((i, j + 1));
                        }
                    }
                    else
                    {
                        if (!list.Contains((i, j))) list.Add((i, j));
                    }
                }

                result[k] = counter;

                output[map[queries[k]][0]] = counter;
                map[queries[k]].RemoveAt(0);
            }

            return output;
        }

        private int MaxPoints_Helper_V2(int[][] grid, int v)
        {
            int count = 0;
            bool[][] visited = new bool[grid.Length][];

            for (int i = 0; i < grid.Length; i++)
            {
                visited[i] = new bool[grid[i].Length];
            }
            Queue<(int, int)> queue = new Queue<(int, int)>();

            queue.Enqueue((0, 0));
            while (queue.Count > 0)
            {
                (int i, int j) = queue.Dequeue();

                if (i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length || visited[i][j] || grid[i][j] >= v) continue;

                count++;
                visited[i][j] = true;


                //top i-1
                queue.Enqueue((i - 1, j));

                //bottom i+1
                queue.Enqueue((i + 1, j));

                //left j-1
                queue.Enqueue((i, j - 1));

                //right j+1
                queue.Enqueue((i, j + 1));
            }

            return count;
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

        #region Weekly324
        public int SimilarPairs(string[] words)
        {
            if (words.Length < 2)
            {
                return 0;
            }

            int result = 0;

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = new string(words[i].Distinct().OrderBy(x => x).ToArray());
            }
            Dictionary<string, int> pair = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (!pair.ContainsKey(words[i]))
                {
                    pair.Add(words[i], 0);
                }
                pair[words[i]]++;
            }

            foreach (var key in pair.Keys)
            {
                result += getPairs(pair[key] - 1);
            }

            //Dictionary<int, IList<int>> pairs = new Dictionary<int, IList<int>>();
            //for (int i = 0; i < words.Length - 1; i++)
            //{
            //    if (pairs.ContainsKey(i)) continue;
            //    var word1 = words[i].ToCharArray().OrderBy(x => x).Distinct();
            //    pairs.Add(i, new List<int>());
            //    for (int j = i + 1; j < words.Length; j++)
            //    {
            //        var word2 = words[j].ToCharArray().OrderBy(x => x).Distinct();

            //        if (match(word1, word2))
            //        {
            //            pairs[i].Add(j);
            //        }
            //    }

            //    for (int k = 0; k < pairs[i].Count - 1; k++)
            //    {
            //        pairs.Add(pairs[i][k], new List<int>());
            //        for (int l = k + 1; l < pairs[i].Count; l++)
            //        {
            //            pairs[pairs[i][k]].Add(l);
            //        }
            //    }
            //}

            //foreach (var item in pairs.Keys)
            //{
            //    result += pairs[item].Count;
            //}
            return result;
        }

        private int getPairs(int k)
        {
            int result = 0;

            while (k > 0)
            {
                result += k;
                k--;
            }

            return result;
        }

        private bool match(IEnumerable<char> word1, IEnumerable<char> word2)
        {
            int len = word1.Count();
            if (len != word2.Count()) return false;

            for (int i = 0; i < len; i++)
            {
                if (word1.ElementAt(i) != word2.ElementAt(i)) return false;
            }
            return true;
        }

        public int SmallestValue(int n)
        {
            int oldn = n;
            int sum = 0;
            int i = 2;
            while (i <= n)
            {
                if (n % i == 0)
                {
                    sum += i;
                    n /= i;
                }
                else
                {
                    i++;
                }
            }

            if (sum == oldn) return oldn;

            return SmallestValue(sum);
        }
        #endregion

        #region Weekly 325
        public int ClosetTarget(string[] words, string target, int startIndex)
        {
            int left = startIndex - 1, right = startIndex + 1;
            bool found = false;
            int counter = 1;
            while (!found && counter < words.Length)
            {
                if (left == -1)
                {
                    left = words.Length - 1;
                }
                if (left >= 0)
                {
                    if (words[left] == target)
                    {
                        found = true;
                        break;
                    }
                }

                if (right == words.Length)
                {
                    right = 0;
                }
                if (right < words.Length)
                {
                    if (words[right] == target)
                    {
                        found = true;
                        break;
                    }
                }
                left--;
                right++;
                counter++;
            }

            return found ? counter : -1;
        }
        #endregion
    }
}
