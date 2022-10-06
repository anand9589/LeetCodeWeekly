using Common;

namespace October22
{
    public class Solution
    {
        #region Day 1 Problem 91. Decode Ways
        public int NumDecodings(string s)
        {
            if (s == null || s.Length == 0 || s.StartsWith('0')) return 0;
            if (s.Length == 1) return 1;

            int[] dp = new int[s.Length + 1];

            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= s.Length; i++)
            {
                int l1 = int.Parse(s.Substring(i - 1, 1));
                int l2 = int.Parse(s.Substring(i - 2, 2));

                if (l1 >= 1 && l1 <= 9)
                {
                    dp[i] += dp[i - 1];
                }

                if (l2 >= 10 && l2 <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp[s.Length];
        }
        #endregion

        #region Day 2 Problem 1155. Number of Dice Rolls With Target Sum
        public int NumRollsToTarget(int n, int k, int target)
        {
            if (target == 0) return 0;
            if (target > n * k) return 0;

            int count = (int)getRollsToDice(n, k, target);


            return count;
        }

        private long getRollsToDice(int n, int k, int target)
        {
            int mod = (int)Math.Pow(10, 9) + 7;
            long[][] dp = new long[n + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new long[target + 1];
            }

            dp[0][0] = 1;

            for (int dice = 1; dice <= n; dice++)
            {
                for (int tar = 1; tar <= target; tar++)
                {
                    long count = 0;
                    for (int i = 1; i <= k; i++)
                    {
                        if (tar - i >= 0) count += dp[dice - 1][tar - i];
                    }
                    dp[dice][tar] = count;
                }
            }

            return dp[n][target] % mod;
        }
        #endregion

        #region Day 3 Problem 1578. Minimum Time to Make Rope Colorful
        public int MinCost(string colors, int[] neededTime)
        {
            if (colors.Length == 1) return 0;

            int index = 1;
            int sum = neededTime[0];
            int max = neededTime[0];
            int result = 0;

            while (index < colors.Length)
            {
                if (colors[index] != colors[index - 1])
                {
                    result += sum - max;
                    sum = 0;
                    max = 0;
                }
                sum += neededTime[index];
                max = Math.Max(max, neededTime[index]);
                index++;
            }
            result += sum - max;

            return result;
        }
        #endregion

        #region Day 4 Problem 112. Path Sum
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            targetSum -= root.Val;

            if (root.Left == null && root.Right == null && targetSum == 0) return true;

            return HasPathSum(root.Left, targetSum) || HasPathSum(root.Right, targetSum);
        }

        private bool hasPathSum_helper(TreeNode node, int sum)
        {
            if (node.Left == null && node.Right == null && sum - node.Val == 0) return true;

            bool leftTree = node.Left != null ? hasPathSum_helper(node.Left, sum - node.Val) : false;
            bool rightTree = node.Right != null ? hasPathSum_helper(node.Right, sum - node.Val) : false;

            return leftTree || rightTree;
        }
        #endregion

        #region Day 5 Problem 623. Add One Row to Tree
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
            {
                return new TreeNode(val, root, null);
            }

            insertNode(root, depth, val, 1);
            return root;
        }

        private void insertNode(TreeNode node, int depth, int val, int currDepth)
        {
            if (node == null) return;

            if (currDepth == depth - 1)
            {
                TreeNode temp = node.Left;
                node.Left = new TreeNode(val, temp, null);
                temp = node.Right;
                node.Right = new TreeNode(val, null, temp);
            }
            else
            {
                insertNode(node.Left, depth, val, currDepth + 1);
                insertNode(node.Right, depth, val, currDepth + 1);
            }
        }
        #endregion

        #region Day 6 Problem 981. Time Based Key-Value Store
        public class TimeMap
        {
            Dictionary<string, List<KeyValuePair<int, string>>> dctKeyTime;
            public TimeMap()
            {
                dctKeyTime = new Dictionary<string, List<KeyValuePair<int, string>>>();
            }

            public void Set(string key, string value, int timestamp)
            {
                if (!dctKeyTime.ContainsKey(key))
                {
                    dctKeyTime.Add(key, new List<KeyValuePair<int, string>>());
                }

                dctKeyTime[key].Add(new KeyValuePair<int, string>( timestamp, value));
            }

            public string Get(string key, int timestamp)
            {
                if (dctKeyTime.ContainsKey(key))
                {
                    List<KeyValuePair<int, string>> values = dctKeyTime[key];
                    if (values.Count > 0)
                    {
                        if (values.Count == 1)
                        {
                            if(values.First().Key <= timestamp) return values.First().Value;
                        }
                        else
                        {

                            //int[] keys = values.Keys.ToArray();
                            int low = 0;
                            int high = values.Count - 1;

                            //if (keys[low] > timestamp) return "";
                            //if (keys[high] < timestamp) return values[keys[high]];
                            if (values[low].Key > timestamp) return "";
                            //if(values[high].Key < timestamp) return values[high].Value;

                            while (low < high)
                            {
                                if(values[low].Key == timestamp) return values[low].Value;
                                if (values[high].Key <= timestamp) return values[high].Value;
                                //if (keys[low] == timestamp) return values[keys[low]];
                                //if (keys[high] == timestamp) return values[keys[high]];

                                int mid = (low + high) / 2;

                                if (values[mid].Key == timestamp) return values[mid].Value;
                                //if (keys[mid] == timestamp) return values[keys[mid]];

                                if (timestamp > values[mid].Key)
                                {
                                    if (Math.Abs(mid - low) <= 1) return values[low].Value;
                                    low = mid + 1;
                                }
                                else
                                {
                                    if (Math.Abs(high - low) <= 1) return values[mid].Value;
                                    high = mid - 1;
                                }
                            }
                        }
                    }
                }
                return "";

                //int low = 0;
                //int high = values.Count;

                //if(values?.Count >= 0)
                //{
                //    var res = values.Where(x => x.Key <= timestamp).LastOrDefault().Value;

                //   return string.IsNullOrEmpty(res) ? "" : res;

                //}
                //return "";
            }
        }
        #endregion

        #region Day 7 Problem
        #endregion

        #region Day 8 Problem
        #endregion

        #region Day 9 Problem
        #endregion

        #region Day 10 Problem
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

        #region Weekly 313
        public int CommonFactors(int a, int b)
        {
            int result = 1;

            for (int i = 2; i <= Math.Min(a, b); i++)
            {
                if (a % i == 0 && b % i == 0) result++;
            }

            return result;
        }
        public int MaxSum(int[][] grid)
        {
            int result = 0;

            for (int i = 1; i < grid.Length - 1; i++)
            {
                for (int j = 1; j < grid[i].Length - 1; j++)
                {
                    int sum = grid[i - 1][j - 1] + grid[i - 1][j] + grid[i - 1][j + 1] + grid[i][j] + grid[i + 1][j - 1] + grid[i + 1][j] + grid[i + 1][j + 1];

                    result = Math.Max(result, sum);
                }
            }

            return result;
        }

        public int MinimizeXor(int num1, int num2)
        {
            return num1 ^ num2;
        }

        public int DeleteString(string s)
        {
            return delete(s);
        }

        private int delete(string s)
        {
            if (s.Length == 0) return 0;
            int c = 1;

            string d = "";

            for (int i = 0; i < s.Length; i++)
            {

                d += s[i];

                string s2 = "";
                if (i + d.Length < s.Length)
                {
                    s2 = s.Substring(i + 1, d.Length);
                }

                if (s2 == d)
                {

                    c = 1 + delete(s.Substring(i + 1));
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}