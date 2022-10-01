namespace October22
{
    public class Solution
    {
        #region Day 1 Problem 91 Decode Ways
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
    }
}