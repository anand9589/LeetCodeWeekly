namespace November22
{
    public class Solution
    {
        #region Daily
        #region Day 1 Problem
        #endregion
        #region Day 2 Problem
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

                if (!set.Contains(curr-1))
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

        #endregion
    }
}