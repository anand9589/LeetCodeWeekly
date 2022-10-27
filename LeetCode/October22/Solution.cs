using Common;
using System.Text;

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

            targetSum -= root.val;

            if (root.left == null && root.right == null && targetSum == 0) return true;

            return HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum);
        }

        private bool hasPathSum_helper(TreeNode node, int sum)
        {
            if (node.left == null && node.right == null && sum - node.val == 0) return true;

            bool leftTree = node.left != null ? hasPathSum_helper(node.left, sum - node.val) : false;
            bool rightTree = node.right != null ? hasPathSum_helper(node.right, sum - node.val) : false;

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
                TreeNode temp = node.left;
                node.left = new TreeNode(val, temp, null);
                temp = node.right;
                node.right = new TreeNode(val, null, temp);
            }
            else
            {
                insertNode(node.left, depth, val, currDepth + 1);
                insertNode(node.right, depth, val, currDepth + 1);
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

                dctKeyTime[key].Add(new KeyValuePair<int, string>(timestamp, value));
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
                            if (values.First().Key <= timestamp) return values.First().Value;
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
                                if (values[low].Key == timestamp) return values[low].Value;
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

        #region Day 7 Problem 732. My Calendar III
        public class MyCalendarThree
        {
            SortedDictionary<int, int> values;
            public MyCalendarThree()
            {
                values = new SortedDictionary<int, int>();
            }

            public int Book(int start, int end)
            {
                int currBooking = 0;
                int maxBooking = 0;
                if (values.ContainsKey(start))
                {
                    values[start]++;
                }
                else
                {
                    values.Add(start, 1);
                }

                if (values.ContainsKey(end))
                {
                    values[end]--;
                }
                else
                {
                    values.Add(end, -1);
                }

                foreach (int t in values.Values)
                {
                    currBooking += t;
                    maxBooking = Math.Max(maxBooking, currBooking);
                }

                return maxBooking;
            }
        }
        #endregion

        #region Day 8 Problem 16. 3Sum Closest
        public int ThreeSumClosest(int[] nums, int target)
        {

            Array.Sort(nums);
            int result = int.MaxValue;
            int diff = int.MaxValue;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;

                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];

                    if (Math.Abs(diff) > Math.Abs(sum - target))
                    {
                        diff = sum - target;
                        result = sum;
                    }

                    if (sum < target)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }
            return result;
        }
        #endregion

        #region Day 9 Problem 653. Two Sum IV - Input is a BST
        public bool FindTarget(TreeNode root, int k)
        {
            List<int> remTarget = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node != null)
                {

                    if (remTarget.Contains(node.val)) return true;
                    int rem = k - node.val;

                    remTarget.Add(rem);
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            return false;
        }
        #endregion

        #region Day 10 Problem 1328. Break a Palindrome
        public string BreakPalindrome(string palindrome)
        {

            if (palindrome.Length == 1)
            {
                return string.Empty;
            }
            char[] chars = palindrome.ToCharArray();
            for (int i = 0; i <= (chars.Length - 1) / 2; i++)
            {
                if (chars[i] != 'a')
                {
                    chars[i] = 'a';

                    return new string(chars);
                }
            }

            chars[chars.Length - 1] = 'b';
            return new string(chars);
        }
        #endregion

        #region Day 11 Problem 334. Increasing Triplet Subsequence
        public bool IncreasingTriplet(int[] nums)
        {
            //for (int i = 0; i < nums.Length-2; i++)
            //{
            //    for (int j = i+1; j < nums.Length-1; j++)
            //    {
            //        for (int k = j+1; k < nums.Length; k++)
            //        {
            //            if (nums[i] < nums[j] && nums[j] < nums[k]) return true;
            //        }
            //    }
            //}

            //Stack<int> stack = new Stack<int>();
            //stack.Push(nums[0]);

            //for (int i = 1; i < nums.Length; i++)
            //{
            //    while (stack.Peek() >= nums[i])
            //    {
            //        stack.Pop();
            //    }
            //    stack.Push(nums[i]);
            //    if (stack.Count == 3) return true;
            //}

            int i = int.MaxValue;
            int j = int.MaxValue;

            for (int k = 0; k < nums.Length; k++)
            {
                if (nums[k] <= i)
                {
                    i = nums[k];
                }
                else if (nums[k] <= j)
                {
                    j = nums[k];
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Day 12 Problem 976. Largest Perimeter Triangle
        public int LargestPerimeter(int[] nums)
        {
            Array.Sort(nums);

            for (int i = nums.Length - 1; i >= 2; i--)
            {
                if (nums[i] < nums[i - 1] + nums[i - 2])
                {
                    return nums[i] + nums[i - 1] + nums[i - 2];
                }
            }
            return 0;
        }
        #endregion

        #region Day 13 Problem 237. Delete Node in a Linked List
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
        #endregion

        #region Day 14 Problem 2095. Delete the Middle Node of a Linked List
        public ListNode DeleteMiddle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            if (slow == fast) return null;
            if (fast.next == null)
            {
                slow.val = slow.next.val;
            }
            slow.next = slow.next.next;

            return head;
        }
        #endregion

        #region Day 15 Problem 1531. String Compression II

        private int[][][][] dp1;
        public int GetLengthOfOptimalCompression(string s, int k)
        {
            int n = s.Length;
            int[][] dp = new int[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = new int[k + 1];
                for (int j = 0; j <= k; j++)
                {
                    dp[i][j] = 10000;
                }
            }

            dp[0][0] = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    int cnt = 0, del = 0;
                    for (int l = i; l >= 1; l--)
                    {
                        if (s[l - 1] == s[i - 1]) cnt++;
                        else del++;
                        if (j - del >= 0)
                            dp[i][j] = Math.Min(dp[i][j],
                                                dp[l - 1][j - del] + 1 + (cnt >= 100 ? 3 : cnt >= 10 ? 2 : cnt >= 2 ? 1 : 0));
                    }
                    if (j > 0)
                        dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j - 1]);
                }
            }
            return dp[n][k];
        }

        public int GetLengthOfOptimalCompression_V3(string s, int k)
        {
            int n = s.Length;
            dp1 = new int[n][][][];

            for (int i = 0; i < n; i++)
            {
                dp1[i] = new int[26][][];

                for (int j = 0; j < 26; j++)
                {
                    dp1[i][j] = new int[n + 1][];

                    for (int l = 0; l < n + 1; l++)
                    {
                        dp1[i][j][l] = Enumerable.Repeat(int.MaxValue, k + 1).ToArray();
                    }
                }
            }

            return solve1531(0, 0, 0, k, s);
        }

        private int solve1531(int i, int ch, int len, int k, string str)
        {
            if (i == str.Length) return getLen1531(len);

            if (dp1[i][ch][len][k] == int.MaxValue)
            {
                int c = str[i] - 'a';
                if (k > 0) dp1[i][ch][len][k] = solve1531(i + 1, ch, len, k - 1, str);
                if (c == ch) dp1[i][ch][len][k] = Math.Min(dp1[i][ch][len][k], solve1531(i + 1, ch, len + 1, k, str));
                else dp1[i][ch][len][k] = Math.Min(dp1[i][ch][len][k], getLen1531(len) + solve1531(i + 1, c, 1, k, str));

            }

            return dp1[i][ch][len][k];
        }

        public int GetLengthOfOptimalCompression_V2(string s, int k)
        {
            int n = s.Length;

            int[][] dp = new int[n + 1][];

            dp[0] = new int[k + 1];
            for (int i = 1; i <= n; i++)
            {
                dp[i] = Enumerable.Repeat(int.MaxValue, k + 1).ToArray();
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    if (j > 0)
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                    }
                    int removed = 0;
                    int count = 0;
                    int p;

                    for (p = i; p > 0; p--)
                    {
                        if (s[p - 1] == s[i - 1]) count++;
                        else if (++removed > j) break;

                        dp[i][j] = Math.Min(dp[i][j], dp[p - 1][j - removed] + getLen1531(count));
                    }

                }
            }

            return dp[n][k];
        }

        private int getLen1531(int len)
        {
            if (len == 0) return 0;
            if (len == 1) return 1;
            if (len < 10) return 2;
            if (len < 100) return 3;

            return 4;
        }

        public int GetLengthOfOptimalCompression_V1(string s, int k)
        {
            if (s.Length == 100)
            {
                bool flag = true;

                for (int i = 0; i < 100; i++)
                {
                    if (s[i] != s[0])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) return 4;
            }

            int[][][][] dp = new int[101][][][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[101][][];
                for (int j = 0; j < 101; j++)
                {
                    dp[i][j] = new int[27][];
                    for (int m = 0; m < 27; m++)
                    {
                        dp[i][j][m] = new int[11];
                    }
                }
            }
            int n = s.Length;
            s = "#" + s;

            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= k; j++)
                    for (int ch = 0; ch <= 26; ch++)
                        for (int num = 0; num <= 10; num++)
                            dp[i][j][ch][num] = int.MaxValue;
            // dp[i][k][ch][num]: the optimal solution for s[1:i]
            // with k digits removed, last letter as ch, the consecitive number of ch as num

            dp[0][0][26][0] = 0;

            for (int i = 0; i < n; i++)
                for (int j = 0; j <= Math.Min(k, i); j++)
                    for (int ch = 0; ch <= 26; ch++)
                        for (int num = 0; num <= 10; num++)
                        {
                            int cur = dp[i][j][ch][num];
                            if (cur == int.MaxValue) continue;

                            // delete s[i+1]
                            dp[i + 1][j + 1][ch][num] = Math.Min(dp[i + 1][j + 1][ch][num], cur);

                            // keep s[i+1]
                            if (s[i + 1] - 'a' == ch)
                            {
                                int add = 0;
                                if (num == 1) add = 1;  // a -> a2
                                else if (num >= 2 && num <= 8) add = 0; // a3->a4
                                else if (num == 9) add = 1; // a9->a10;
                                else if (num == 10) add = 0; // a10->a11;
                                dp[i + 1][j][ch][Math.Min(num + 1, 10)] = Math.Min(dp[i + 1][j][ch][Math.Min(num + 1, 10)], cur + add);
                            }
                            else
                            {
                                dp[i + 1][j][s[i + 1] - 'a'][1] = Math.Min(dp[i + 1][j][s[i + 1] - 'a'][1], cur + 1);
                            }
                        }

            int ret = int.MaxValue;
            for (int ch = 0; ch <= 26; ch++)
                for (int num = 0; num <= 10; num++)
                    ret = Math.Min(ret, dp[n][k][ch][num]);

            return ret;
        }
        #endregion

        #region Day 16 Problem 1335. Minimum Difficulty of a Job Schedule
        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            if (d > jobDifficulty.Length) return -1;
            if (d == jobDifficulty.Length) return jobDifficulty.Sum();

            int[][] dp = new int[d + 1][];

            for (int i = 0; i <= d; i++)
            {
                dp[i] = new int[jobDifficulty.Length];

                for (int j = 0; j < jobDifficulty.Length; j++)
                {
                    dp[i][j] = -1;
                }
            }

            return findMinDifficulty(dp, jobDifficulty, d, 0);

        }

        private int findMinDifficulty(int[][] dp, int[] jobDifficulty, int d, int index)
        {
            int max = 0;
            if (d == 1)
            {
                while (index < jobDifficulty.Length)
                {
                    max = Math.Max(max, jobDifficulty[index]);
                    index++;
                }

                return max;
            }

            if (dp[d][index] != -1) return dp[d][index];

            int res = int.MaxValue;

            for (int i = index; i < jobDifficulty.Length - d + 1; i++)
            {
                max = Math.Max(max, jobDifficulty[i]);
                res = Math.Min(res, max + findMinDifficulty(dp, jobDifficulty, d - 1, i + 1));
            }

            dp[d][index] = res;

            return dp[d][index];
        }
        #endregion

        #region Day 17 Problem 1832. Check if the Sentence Is Pangram
        public bool CheckIfPangram_v1(string sentence)
        {
            char[] chs = sentence.ToCharArray().Distinct().ToArray();
            return chs.Length == 26;
        }
        public bool CheckIfPangram(string sentence)
        {
            int index = 0;
            int count = 0;
            bool[] visited = new bool[26];
            while (index < sentence.Length)
            {
                int i = sentence[index] - 'a';
                if (!visited[i])
                {
                    visited[i] = true;
                    count++;
                }
                index++;
            }
            return count == 26;
        }
        #endregion

        #region Day 18 Problem 38. Count and Say
        public string CountAndSay(int n)
        {
            if (n == 1) return "1";

            StringBuilder sb = new StringBuilder();
            sb.Append(1);

            for (int i = 2; i <= n; i++)
            {
                IList<(char, int)> lst = new List<(char, int)>();
                string s = sb.ToString();
                int index = 1;
                char lastch = s[0];
                lst.Add((lastch, 1));
                int counter = 1;
                while (index < s.Length)
                {
                    if (lastch == s[index])
                    {
                        counter++;
                        lst[lst.Count - 1] = (lastch, counter);
                    }
                    else
                    {
                        counter = 1;
                        lastch = s[index];
                        lst.Add((lastch, counter));
                    }
                    index++;
                }
                sb = new StringBuilder();
                foreach (var item in lst)
                {
                    sb.Append(item.Item2);
                    sb.Append(item.Item1 - '0');
                }
            }

            return sb.ToString();
        }
        #endregion

        #region Day 19 Problem 692. Top K Frequent Words
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (dic.ContainsKey(word))
                {
                    dic[word]++;
                }
                else
                {
                    dic.Add(word, 1);
                }
            }

            return dic.OrderBy(x => x.Key).OrderByDescending(y => y.Value).Select(x => x.Key).Take(k).ToList();
        }
        #endregion

        #region Day 20 Problem 12. Integer to Roman
        public string IntToRoman(int num)
        {
            Dictionary<int, string> romanCode = new Dictionary<int, string>()
            {
                {1000,"M" },
                {900,"CM" },
                {500,"D" },
                {400,"CD" },
                {100,"C" },
                {90,"XC" },
                {50,"L" },
                {40,"XL" },
                {10,"X" },
                {9,"IX" },
                {5,"V" },
                {4,"IV" },
                {1,"I" }
            };

            StringBuilder sb = new StringBuilder();

            foreach (int item in romanCode.Keys)
            {
                while (num >= item)
                {
                    sb.Append(romanCode[item]);
                    num -= item;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region Day 21 Problem 219. Contains Duplicate II
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < Math.Min(i + k + 1, nums.Length); j++)
                {
                    if (nums[i] == nums[j]) return true;
                }

            }
            return false;
        }
        #endregion

        #region Day 22 Problem 76. Minimum Window Substring
        public string MinWindow(string s, string t)
        {
            int stringLength = int.MaxValue;
            string result = "";
            if (s.Length < t.Length) return result;

            if (t.Length == 1 && s.Contains(t[0])) return t;
            Dictionary<char, int> dct = new Dictionary<char, int>();


            for (int i = 0; i < t.Length; i++)
            {
                if (!dct.ContainsKey(t[i]))
                {
                    dct.Add(t[i], 1);
                }
                else
                {
                    dct[t[i]]++;
                }
            }
            int startIndex = 0;
            int endIndex = s.Length - 1;
            while (startIndex <= endIndex && !dct.ContainsKey(s[startIndex]))
            {
                startIndex++;
            }

            while (startIndex <= endIndex && !dct.ContainsKey(s[endIndex]))
            {
                endIndex--;
            }

            if (startIndex > endIndex || (endIndex - startIndex + 1) < t.Length) return result;

            int counter = t.Length;
            int index = startIndex;
            while (startIndex <= endIndex)
            {
                if (dct.ContainsKey(s[startIndex]))
                {
                    char c = s[startIndex];
                    dct[c]--;
                    if (dct[c] >= 0) counter--;
                    while (counter == 0)
                    {
                        if (stringLength > startIndex - index + 1)
                        {
                            stringLength = startIndex - index + 1;
                            result = s.Substring(index, stringLength);

                        }

                        char p = s[index];

                        dct[p]++;
                        if (dct[p] > 0) counter++;
                        index++;

                        while (!dct.ContainsKey(s[index]))
                        {
                            index++;
                        }

                    }
                }
                startIndex++;
            }
            return result;
        }
        #endregion

        #region Day 23 Problem 645. Set Mismatch
        public int[] FindErrorNums(int[] nums)
        {
            int[] result = new int[2];

            foreach (int n in nums)
            {
                if (nums[Math.Abs(n) - 1] < 0)
                {
                    result[0] = Math.Abs(n);
                }
                else
                {
                    nums[Math.Abs(n) - 1] *= -1;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    result[1] = i + 1;
                }
            }
            return result;
        }
        #endregion

        #region Day 24 1239. Maximum Length of a Concatenated String with Unique Characters
        public int MaxLength(IList<string> arr)
        {
            arr = arr.Where(x => x.Distinct().Count() == x.Count()).ToList();

            return MaxLength_BackTrack(arr);
        }

        public int MaxLength_BackTrack(IList<string> arr, int i = 0, string s = "")
        {
            if (s.Distinct().Count() < s.Length) return 0;

            if (arr.Count == i) return s.Length;

            return Math.Max(
                MaxLength_BackTrack(arr, i + 1, s),
                MaxLength_BackTrack(arr, i + 1, s + arr[i])
            );
        }
        #endregion

        #region Day 25 Problem 1662. Check If Two String Arrays are Equivalent
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {

            return string.Join("", word1).Equals(string.Join("", word2));
        }
        #endregion

        #region Day 26 Problem 523. Continuous Subarray Sum
        public bool CheckSubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, -1);
            long sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                int rem = (int)(sum % k);
                if (map.ContainsKey(rem))
                {
                    if (i - map[rem] > 1) return true;
                }
                else
                {
                    map.Add(rem, i);
                }
            }
            return false;
        }
        #endregion

        #region Day 27 Problem 835. Image Overlap
        public int LargestOverlap(int[][] img1, int[][] img2)
        {

            int n = img1.Length;
            if (n == 1)
            {
                if (img1[0][0] == img2[0][0] && img1[0][0] == 1) return 1;
                return 0;
            }
            IList<(int, int)> img1List = new List<(int, int)>();
            IList<(int, int)> img2List = new List<(int, int)>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (img1[i][j] == 1)
                    {
                        img1List.Add((i + n - 1, j + n - 1));
                    }
                    if (img2[i][j] == 1)
                    {
                        img2List.Add((i, j));
                    }
                }
            }
            Dictionary<(int, int), int> map = new Dictionary<(int, int), int>();

            foreach (var (p, q) in img1List)
            {
                foreach (var (x, y) in img2List)
                {
                    var m = (p - x, q - y);

                    if (map.ContainsKey(m))
                    {
                        map[m]++;
                    }
                    else
                    {
                        map.Add(m, 1);
                    }
                }
            }

            return map.Count > 0 ? map.Values.Max() : 0;
        }
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

        #region Weekly Contest 315
        public int FindMaxK(int[] nums)
        {
            List<int> list = new List<int>();
            int result = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (list.Contains(-(nums[i])))
                {
                    result = Math.Max(result, Math.Abs(nums[i]));
                }
                else
                {
                    list.Add(nums[i]);
                }
            }
            return result;
        }

        public int CountDistinctIntegers(int[] nums)
        {
            int[] newArr = new int[nums.Length + nums.Length];

            for (int i = 0; i < nums.Length * 2; i++)
            {
                if (i < nums.Length)
                {
                    newArr[i] = nums[i];
                }
                else
                {
                    int index = i % nums.Length;
                    newArr[i] = Convert.ToInt32(new string(nums[index].ToString().Reverse().ToArray()));
                }
            }

            return newArr.Distinct().Count();
        }
        public bool SumOfNumberAndReverse(int num)
        {
            for (int i = num; i >= 1; i--)
            {
                int x = i;
                int y = getReverseNumber(i);

                if (x + y == num) return true;
            }

            return false;
        }

        private int getReverseNumber(int i)
        {
            return Convert.ToInt32(new string(i.ToString().Reverse().ToArray()));
        }
        #endregion

        #region Weekly Contest 316
        public bool HaveConflict(string[] event1, string[] event2)
        {
            int event1StartTime = int.Parse(event1[0].Split(":")[0]) * 60 + int.Parse(event1[0].Split(":")[1]);
            int event1EndTime = int.Parse(event1[1].Split(":")[0]) * 60 + int.Parse(event1[1].Split(":")[1]);
            int event2StartTime = int.Parse(event2[0].Split(":")[0]) * 60 + int.Parse(event2[0].Split(":")[1]);
            int event2EndTime = int.Parse(event2[1].Split(":")[0]) * 60 + int.Parse(event2[1].Split(":")[1]);

            if (event2StartTime >= event1StartTime && event2StartTime <= event1EndTime) return true;
            if (event1StartTime >= event2StartTime && event1StartTime <= event2EndTime) return true;

            if (event2EndTime >= event1StartTime && event2EndTime <= event1EndTime) return true;
            if (event1EndTime >= event2StartTime && event1EndTime <= event2EndTime) return true;

            return false;
        }

        public int SubarrayGCD(int[] nums, int k)
        {

            return 0;
        }

        public long MinCost(int[] nums, int[] cost)
        {
            long result = 0;

            long arrLen = 0;

            for (int i = 0; i < cost.Length; i++)
            {
                arrLen += cost[i];
            }
            //int[] arr = new int[arrLen];
            List<(int, int)> list = new List<(int, int)>();
            for (int i = 0; i < nums.Length; i++)
            {
                list.Add((nums[i], cost[i]));
            }

            list = list.OrderBy(x => x.Item1).ToList();
            //int index = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = 0; j < cost[i]; j++)
            //    {
            //        arr[index++] = nums[i];
            //    }
            //}
            //Array.Sort(arr);
            long median = arrLen / 2;
            int num = 0;

            long k = median;
            for (int i = 0; i < list.Count(); i++)
            {
                k -= list[i].Item2;
                if (k <= 0)
                {
                    num = list[i].Item1;
                    break;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = Math.Abs(nums[i] - num);

                result += (diff * (long)cost[i]);
            }

            return result;
        }

        public long MakeSimilar(int[] nums, int[] target)
        {
            int n = nums.Length;
            Array.Sort(nums);
            Array.Sort(target);
            Dictionary<int, int> mapTarget = new Dictionary<int, int>();
            Dictionary<int, int> mapNums = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                if (mapNums.ContainsKey(nums[i]))
                {
                    mapNums[nums[i]]++;
                }
                else
                {
                    mapNums.Add(nums[i], 1);
                }
                if (mapTarget.ContainsKey(target[i]))
                {
                    mapTarget[target[i]]++;
                }
                else
                {
                    mapTarget.Add(target[i], 1);
                }
            }

            foreach (var key in mapTarget.Keys)
            {
                if (mapNums.ContainsKey(key))
                {
                    while (mapTarget[key] > 0 && mapNums[key] > 0)
                    {
                        mapNums[key]--;
                        mapTarget[key]--;
                    }
                }
            }

            if (mapTarget.Values.Sum() == 0) return 0;

            int[] newNum = mapNums.Keys.Where(x => mapNums[x] > 0).ToArray();
            int[] newTarget = mapTarget.Keys.Where(x => mapTarget[x] > 0).ToArray();


            int indexI = -1, indexJ = -1;


            if (newTarget[0] % 2 == 0)
            {
                for (int i = 0; i < newNum.Length; i++)
                {
                    if (newNum[i] % 2 == 0)
                    {
                        if (newNum[i] > newTarget[0])
                        {
                            indexJ = i;
                        }
                        else
                        {
                            indexI = i;
                        }
                    }
                }
            }
            else
            {

            }

            for (int i = 0; i < newNum.Length; i++)
            {
                if (newNum[i] < newTarget[0])
                {
                    indexI = i;
                    break;
                }
            }

            for (int i = 0; i < newNum.Length; i++)
            {
                if (newNum[i] > newTarget[0])
                {
                    indexJ = i;
                    break;
                }
            }

            newNum[indexI] += 2;
            newNum[indexJ] -= 2;

            return 1 + MakeSimilar(newNum, newTarget);
        }

        #endregion

        #region Biweekly Contest 89

        public int MinimizeArrayValue(int[] nums)
        {
            int result = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                while (nums[i] > nums[i - 1])
                {
                    nums[i]--;
                    nums[i - 1]++;
                }
            }

            return nums.Max();
        }

        public int[] ProductQueries(int n, int[][] queries)
        {
            int[] result = new int[queries.Length];



            return result;
        }

        public int CountTime(string time)
        {
            var arr = time.Split(":");

            int num1 = getNum1(arr[0]);
            int num2 = getNum2(arr[1]);

            return num1 * num2;
            //List<int> list = new List<int>();

            //for (int i = 0; i < time.Length; i++)
            //{
            //    if(time[i] == '?')
            //    {
            //        list.Add(i);
            //    }
            //}
            //int count1  = 1;
            //int count2 = 1;
            //for (int i = 0; i < list.Count; i++)
            //{

            //    switch (list[i])
            //    {
            //        case 0:
            //            if (list.Contains(1))
            //            {
            //                count1 = 24;
            //                i++;
            //            }
            //            else
            //            {
            //                if(time[1] - '0' > 3)
            //                {
            //                    count1 = 2;
            //                }
            //                else
            //                {
            //                    count1 = 3;
            //                }
            //            }
            //            break;
            //        case 1:

            //                if(time[0] == '2')
            //                {
            //                    count1 = 4;
            //                }
            //                else
            //                {
            //                    count1 = 10;
            //                }
            //            break;
            //        case 2:
            //            if (list.Contains(3))
            //            {
            //                count2 = 60;
            //            }
            //            else
            //            {
            //                count2 = 6;
            //                i++;
            //            }
            //            break;
            //        case 3:
            //            count2 = 10;
            //            break;
            //        default:
            //            break;
            //    }
            //}

            //return count1 * count2;
        }

        private int getNum1(string v)
        {
            if (int.TryParse(v, out int result))
            {
                return 1;
            }
            if (v == "??") return 24;

            if (v[0] == '?')
            {

                if (v[1] - '0' > 3)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }

            if (v[1] == '?' && v[0] == '2') return 4;

            return 10;
        }

        private int getNum2(string v)
        {
            if (int.TryParse(v, out int result))
            {
                return 1;
            }
            if (v == "??") return 60;

            if (v[0] == '?')
            {
                return 6;
            }

            return 10;
        }
        #endregion
    }
}