using System.Text;

namespace November22
{
    public class Solution
    {
        #region Daily

        #region Day 1 Problem 1706. Where Will the Ball Fall
        public int[] FindBall(int[][] grid)
        {
            int[][] dp = new int[grid.Length][];
            //Array.Copy(grid, dp, dp.Length);

            for (int i = 0; i < grid.Length; i++)
            {
                dp[i] = new int[grid[i].Length];
                for (int j = 0; j < grid[i].Length; j++)
                {
                    dp[i][j] = grid[i][j];
                }
            }

            int m = grid.Length;
            int n = grid[0].Length;
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = getBallTrack(grid, dp, 0, i);
            }

            return result;

        }

        private int getBallTrack(int[][] grid, int[][] dp, int i, int j)
        {

            while (i < grid.Length)
            {
                if (dp[i][j] == -2) return -1;
                if (grid[i][j] == 1)
                {
                    if (j == grid[0].Length - 1) return -1;
                    if (grid[i][j] != grid[i][j + 1])
                    {
                        dp[i][j] = -2;
                        return -1;
                    }
                    j++;
                }
                else
                {
                    if (j == 0) return -1;
                    if (grid[i][j] != grid[i][j - 1])
                    {
                        dp[i][j] = -2;
                        return -1;
                    }
                    j--;
                }
                i++;
            }
            return j;
        }



        #endregion

        #region Day 2 Problem 433. Minimum Genetic Mutation
        public int MinMutation(string start, string end, string[] bank)
        {
            Queue<string> queue = new Queue<string>();
            HashSet<string> set = new HashSet<string>();


            queue.Enqueue(start);
            set.Add(start);

            char[] chs = new char[] { 'A', 'C', 'G', 'T' };
            int steps = 0;

            while (queue.Count > 0)
            {
                int len = queue.Count;

                for (int i = 0; i < len; i++)
                {
                    string node = queue.Dequeue();

                    if (node.Equals(end))
                    {
                        return steps;
                    }


                    foreach (char c in chs)
                    {
                        for (int j = 0; j < node.Length; j++)
                        {
                            string n = node.Substring(0, j) + c + node.Substring(j + 1);

                            if (!set.Contains(n) && bank.Contains(n))
                            {
                                queue.Enqueue(n);
                                set.Add(n);
                            }
                        }
                    }
                }
                steps++;
            }

            return -1;
        }
        #endregion

        #region Day 3 Problem
        #endregion

        #region Day 4 Problem
        #endregion

        #region Day 5 Problem
        #endregion

        #region Day 6 Problem
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
        #endregion

        #region Problems

        #region Problem 128. Longest Consecutive Sequence
        public int LongestConsecutive(int[] nums)
        {
            int result = 0;
            HashSet<int> set = new HashSet<int>();
            foreach (int n in nums)
            {
                set.Add(n);
            }


            for (int i = 0; i < nums.Length; i++)
            {
                int counter = 1;
                int curr = nums[i];

                if (!set.Contains(curr - 1))
                {
                    while (set.Contains(++curr))
                    {
                        counter++;
                    }
                }
                result = Math.Max(result, counter);
            }

            return result;
        }
        #endregion

        #region Problem 191. Number of 1 Bits
        public int HammingWeight(uint n)
        {
            int counter = 0;

            while (n > 0)
            {
                counter += (int)n & 1;
                n >>= 1;
            }
            return counter;
        }
        #endregion

        #region Problem 1281. Subtract the Product and Sum of Digits of an Integer
        public int SubtractProductAndSum(int n)
        {
            int product = 1;
            int sum = 0;

            while (n > 0)
            {
                int rem = n % 10;

                product *= rem;
                sum += rem;
                n /= 10;
            }

            return product - sum;
        }
        public int SubtractProductAndSum_v1(int n)
        {
            int product = 1;
            
            int sum = 0;

            while (n > 0)
            {
                int rem = n % 10;

                product *= rem;
                sum += rem;
                n /= 10;
            }

            return product - sum;
        }
        #endregion

        #region Problem 1491. Average Salary Excluding the Minimum and Maximum Salary
        public double Average(int[] salary)
        {
            return (double)(salary.Sum() - salary.Max() - salary.Min()) / (salary.Length - 2);
        }
        #endregion

        #region Problem 1523. Count Odd Numbers in an Interval Range
        public int CountOdds(int low, int high)
        {
            int result = 0;
            if (low % 2 == 1)
            {
                result++;
                low++;
            }
            if (low < high)
            {

                if (high % 2 == 1)
                {
                    result++;
                    high--;
                }
                result += (high - low) / 2;
            }

            return result;
        }
        #endregion
        #endregion
    }
}