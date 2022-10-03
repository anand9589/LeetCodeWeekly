﻿namespace October22
{
    public class Solution
    {
        #region Day 1 Problem 91. Decode Ways
        public int NumDecodings(string s)
        {
            if (s==null || s.Length == 0 || s.StartsWith('0')) return 0;
            if (s.Length == 1) return 1;

            int[] dp = new int[s.Length+1];

            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= s.Length; i++)
            {
                int l1 = int.Parse(s.Substring(i - 1, 1));
                int l2 = int.Parse(s.Substring(i - 2, 2));

                if(l1>=1 && l1 <= 9)
                {
                    dp[i] += dp[i - 1];
                }

                if(l2>=10 && l2 <= 26)
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
            if(target == 0) return 0;
            if (target > n * k) return 0;

            int count =(int) getRollsToDice(n,k,target);

            
            return count;
        }

        private long getRollsToDice(int n, int k, int target)
        {
            int mod = (int)Math.Pow(10, 9) + 7;
            long[][] dp = new long[n+1][];
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
                        if(tar-i>=0)  count+=dp[dice-1][tar-i];
                    }
                    dp[dice][tar] = count;
                }
            }

            return dp[n][target]%mod;
        }
        #endregion

        #region Weekly 313
        public int CommonFactors(int a, int b)
        {
            int result = 1;

            for (int i = 2; i <= Math.Min(a,b); i++)
            {
                if (a % i == 0 && b % i == 0) result++;
            }

            return result;
        }
        public int MaxSum(int[][] grid)
        {
            int result = 0;

            for (int i = 1; i < grid.Length-1; i++)
            {
                for (int j = 1; j < grid[i].Length-1; j++)
                {
                    int sum = grid[i-1][j-1] + grid[i-1][j] + grid[i-1][j+1] + grid[i][j] + grid[i+1][j-1] + grid[i+1][j] +grid[i+1][j+1];

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
          return  delete(s);
        }

        private int delete(string s)
        {
            if (s.Length == 0)                 return 0;
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